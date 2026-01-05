namespace Softcase.Desktop.Forms
{
    partial class UC_TelaResultados
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer

        private void InitializeComponent()
        {
            Lb_Data = new Label();
            Lb_Temp = new Label();
            Lb_Evento = new Label();
            Pb_Manha = new ProgressBar();
            lblStaticManha = new Label();
            Lb_PctManha = new Label();
            Lb_PctTarde = new Label();
            lblStaticTarde = new Label();
            Pb_Tarde = new ProgressBar();
            Lb_PctNoite = new Label();
            lblStaticNoite = new Label();
            Pb_Noite = new ProgressBar();
            panelSeparator = new Panel();
            Lb_Motivo = new Label();
            SuspendLayout();
            // 
            // Lb_Data
            // 
            Lb_Data.AutoSize = true;
            Lb_Data.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Lb_Data.ForeColor = Color.FromArgb(64, 64, 64);
            Lb_Data.Location = new Point(12, 12);
            Lb_Data.Name = "Lb_Data";
            Lb_Data.Size = new Size(141, 21);
            Lb_Data.TabIndex = 0;
            Lb_Data.Text = "Data Placeholder";
            // 
            // Lb_Temp
            // 
            Lb_Temp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Lb_Temp.Font = new Font("Segoe UI", 14F);
            Lb_Temp.ForeColor = Color.DarkOrange;
            Lb_Temp.Location = new Point(170, 8);
            Lb_Temp.Name = "Lb_Temp";
            Lb_Temp.Size = new Size(115, 25);
            Lb_Temp.TabIndex = 1;
            Lb_Temp.Text = "00°C";
            Lb_Temp.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Lb_Evento
            // 
            Lb_Evento.AutoSize = true;
            Lb_Evento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Lb_Evento.ForeColor = Color.Red;
            Lb_Evento.Location = new Point(14, 38);
            Lb_Evento.Name = "Lb_Evento";
            Lb_Evento.Size = new Size(135, 15);
            Lb_Evento.TabIndex = 2;
            Lb_Evento.Text = "⚠ EVENTO NA REGIÃO";
            Lb_Evento.Visible = false;
            // 
            // Pb_Manha
            // 
            Pb_Manha.Location = new Point(15, 88);
            Pb_Manha.Name = "Pb_Manha";
            Pb_Manha.Size = new Size(220, 10);
            Pb_Manha.Style = ProgressBarStyle.Continuous;
            Pb_Manha.TabIndex = 25;
            // 
            // lblStaticManha
            // 
            lblStaticManha.AutoSize = true;
            lblStaticManha.ForeColor = Color.DimGray;
            lblStaticManha.Location = new Point(12, 70);
            lblStaticManha.Name = "lblStaticManha";
            lblStaticManha.Size = new Size(82, 15);
            lblStaticManha.TabIndex = 24;
            lblStaticManha.Text = "Manhã (09:00)";
            // 
            // Lb_PctManha
            // 
            Lb_PctManha.AutoSize = true;
            Lb_PctManha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Lb_PctManha.Location = new Point(241, 85);
            Lb_PctManha.Name = "Lb_PctManha";
            Lb_PctManha.Size = new Size(24, 15);
            Lb_PctManha.TabIndex = 23;
            Lb_PctManha.Text = "0%";
            // 
            // Lb_PctTarde
            // 
            Lb_PctTarde.AutoSize = true;
            Lb_PctTarde.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Lb_PctTarde.Location = new Point(241, 125);
            Lb_PctTarde.Name = "Lb_PctTarde";
            Lb_PctTarde.Size = new Size(24, 15);
            Lb_PctTarde.TabIndex = 20;
            Lb_PctTarde.Text = "0%";
            // 
            // lblStaticTarde
            // 
            lblStaticTarde.AutoSize = true;
            lblStaticTarde.ForeColor = Color.DimGray;
            lblStaticTarde.Location = new Point(12, 110);
            lblStaticTarde.Name = "lblStaticTarde";
            lblStaticTarde.Size = new Size(74, 15);
            lblStaticTarde.TabIndex = 21;
            lblStaticTarde.Text = "Tarde (15:00)";
            // 
            // Pb_Tarde
            // 
            Pb_Tarde.Location = new Point(15, 128);
            Pb_Tarde.Name = "Pb_Tarde";
            Pb_Tarde.Size = new Size(220, 10);
            Pb_Tarde.Style = ProgressBarStyle.Continuous;
            Pb_Tarde.TabIndex = 22;
            // 
            // Lb_PctNoite
            // 
            Lb_PctNoite.AutoSize = true;
            Lb_PctNoite.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Lb_PctNoite.Location = new Point(241, 165);
            Lb_PctNoite.Name = "Lb_PctNoite";
            Lb_PctNoite.Size = new Size(24, 15);
            Lb_PctNoite.TabIndex = 17;
            Lb_PctNoite.Text = "0%";
            // 
            // lblStaticNoite
            // 
            lblStaticNoite.AutoSize = true;
            lblStaticNoite.ForeColor = Color.DimGray;
            lblStaticNoite.Location = new Point(12, 150);
            lblStaticNoite.Name = "lblStaticNoite";
            lblStaticNoite.Size = new Size(74, 15);
            lblStaticNoite.TabIndex = 18;
            lblStaticNoite.Text = "Noite (21:00)";
            // 
            // Pb_Noite
            // 
            Pb_Noite.Location = new Point(15, 168);
            Pb_Noite.Name = "Pb_Noite";
            Pb_Noite.Size = new Size(220, 10);
            Pb_Noite.Style = ProgressBarStyle.Continuous;
            Pb_Noite.TabIndex = 19;
            // 
            // panelSeparator
            // 
            panelSeparator.BackColor = Color.LightGray;
            panelSeparator.Location = new Point(15, 60);
            panelSeparator.Name = "panelSeparator";
            panelSeparator.Size = new Size(260, 1);
            panelSeparator.TabIndex = 16;
            // 
            // Lb_Motivo
            // 
            Lb_Motivo.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            Lb_Motivo.ForeColor = Color.FromArgb(50, 50, 80);
            Lb_Motivo.Location = new Point(15, 195);
            Lb_Motivo.Name = "Lb_Motivo";
            Lb_Motivo.Size = new Size(260, 45);
            Lb_Motivo.TabIndex = 15;
            Lb_Motivo.Text = "Análise: Ocupação normal esperada.";
            // 
            // UC_TelaResultados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(Lb_Motivo);
            Controls.Add(panelSeparator);
            Controls.Add(Lb_PctNoite);
            Controls.Add(lblStaticNoite);
            Controls.Add(Pb_Noite);
            Controls.Add(Lb_PctTarde);
            Controls.Add(lblStaticTarde);
            Controls.Add(Pb_Tarde);
            Controls.Add(Lb_PctManha);
            Controls.Add(lblStaticManha);
            Controls.Add(Pb_Manha);
            Controls.Add(Lb_Evento);
            Controls.Add(Lb_Temp);
            Controls.Add(Lb_Data);
            Name = "UC_TelaResultados";
            Size = new Size(290, 250);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Label Lb_Data;
        public System.Windows.Forms.Label Lb_Temp;
        public System.Windows.Forms.Label Lb_Evento;
        public System.Windows.Forms.ProgressBar Pb_Manha;
        public System.Windows.Forms.Label Lb_PctManha;
        public System.Windows.Forms.ProgressBar Pb_Tarde;
        public System.Windows.Forms.Label Lb_PctTarde;
        public System.Windows.Forms.ProgressBar Pb_Noite;
        public System.Windows.Forms.Label Lb_PctNoite;
        public System.Windows.Forms.Label Lb_Motivo; 

        private System.Windows.Forms.Label lblStaticManha;
        private System.Windows.Forms.Label lblStaticTarde;
        private System.Windows.Forms.Label lblStaticNoite;
        private System.Windows.Forms.Panel panelSeparator;
    }
}