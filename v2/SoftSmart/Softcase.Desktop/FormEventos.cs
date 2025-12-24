using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softcase.Desktop
{
    public partial class Eventos : Form
    {
        public Eventos(int prever)
        {
            InitializeComponent();
            ConstuirDiasNaTela(prever);
        }

        public void ConstuirDiasNaTela(int prever)
        {
            DateTime dataAtual = DateTime.Now.Date;
            for (int i = 1; i < prever + 1; i++)
            {
                var cbox = new CheckBox();
                cbox.Text = dataAtual.AddDays(i).ToString("dd/MM/yyyy");
                cbox.Name = "Cbx_DiaEvento" + i.ToString();
                cbox.AutoSize = true;
                Flp_PainelDias.Controls.Add(cbox);
            }
        }

        public List<DateTime> RetornaDiasSelecionados()
        {
            List<DateTime> diasSelecionados = new List<DateTime>();
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    DateTime dataSelecionada;
                    if (DateTime.TryParse(checkBox.Text, out dataSelecionada))
                    {
                        diasSelecionados.Add(dataSelecionada);
                    }
                }
            }
            return diasSelecionados;
        }

        private void FormEventos_Load(object sender, EventArgs e)
        {

        }

        private void Btn_ConcluirEventos_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
