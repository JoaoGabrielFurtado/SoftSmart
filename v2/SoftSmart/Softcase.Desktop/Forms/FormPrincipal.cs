using Newtonsoft.Json;
using Softcase.Core;
using Softcase.Core.Classes;
using Softcase.Core.DTOs;
using Softcase.Desktop.Forms;
using Softcase.ML; 
using System.Linq.Expressions;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Softcase.Desktop
{
    public partial class FormPrincipal : Form
    {

        private float estaChovendo = 0;
        private float ehFeriado = 0;
        private bool temEvento = false;
        private DateTime data = DateTime.Now;
        private static readonly HttpClient _httpClient = new HttpClient();
        private List<string> ListaCidade = new();
        private ServicoDePrevisao servicoDePrevisao = new();

        public FormPrincipal()
        {
            InitializeComponent();


            //COMBO BOX PREVER
            List<string> Prever = new List<string>()
            {
                "1", "2", "3", "4", "5"
            };
            foreach (string s in Prever)
            {
                Cbx_Prever.Items.Add(s);
            }
            Cbx_Prever.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //COMBO BOX CIDADES
            PopulaCidades();
        }


        private async void Btn_VerificaIA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Cbx_Cidade.Text))
            {
                MessageBox.Show("Por favor, selecione uma cidade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Cbx_Prever.Text) || !int.TryParse(Cbx_Prever.Text, out int prever))
            {
                MessageBox.Show("Por favor, selecione quantos dias deseja prever.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Btn_VerificaIA.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                string cidade = Cbx_Cidade.Text;
                List<PrevisaoFutura> _listaPrevisao = await servicoDePrevisao.RetornaPrevisaoFuturaAsync(cidade, prever);

                List<ResultadoConsolidado> _listaResultados = new();

                List<DateTime> diasComEvento = new();

                if (temEvento)
                    diasComEvento = ChamaFormEvento(prever);

                float capacidadeTotalIA = 250f;


                foreach (var item in _listaPrevisao)
                {
                    var diaSemana = item.Data.DayOfWeek;
                    TimeSpan hora = item.Data.TimeOfDay;
                    float evento = diasComEvento.Contains(item.Data.Date) ? 1 : 0;
                    float temChuva = item.Chuva;
                    float ehFeriado = item.EhFeriado;

                    int ocupManha = ServicoDeIA.RetornaResultadoIA(9f, (float)diaSemana, item.TempManha, temChuva, evento, ehFeriado);
                    int pctManha = (int)Math.Round((ocupManha / capacidadeTotalIA) * 100);

                    int ocupTarde = ServicoDeIA.RetornaResultadoIA(15f, (float)diaSemana, item.TempTarde, temChuva, evento, ehFeriado);
                    int pctTarde = (int)Math.Round((ocupTarde / capacidadeTotalIA) * 100);

                    int ocupNoite = ServicoDeIA.RetornaResultadoIA(21f, (float)diaSemana, item.TempNoite, temChuva, evento, ehFeriado);
                    int pctNoite = (int)Math.Round((ocupNoite / capacidadeTotalIA) * 100);

                    pctManha = Math.Clamp(pctManha, 0, 100);
                    pctTarde = Math.Clamp(pctTarde, 0, 100);
                    pctNoite = Math.Clamp(pctNoite, 0, 100);

                    ResultadoConsolidado resultado = new ResultadoConsolidado
                    {
                        Data = item.Data.ToString("dd/MM"),
                        DiaSemana = item.Data.ToString("dddd"),

                        OcupacaoManha = $"{pctManha}%",
                        OcupacaoTarde = $"{pctTarde}%",
                        OcupacaoNoite = $"{pctNoite}%",

                        OcupacaoManhaInt = pctManha,
                        OcupacaoTardeInt = pctTarde,
                        OcupacaoNoiteInt = pctNoite,


                        TemperaturaMedia = (item.TempManha + item.TempTarde + item.TempNoite) / 3,
                        Evento = evento == 1 ? "Sim" : "Não",
                        TemChuva = temChuva == 1 ? "Sim" : "Não"
                    };

                    _listaResultados.Add(resultado);
                }

                FormDashboard janelaDashboard = new FormDashboard(_listaResultados);
                janelaDashboard.ShowDialog();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Ocorreu um erro: {erro.Message}");
            }
            finally
            {
                Btn_VerificaIA.Enabled = true;
                Cursor = Cursors.Default;
            }
        }
        private void Lbl_Informacoes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Caso possua um ou mais eventos nos dias que você deseja prever marque \"TEM EVENTO?\" e preencha as opções.", "Tem Eventos?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Cbx_Evento_CheckedChanged(object sender, EventArgs e)
        {
            if (Cbx_Evento.Checked)
                temEvento = true;
            else
                temEvento = false;
        }

        private void Cbx_Cidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                int indexExato = Cbx_Cidade.FindStringExact(Cbx_Cidade.Text);

                if (indexExato != -1)
                {
                    Cbx_Cidade.SelectedIndex = indexExato;
                    return;
                }

                int indexAproximado = Cbx_Cidade.FindString(Cbx_Cidade.Text);
                if (indexAproximado != -1)
                {
                    Cbx_Cidade.SelectedIndex = indexAproximado;
                    Cbx_Cidade.Text = Cbx_Cidade.Items[indexAproximado].ToString();
                    Cbx_Cidade.Select(Cbx_Cidade.Text.Length, 0);
                }
            }
        }



        //METODOS
        #region METODO ANTIGO
        //public async Task<List<PrevisaoFutura>> RetornaPrevisaoFuturaAsync(string cidade, int prever)
        //{
        //    List<PrevisaoFutura> listaPrevisaoFutura = new();
        //    RespostaClima retorno = await servicoDeClima.VerificaClimaAsync(cidade);

        //    if (retorno == null || retorno.list == null) return listaPrevisaoFutura;

        //    for (int i = 1; i <= prever; i++)
        //    {
        //        DateTime dataAlvo = DateTime.Now.Date.AddDays(i);

        //        var itemEncontrado = retorno.list.FirstOrDefault(x =>
        //            Convert.ToDateTime(x.dt_txt).Date == dataAlvo &&
        //            Convert.ToDateTime(x.dt_txt).Hour == 12
        //        );

        //        if (itemEncontrado == null)
        //        {
        //            itemEncontrado = retorno.list.FirstOrDefault(x =>
        //               Convert.ToDateTime(x.dt_txt).Date == dataAlvo
        //            );
        //        }

        //        if (itemEncontrado != null)
        //        {
        //            float indicadorChuva = 0;
        //            if (itemEncontrado.weather != null && itemEncontrado.weather.Length > 0)
        //            {
        //                string condicao = itemEncontrado.weather[0].main;
        //                if (condicao == "Rain" || condicao == "Thunderstorm" || condicao == "Drizzle")
        //                    indicadorChuva = 1;
        //            }

        //            bool feriado = ServicoDeCalendario.EhFeriado(Convert.ToDateTime(itemEncontrado.dt_txt));

        //            PrevisaoFutura p = new PrevisaoFutura
        //            {
        //                Data = Convert.ToDateTime(itemEncontrado.dt_txt),
        //                Temperatura = (float)Math.Round(itemEncontrado.main.temp),
        //                Chuva = indicadorChuva,
        //                EhFeriado = feriado ? 1 : 0
        //            };
        //            listaPrevisaoFutura.Add(p);
        //        }
        //    }
        //    return listaPrevisaoFutura;
        //}

        #endregion

        private async void PopulaCidades()
        {
            try
            {
                Cbx_Cidade.Enabled = false;
                Cbx_Cidade.Items.Clear();
                Cbx_Cidade.Items.Add("Carregando...");
                Cbx_Cidade.SelectedIndex = 0;

                string url = "https://servicodados.ibge.gov.br/api/v1/localidades/municipios?orderBy=asc";

                using (var resposta = await _httpClient.GetAsync(url))
                {
                    resposta.EnsureSuccessStatusCode();
                    var jsonString = await resposta.Content.ReadAsStringAsync();

                    var dadosCidades = JsonConvert.DeserializeObject<List<dynamic>>(jsonString);

                    Cbx_Cidade.BeginUpdate();

                    Cbx_Cidade.Items.Clear();

                    foreach (var c in dadosCidades)
                    {
                        Cbx_Cidade.Items.Add(c.nome.ToString());
                    }

                    Cbx_Cidade.EndUpdate();

                    Cbx_Cidade.AutoCompleteSource = AutoCompleteSource.ListItems;
                    Cbx_Cidade.AutoCompleteMode = AutoCompleteMode.Suggest;
                    Cbx_Cidade.DropDownStyle = ComboBoxStyle.DropDown;

                    if (Cbx_Cidade.Items.Count > 0)
                    {
                        Cbx_Cidade.SelectedIndex = 0;
                    }

                    Cbx_Cidade.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cidades: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Cbx_Cidade.Items.Clear();
                Cbx_Cidade.Enabled = true;
            }
        }

        private List<DateTime> ChamaFormEvento(int prever)
        {
            Eventos evento = new Eventos(prever);
            var resultado = evento.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                List<DateTime> diasSelecionados = evento.RetornaDiasSelecionados();
                return diasSelecionados;
            }

            return new List<DateTime>();
        }


    }
}
