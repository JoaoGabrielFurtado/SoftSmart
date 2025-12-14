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
            Cbx_DiasSemana = new ComboBox();
            Lbl_Temperatura = new Label();
            Trb_Temperatura = new TrackBar();
            Ckb_Chuva = new CheckBox();
            Ckb_Evento = new CheckBox();
            Grp_Infos = new GroupBox();
            Ckb_EhFeriado = new CheckBox();
            Lbl_MarcaHora = new Label();
            Lbl_MarcaTemp = new Label();
            Btn_VerificaIA = new Button();
            Lbl_Ocupacao = new Label();
            ((System.ComponentModel.ISupportInitialize)Trb_Horario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Trb_Temperatura).BeginInit();
            Grp_Infos.SuspendLayout();
            SuspendLayout();
            // 
            // Lbl_Horario
            // 
            Lbl_Horario.AutoSize = true;
            Lbl_Horario.Location = new Point(16, 25);
            Lbl_Horario.Name = "Lbl_Horario";
            Lbl_Horario.Size = new Size(47, 15);
            Lbl_Horario.TabIndex = 0;
            Lbl_Horario.Text = "Horário";
            // 
            // Trb_Horario
            // 
            Trb_Horario.Location = new Point(16, 42);
            Trb_Horario.Margin = new Padding(3, 2, 3, 2);
            Trb_Horario.Maximum = 23;
            Trb_Horario.Name = "Trb_Horario";
            Trb_Horario.Size = new Size(192, 45);
            Trb_Horario.TabIndex = 1;
            Trb_Horario.Scroll += Trb_Horario_Scroll;
            // 
            // Lbl_Dia
            // 
            Lbl_Dia.AutoSize = true;
            Lbl_Dia.Location = new Point(16, 100);
            Lbl_Dia.Name = "Lbl_Dia";
            Lbl_Dia.Size = new Size(84, 15);
            Lbl_Dia.TabIndex = 2;
            Lbl_Dia.Text = "Dia da semana";
            // 
            // Cbx_DiasSemana
            // 
            Cbx_DiasSemana.FormattingEnabled = true;
            Cbx_DiasSemana.Location = new Point(19, 117);
            Cbx_DiasSemana.Margin = new Padding(3, 2, 3, 2);
            Cbx_DiasSemana.Name = "Cbx_DiasSemana";
            Cbx_DiasSemana.Size = new Size(189, 23);
            Cbx_DiasSemana.TabIndex = 3;
            // 
            // Lbl_Temperatura
            // 
            Lbl_Temperatura.AutoSize = true;
            Lbl_Temperatura.Location = new Point(16, 159);
            Lbl_Temperatura.Name = "Lbl_Temperatura";
            Lbl_Temperatura.Size = new Size(74, 15);
            Lbl_Temperatura.TabIndex = 4;
            Lbl_Temperatura.Text = "Temperatura";
            // 
            // Trb_Temperatura
            // 
            Trb_Temperatura.Location = new Point(16, 176);
            Trb_Temperatura.Margin = new Padding(3, 2, 3, 2);
            Trb_Temperatura.Maximum = 45;
            Trb_Temperatura.Minimum = -10;
            Trb_Temperatura.Name = "Trb_Temperatura";
            Trb_Temperatura.Size = new Size(192, 45);
            Trb_Temperatura.TabIndex = 5;
            Trb_Temperatura.TickFrequency = 5;
            Trb_Temperatura.Value = 10;
            Trb_Temperatura.Scroll += Trb_Temperatura_Scroll;
            // 
            // Ckb_Chuva
            // 
            Ckb_Chuva.AutoSize = true;
            Ckb_Chuva.Location = new Point(19, 235);
            Ckb_Chuva.Margin = new Padding(3, 2, 3, 2);
            Ckb_Chuva.Name = "Ckb_Chuva";
            Ckb_Chuva.Size = new Size(108, 19);
            Ckb_Chuva.TabIndex = 6;
            Ckb_Chuva.Text = "Está chovendo?";
            Ckb_Chuva.UseVisualStyleBackColor = true;
            Ckb_Chuva.CheckedChanged += Ckb_Chuva_CheckedChanged;
            // 
            // Ckb_Evento
            // 
            Ckb_Evento.AutoSize = true;
            Ckb_Evento.Location = new Point(19, 257);
            Ckb_Evento.Margin = new Padding(3, 2, 3, 2);
            Ckb_Evento.Name = "Ckb_Evento";
            Ckb_Evento.Size = new Size(119, 19);
            Ckb_Evento.TabIndex = 7;
            Ckb_Evento.Text = "Evento na região?";
            Ckb_Evento.UseVisualStyleBackColor = true;
            Ckb_Evento.CheckedChanged += Ckb_Evento_CheckedChanged;
            // 
            // Grp_Infos
            // 
            Grp_Infos.Controls.Add(Ckb_EhFeriado);
            Grp_Infos.Controls.Add(Lbl_MarcaHora);
            Grp_Infos.Controls.Add(Lbl_MarcaTemp);
            Grp_Infos.Controls.Add(Lbl_Horario);
            Grp_Infos.Controls.Add(Ckb_Evento);
            Grp_Infos.Controls.Add(Trb_Horario);
            Grp_Infos.Controls.Add(Ckb_Chuva);
            Grp_Infos.Controls.Add(Lbl_Dia);
            Grp_Infos.Controls.Add(Trb_Temperatura);
            Grp_Infos.Controls.Add(Cbx_DiasSemana);
            Grp_Infos.Controls.Add(Lbl_Temperatura);
            Grp_Infos.Location = new Point(25, 23);
            Grp_Infos.Margin = new Padding(3, 2, 3, 2);
            Grp_Infos.Name = "Grp_Infos";
            Grp_Infos.Padding = new Padding(3, 2, 3, 2);
            Grp_Infos.Size = new Size(225, 302);
            Grp_Infos.TabIndex = 8;
            Grp_Infos.TabStop = false;
            Grp_Infos.Text = "Informações";
            // 
            // Ckb_EhFeriado
            // 
            Ckb_EhFeriado.AutoSize = true;
            Ckb_EhFeriado.Location = new Point(19, 279);
            Ckb_EhFeriado.Margin = new Padding(3, 2, 3, 2);
            Ckb_EhFeriado.Name = "Ckb_EhFeriado";
            Ckb_EhFeriado.Size = new Size(77, 19);
            Ckb_EhFeriado.TabIndex = 10;
            Ckb_EhFeriado.Text = "É feriado?";
            Ckb_EhFeriado.UseVisualStyleBackColor = true;
            Ckb_EhFeriado.CheckedChanged += Ckb_EhFeriado_CheckedChanged;
            // 
            // Lbl_MarcaHora
            // 
            Lbl_MarcaHora.AutoSize = true;
            Lbl_MarcaHora.Location = new Point(175, 25);
            Lbl_MarcaHora.Name = "Lbl_MarcaHora";
            Lbl_MarcaHora.Size = new Size(0, 15);
            Lbl_MarcaHora.TabIndex = 9;
            // 
            // Lbl_MarcaTemp
            // 
            Lbl_MarcaTemp.AutoSize = true;
            Lbl_MarcaTemp.Location = new Point(171, 159);
            Lbl_MarcaTemp.Name = "Lbl_MarcaTemp";
            Lbl_MarcaTemp.Size = new Size(0, 15);
            Lbl_MarcaTemp.TabIndex = 8;
            // 
            // Btn_VerificaIA
            // 
            Btn_VerificaIA.BackColor = Color.DodgerBlue;
            Btn_VerificaIA.Cursor = Cursors.Hand;
            Btn_VerificaIA.ForeColor = Color.Transparent;
            Btn_VerificaIA.Location = new Point(305, 280);
            Btn_VerificaIA.Name = "Btn_VerificaIA";
            Btn_VerificaIA.Size = new Size(105, 32);
            Btn_VerificaIA.TabIndex = 10;
            Btn_VerificaIA.Text = "Verificar IA";
            Btn_VerificaIA.UseVisualStyleBackColor = false;
            Btn_VerificaIA.Click += Btn_VerificaIA_Click;
            // 
            // Lbl_Ocupacao
            // 
            Lbl_Ocupacao.AutoSize = true;
            Lbl_Ocupacao.BorderStyle = BorderStyle.Fixed3D;
            Lbl_Ocupacao.Font = new Font("Segoe UI", 30F);
            Lbl_Ocupacao.ForeColor = Color.DodgerBlue;
            Lbl_Ocupacao.Location = new Point(325, 140);
            Lbl_Ocupacao.Name = "Lbl_Ocupacao";
            Lbl_Ocupacao.Size = new Size(65, 56);
            Lbl_Ocupacao.TabIndex = 0;
            Lbl_Ocupacao.Text = "ㅤ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 365);
            Controls.Add(Lbl_Ocupacao);
            Controls.Add(Btn_VerificaIA);
            Controls.Add(Grp_Infos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoftSmart";
            ((System.ComponentModel.ISupportInitialize)Trb_Horario).EndInit();
            ((System.ComponentModel.ISupportInitialize)Trb_Temperatura).EndInit();
            Grp_Infos.ResumeLayout(false);
            Grp_Infos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lbl_Horario;
        private TrackBar Trb_Horario;
        private Label Lbl_Dia;
        private ComboBox Cbx_DiasSemana;
        private Label Lbl_Temperatura;
        private TrackBar Trb_Temperatura;
        private CheckBox Ckb_Chuva;
        private CheckBox Ckb_Evento;
        private GroupBox Grp_Infos;
        private Label Lbl_MarcaHora;
        private Label Lbl_MarcaTemp;
        private Button Btn_VerificaIA;
        private CheckBox Ckb_EhFeriado;
        private Label Lbl_Ocupacao;
    }
}
