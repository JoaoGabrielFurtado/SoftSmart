using Softcase.ML; 
using Newtonsoft.Json;
using Softcase.Core;
using Softcase.Core.DTOs;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Softcase.Core.Classes;
using Softcase.Desktop.Forms;

namespace Softcase.Desktop
{
    public partial class FormPrincipal : Form
    {

        private float estaChovendo = 0;
        private float ehFeriado = 0;
        private bool temEvento = false;
        private DateTime data = DateTime.Now;
        public ServicoDeClima servicoDeClima = new();

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

            //COMBO BOX CIDADES
            List<string> Cidades = new List<string>()
            {
                "Santos", "São Paulo", "Salvador", "São Vicente", "Guarujá", "Praia Grande", "Rio de Janeiro", "Curitiba", "Porto Alegre", "Brasília"
            };
            foreach (string s in Cidades)
            {
                Cbx_Cidade.Items.Add(s);
            }
            Cbx_Cidade.DropDownStyle = ComboBoxStyle.DropDownList;
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
                List<PrevisaoFutura> _listaPrevisao = await RetornaPrevisaoFuturaAsync(cidade, prever);

                List<ResultadoConsolidado> _listaResultados = new();

                List<DateTime> diasComEvento = new();

                if (temEvento)
                    diasComEvento = ChamaFormEvento(prever);

                //flexibilizar no futuro
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
            catch(Exception erro)
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


        //METODOS
        public async Task<List<PrevisaoFutura>> RetornaPrevisaoFuturaAsync(string cidade, int prever)
        {
            List<PrevisaoFutura> listaPrevisaoFutura = new();
            RespostaClima retorno = await servicoDeClima.VerificaClimaAsync(cidade);

            if (retorno == null || retorno.list == null) return listaPrevisaoFutura;

            for (int i = 1; i <= prever; i++)
            {
                DateTime dataAlvo = DateTime.Now.Date.AddDays(i);

                var registrosDoDia = retorno.list.Where(x => Convert.ToDateTime(x.dt_txt).Date == dataAlvo).ToList();

                if (registrosDoDia.Any())
                {
                    var principal = registrosDoDia.FirstOrDefault(x => Convert.ToDateTime(x.dt_txt).Hour == 12) ?? registrosDoDia.First();


                    var itemManha = registrosDoDia.FirstOrDefault(x => Convert.ToDateTime(x.dt_txt).Hour == 9) ?? registrosDoDia.First();

                    var itemTarde = registrosDoDia.FirstOrDefault(x => Convert.ToDateTime(x.dt_txt).Hour == 15) ?? principal;

                    var itemNoite = registrosDoDia.FirstOrDefault(x => Convert.ToDateTime(x.dt_txt).Hour == 21) ?? registrosDoDia.Last();


                    float indicadorChuva = 0;
                    if (principal.weather != null && principal.weather.Length > 0)
                    {
                        string condicao = principal.weather[0].main;
                        if (condicao == "Rain" || condicao == "Thunderstorm" || condicao == "Drizzle")
                            indicadorChuva = 1;
                    }

                    bool feriado = ServicoDeCalendario.EhFeriado(dataAlvo);

                    PrevisaoFutura p = new PrevisaoFutura
                    {
                        Data = dataAlvo,
                        Temperatura = (float)Math.Round(principal.main.temp), 
                        Chuva = indicadorChuva,
                        EhFeriado = feriado ? 1 : 0,


                        TempManha = (float)Math.Round(itemManha.main.temp),
                        TempTarde = (float)Math.Round(itemTarde.main.temp),
                        TempNoite = (float)Math.Round(itemNoite.main.temp)
                    };
                    listaPrevisaoFutura.Add(p);
                }
            }
            return listaPrevisaoFutura;
        }


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
