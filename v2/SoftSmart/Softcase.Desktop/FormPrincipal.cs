using Newtonsoft.Json;
using Softcase.Core;
using Softcase.Core.DTOs;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;

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
            string cidade = Cbx_Cidade.Text;
            int prever = Convert.ToInt32(Cbx_Prever.Text);

            List<PrevisaoFutura> _listaPrevisao = await RetornaPrevisaoFuturaAsync(cidade, prever);

            List<ResultadoConsolidado> _listaResultados = new();

            List<DateTime> diasComEvento = new();

            if (temEvento)
                diasComEvento = ChamaFormEvento(prever);

            foreach (var item in _listaPrevisao)
            {
                var diaSemana = item.Data.DayOfWeek;
                TimeSpan hora = item.Data.TimeOfDay;
                float evento = diasComEvento.Contains(item.Data.Date) ? 1 : 0;
                float temChuva = item.Chuva;
                float ehFeriado = ServicoDeCalendario.EhFeriado(item.Data) ? 1 : 0;
                int ocupacao = ServicoDeIA.RetornaResultadoIA((float)hora.TotalHours, (float)diaSemana, item.Temperatura, temChuva, evento, ehFeriado);
                string motivo = "AINDA NADA";

                ResultadoConsolidado resultado = new ResultadoConsolidado
                {
                    Data = item.Data,
                    Temperatura = item.Temperatura,
                    OcupacaoPrevista = ocupacao,
                    Evento = evento == 1 ? "Tem evento" : "Não tem evento",
                    MotivoPrincipal = motivo
                };


                _listaResultados.Add(resultado);

            }

            Dgv_Infos.DataSource = " ";
            Dgv_Infos.DataSource = _listaResultados;

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

                var itemEncontrado = retorno.list.FirstOrDefault(x =>
                    Convert.ToDateTime(x.dt_txt).Date == dataAlvo &&
                    Convert.ToDateTime(x.dt_txt).Hour == 12
                );

                if (itemEncontrado == null)
                {
                    itemEncontrado = retorno.list.FirstOrDefault(x =>
                       Convert.ToDateTime(x.dt_txt).Date == dataAlvo
                    );
                }

                if (itemEncontrado != null)
                {
                    float indicadorChuva = 0;
                    if (itemEncontrado.weather != null && itemEncontrado.weather.Length > 0)
                    {
                        string condicao = itemEncontrado.weather[0].main;
                        if (condicao == "Rain" || condicao == "Thunderstorm" || condicao == "Drizzle")
                            indicadorChuva = 1;
                    }

                    bool feriado = ServicoDeCalendario.EhFeriado(Convert.ToDateTime(itemEncontrado.dt_txt));

                    PrevisaoFutura p = new PrevisaoFutura
                    {
                        Data = Convert.ToDateTime(itemEncontrado.dt_txt),
                        Temperatura = (float)Math.Round(itemEncontrado.main.temp),
                        Chuva = indicadorChuva
                    };
                    listaPrevisaoFutura.Add(p);
                }
            }
            return listaPrevisaoFutura;
        }

        private List<DateTime> ChamaFormEvento(int prever)
        {
            Eventos evento = new Eventos(prever);
            evento.ShowDialog();
            List<DateTime> diasSelecionados = evento.RetornaDiasSelecionados();
            return diasSelecionados;
        }


    }
}
