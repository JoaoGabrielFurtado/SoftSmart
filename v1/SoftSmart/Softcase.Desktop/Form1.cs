using Softcase.Core;
using Softcase_ML;

namespace Softcase.Desktop
{
    public partial class Form1 : Form
    {

        private float estaChovendo = 0;
        private float ehFeriado = 0;
        private float temEvento = 0;

        public Form1()
        {
            InitializeComponent();

            //LABELS
            Lbl_MarcaHora.Text = Trb_Horario.Value.ToString() + "h";
            Lbl_MarcaTemp.Text = Trb_Temperatura.Value.ToString() + "ºC";

            //COMBO BOX
            List<string> Dias = new List<string>()
            {
                "Domingo", "Segunda-Feira", "Terça-Feira", "Quarta-Feira", "Quinta-Feira", "Sexta-Feira", "Sábado"
            };
            foreach (string s in Dias)
            {
                Cbx_DiasSemana.Items.Add(s);
            }
            Cbx_DiasSemana.DropDownStyle = ComboBoxStyle.DropDownList; // Impede escrita no combo box
        }

        private void Trb_Horario_Scroll(object sender, EventArgs e)
        {
            Lbl_MarcaHora.Text = Trb_Horario.Value.ToString() + "h";
        }

        private void Trb_Temperatura_Scroll(object sender, EventArgs e)
        {
            Lbl_MarcaTemp.Text = Trb_Temperatura.Value.ToString() + "ºC";
        }

        private void Ckb_Chuva_CheckedChanged(object sender, EventArgs e)
        {
            if (Ckb_Chuva.Checked)
                estaChovendo = 1;
            else estaChovendo = 0;

        }

        private void Ckb_Evento_CheckedChanged(object sender, EventArgs e)
        {
            if (Ckb_Evento.Checked)
                temEvento = 1;
            else temEvento = 0;
        }

        private void Ckb_EhFeriado_CheckedChanged(object sender, EventArgs e)
        {
            if (Ckb_EhFeriado.Checked)
                ehFeriado = 1;
            else ehFeriado = 0;
        }

        private void Btn_VerificaIA_Click(object sender, EventArgs e)
        {
            float horario = Trb_Horario.Value;
            string dia = Cbx_DiasSemana.Text;
            float diaSemana = -1;
            switch (dia)
            {
                case "Domingo":
                    diaSemana = 0;
                    break;
                case "Segunda-Feira":
                    diaSemana = 1;
                    break;
                case "Terça-Feira":
                    diaSemana = 2;
                    break;
                case "Quarta-Feira":
                    diaSemana = 3;
                    break;
                case "Quinta-Feira":
                    diaSemana = 4;
                    break;
                case "Sexta-Feira":
                    diaSemana = 5;
                    break;
                case "Sábado":
                    diaSemana = 6;
                    break;
                default:
                    diaSemana = -1;
                    break;
            }
            if (diaSemana == -1)
            {
                MessageBox.Show("Dia da Semana inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            float temperatura = Trb_Temperatura.Value;

            var dadosEntrada = new ModeloOcupacao.ModelInput
            {
                Hora = horario,
                DiaDaSemana = diaSemana,
                Temperatura = temperatura,
                Chuva = estaChovendo,
                EventoNaRegiao = temEvento,
                EhFeriado = ehFeriado
            };

            var resultado = ModeloOcupacao.Predict(dadosEntrada);

            Lbl_Ocupacao.Text = ((int)resultado.Score).ToString();

        }
    }
}
