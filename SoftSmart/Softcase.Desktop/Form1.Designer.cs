namespace Softcase.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Lbl_Horario = new Label();
            Trb_Horario = new TrackBar();
            Lbl_Dia = new Label();
            comboBox1 = new ComboBox();
            Lbl_Temperatura = new Label();
            Trb_Temperatura = new TrackBar();
            Ckb_Chuva = new CheckBox();
            Ckb_Evento = new CheckBox();
            Grp_Infos = new GroupBox();
            Grp_Ocupacao = new GroupBox();
            Lbl_Ocupacao = new Label();
            Lbl_MarcaTemp = new Label();
            Lbl_MarcaHora = new Label();
            ((System.ComponentModel.ISupportInitialize)Trb_Horario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Trb_Temperatura).BeginInit();
            Grp_Infos.SuspendLayout();
            Grp_Ocupacao.SuspendLayout();
            SuspendLayout();
            // 
            // Lbl_Horario
            // 
            Lbl_Horario.AutoSize = true;
            Lbl_Horario.Location = new Point(18, 33);
            Lbl_Horario.Name = "Lbl_Horario";
            Lbl_Horario.Size = new Size(60, 20);
            Lbl_Horario.TabIndex = 0;
            Lbl_Horario.Text = "Horário";
            // 
            // Trb_Horario
            // 
            Trb_Horario.Location = new Point(18, 56);
            Trb_Horario.Maximum = 23;
            Trb_Horario.Name = "Trb_Horario";
            Trb_Horario.Size = new Size(219, 56);
            Trb_Horario.TabIndex = 1;
            // 
            // Lbl_Dia
            // 
            Lbl_Dia.AutoSize = true;
            Lbl_Dia.Location = new Point(18, 133);
            Lbl_Dia.Name = "Lbl_Dia";
            Lbl_Dia.Size = new Size(108, 20);
            Lbl_Dia.TabIndex = 2;
            Lbl_Dia.Text = "Dia da semana";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(22, 156);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(215, 28);
            comboBox1.TabIndex = 3;
            // 
            // Lbl_Temperatura
            // 
            Lbl_Temperatura.AutoSize = true;
            Lbl_Temperatura.Location = new Point(18, 212);
            Lbl_Temperatura.Name = "Lbl_Temperatura";
            Lbl_Temperatura.Size = new Size(93, 20);
            Lbl_Temperatura.TabIndex = 4;
            Lbl_Temperatura.Text = "Temperatura";
            // 
            // Trb_Temperatura
            // 
            Trb_Temperatura.Location = new Point(18, 235);
            Trb_Temperatura.Maximum = 45;
            Trb_Temperatura.Minimum = -10;
            Trb_Temperatura.Name = "Trb_Temperatura";
            Trb_Temperatura.Size = new Size(219, 56);
            Trb_Temperatura.TabIndex = 5;
            Trb_Temperatura.TickFrequency = 5;
            Trb_Temperatura.Value = 10;
            // 
            // Ckb_Chuva
            // 
            Ckb_Chuva.AutoSize = true;
            Ckb_Chuva.Location = new Point(22, 313);
            Ckb_Chuva.Name = "Ckb_Chuva";
            Ckb_Chuva.Size = new Size(134, 24);
            Ckb_Chuva.TabIndex = 6;
            Ckb_Chuva.Text = "Está chovendo?";
            Ckb_Chuva.UseVisualStyleBackColor = true;
            // 
            // Ckb_Evento
            // 
            Ckb_Evento.AutoSize = true;
            Ckb_Evento.Location = new Point(22, 343);
            Ckb_Evento.Name = "Ckb_Evento";
            Ckb_Evento.Size = new Size(150, 24);
            Ckb_Evento.TabIndex = 7;
            Ckb_Evento.Text = "Evento na região?";
            Ckb_Evento.UseVisualStyleBackColor = true;
            // 
            // Grp_Infos
            // 
            Grp_Infos.Controls.Add(Lbl_MarcaHora);
            Grp_Infos.Controls.Add(Lbl_MarcaTemp);
            Grp_Infos.Controls.Add(Lbl_Horario);
            Grp_Infos.Controls.Add(Ckb_Evento);
            Grp_Infos.Controls.Add(Trb_Horario);
            Grp_Infos.Controls.Add(Ckb_Chuva);
            Grp_Infos.Controls.Add(Lbl_Dia);
            Grp_Infos.Controls.Add(Trb_Temperatura);
            Grp_Infos.Controls.Add(comboBox1);
            Grp_Infos.Controls.Add(Lbl_Temperatura);
            Grp_Infos.Location = new Point(29, 31);
            Grp_Infos.Name = "Grp_Infos";
            Grp_Infos.Size = new Size(257, 403);
            Grp_Infos.TabIndex = 8;
            Grp_Infos.TabStop = false;
            Grp_Infos.Text = "Informações";
            // 
            // Grp_Ocupacao
            // 
            Grp_Ocupacao.Controls.Add(Lbl_Ocupacao);
            Grp_Ocupacao.Location = new Point(307, 136);
            Grp_Ocupacao.Name = "Grp_Ocupacao";
            Grp_Ocupacao.Size = new Size(202, 158);
            Grp_Ocupacao.TabIndex = 9;
            Grp_Ocupacao.TabStop = false;
            Grp_Ocupacao.Text = "Ocupação";
            // 
            // Lbl_Ocupacao
            // 
            Lbl_Ocupacao.AutoSize = true;
            Lbl_Ocupacao.Location = new Point(94, 70);
            Lbl_Ocupacao.Name = "Lbl_Ocupacao";
            Lbl_Ocupacao.Size = new Size(13, 20);
            Lbl_Ocupacao.TabIndex = 0;
            Lbl_Ocupacao.Text = "!";
            // 
            // Lbl_MarcaTemp
            // 
            Lbl_MarcaTemp.AutoSize = true;
            Lbl_MarcaTemp.Location = new Point(96, 271);
            Lbl_MarcaTemp.Name = "Lbl_MarcaTemp";
            Lbl_MarcaTemp.Size = new Size(46, 20);
            Lbl_MarcaTemp.TabIndex = 8;
            Lbl_MarcaTemp.Text = "Temp";
            // 
            // Lbl_MarcaHora
            // 
            Lbl_MarcaHora.AutoSize = true;
            Lbl_MarcaHora.Location = new Point(96, 92);
            Lbl_MarcaHora.Name = "Lbl_MarcaHora";
            Lbl_MarcaHora.Size = new Size(42, 20);
            Lbl_MarcaHora.TabIndex = 9;
            Lbl_MarcaHora.Text = "Hora";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 470);
            Controls.Add(Grp_Ocupacao);
            Controls.Add(Grp_Infos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "SoftSmart";
            ((System.ComponentModel.ISupportInitialize)Trb_Horario).EndInit();
            ((System.ComponentModel.ISupportInitialize)Trb_Temperatura).EndInit();
            Grp_Infos.ResumeLayout(false);
            Grp_Infos.PerformLayout();
            Grp_Ocupacao.ResumeLayout(false);
            Grp_Ocupacao.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label Lbl_Horario;
        private TrackBar Trb_Horario;
        private Label Lbl_Dia;
        private ComboBox comboBox1;
        private Label Lbl_Temperatura;
        private TrackBar Trb_Temperatura;
        private CheckBox Ckb_Chuva;
        private CheckBox Ckb_Evento;
        private GroupBox Grp_Infos;
        private GroupBox Grp_Ocupacao;
        private Label Lbl_Ocupacao;
        private Label Lbl_MarcaHora;
        private Label Lbl_MarcaTemp;
    }
}
