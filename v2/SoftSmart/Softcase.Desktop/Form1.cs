using Newtonsoft.Json;
using Softcase.Core;
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
            float cidade = Cbx_Cidade.SelectedIndex;
            string cidadeString = Cbx_Cidade.Text;
            int prever;
            try
            {
                prever = Convert.ToInt32(Cbx_Prever.Text);
            }
            catch (Exception er)
            {
                MessageBox.Show("Preencha o campo 'Prever quantos dias'", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cidade == -1)
            {
                MessageBox.Show("Selecione uma cidade!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> diasPrever = new();

            for(int i = 1; i < prever + 1; i++)
            {
                DateTime dateSoma = data.AddDays(i);
                diasPrever.Add(dateSoma.ToString());    
            }

            foreach (string i in diasPrever)
            {
                MessageBox.Show(i);
            }

            MessageBox.Show("DATA RESETADA " + data);

            float temperatura = await RetornaClimaAsync(cidadeString);

            MessageBox.Show(temperatura.ToString());

            int previsao = ServicoDeIA.RetornaResultadoIA(
                22, 2, temperatura, 0, 0, 0
            );
        }

        //METODOS

        public async Task<float> RetornaClimaAsync(string cidade)
        {
            RespostaClima retorno = await servicoDeClima.VerificaClimaAsync(cidade);
            if (retorno == null || retorno.list == null || retorno.list.Count == 0)
                return 0f;
            int temperatura = Convert.ToInt32(retorno.list[0].main.temp);
            return temperatura;
        }
    }
}
