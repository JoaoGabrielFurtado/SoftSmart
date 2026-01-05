using Softcase.Core.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softcase.Desktop.Forms
{
    public partial class FormDashboard : Form
    {
        public FormDashboard(List<ResultadoConsolidado> resultados)
        {
            InitializeComponent();
            CarregarCards(resultados);
        }

        private void CarregarCards(List<ResultadoConsolidado> lista)
        {
            flp_Galeria.Controls.Clear();
            foreach (var item in lista)
            {
                var cartao = new Softcase.Desktop.Forms.UC_TelaResultados(); 
                cartao.ConfigurarDados(item);
                flp_Galeria.Controls.Add(cartao);
            }
        }
    }
}
