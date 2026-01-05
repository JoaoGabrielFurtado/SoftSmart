using Softcase.Core;
using Softcase.Core.Classes;
using Softcase.Core.DTOs;
using System.Drawing;
using System.Windows.Forms;

namespace Softcase.Desktop.Forms 
{
    public partial class UC_TelaResultados : UserControl
    {
        public UC_TelaResultados()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;
        }

        public void ConfigurarDados(ResultadoConsolidado dados)
        {
            Lb_Data.Text = $"{dados.DiaSemana} - {dados.Data}  ";
            Lb_Temp.Text = $"{dados.TemperaturaMedia:F0}°C";

            if (dados.TemChuva == "Sim") Lb_Temp.Text += " 🌧";
            else Lb_Temp.Text += " ☀";

            if (dados.Evento == "Sim")
            {
                Lb_Evento.Visible = true;
                this.BackColor = Color.MistyRose;
            }
            else
            {
                Lb_Evento.Visible = false;
                this.BackColor = Color.White;
            }

            AtualizarBarra(Pb_Manha, Lb_PctManha, dados.OcupacaoManhaInt);
            AtualizarBarra(Pb_Tarde, Lb_PctTarde, dados.OcupacaoTardeInt);
            AtualizarBarra(Pb_Noite, Lb_PctNoite, dados.OcupacaoNoiteInt);

            string motivo = ServicoDeMotivo.GerarMotivo(
                dados.OcupacaoManhaInt,
                dados.OcupacaoTardeInt,
                dados.OcupacaoNoiteInt,
                dados.Evento,
                dados.TemChuva,
                dados.TemperaturaMedia
            );

            Lb_Motivo.Text = motivo;
        }

        private void AtualizarBarra(ProgressBar barra, Label labelPct, int valor)
        {
            if (valor > 100) valor = 100;
            if (valor < 0) valor = 0;
            barra.Value = valor;
            labelPct.Text = $"{valor}%";
        }
    }
}