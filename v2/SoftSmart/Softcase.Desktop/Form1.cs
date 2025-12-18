using Newtonsoft.Json;
using Softcase.Core;
using Softcase.Core.DTOs;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;

namespace Softcase.Desktop
{
    public partial class Form1 : Form
    {

        private float estaChovendo = 0;
        private float ehFeriado = 0;
        private float temEvento = 0;
        private DateTime data = DateTime.Now;
        public ServicoDeClima servicoDeClima = new();

        public Form1()
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

            foreach (var item in _listaPrevisao)
            {

                var diaSemana = item.Data.DayOfWeek;
                TimeSpan hora = item.Data.TimeOfDay;
                int ocupacao = ServicoDeIA.RetornaResultadoIA((float)hora.TotalHours, (float)diaSemana, item.Temperatura, 0, 0, 0);
                string motivo = "AINDA NADA";

                ResultadoConsolidado result = new ResultadoConsolidado
                {
                    Data = item.Data,
                    Temperatura = item.Temperatura,
                    OcupacaoPrevista = ocupacao,
                    MotivoPrincipal = motivo
                };


                _listaResultados.Add(result);

            }

            Dgv_Infos.DataSource = " ";
            Dgv_Infos.DataSource = _listaResultados;

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

                // Data 
                // horário 12:00
                var itemEncontrado = retorno.list.FirstOrDefault(x =>
                    Convert.ToDateTime(x.dt_txt).Date == dataAlvo &&
                    Convert.ToDateTime(x.dt_txt).Hour == 12
                );

                // tenta pegar qualquer horário daquele dia para não ficar vazio
                if (itemEncontrado == null)
                {
                    itemEncontrado = retorno.list.FirstOrDefault(x =>
                       Convert.ToDateTime(x.dt_txt).Date == dataAlvo
                    );
                }

                if (itemEncontrado != null)
                {
                    PrevisaoFutura p = new PrevisaoFutura
                    {
                        Data = Convert.ToDateTime(itemEncontrado.dt_txt),
                        Temperatura = (float)Math.Round(itemEncontrado.main.temp)
                    };

                    listaPrevisaoFutura.Add(p); 
                }
            }
            return listaPrevisaoFutura;
        }
    }
}
