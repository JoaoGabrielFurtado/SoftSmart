namespace Softcase.Desktop
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            Grp_Infos = new GroupBox();
            Lbl_Informacoes = new Label();
            Cbx_Evento = new CheckBox();
            Lbl_Prever = new Label();
            Cbx_Prever = new ComboBox();
            Lbl_Cidade = new Label();
            Cbx_Cidade = new ComboBox();
            Btn_VerificaIA = new Button();
            Grp_Infos.SuspendLayout();
            SuspendLayout();
            // 
            // Grp_Infos
            // 
            Grp_Infos.Controls.Add(Lbl_Informacoes);
            Grp_Infos.Controls.Add(Cbx_Evento);
            Grp_Infos.Controls.Add(Lbl_Prever);
            Grp_Infos.Controls.Add(Cbx_Prever);
            Grp_Infos.Controls.Add(Lbl_Cidade);
            Grp_Infos.Controls.Add(Cbx_Cidade);
            Grp_Infos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Grp_Infos.Location = new Point(12, 16);
            Grp_Infos.Margin = new Padding(3, 2, 3, 2);
            Grp_Infos.Name = "Grp_Infos";
            Grp_Infos.Padding = new Padding(3, 2, 3, 2);
            Grp_Infos.Size = new Size(231, 207);
            Grp_Infos.TabIndex = 8;
            Grp_Infos.TabStop = false;
            Grp_Infos.Text = "Informações";
            // 
            // Lbl_Informacoes
            // 
            Lbl_Informacoes.AutoSize = true;
            Lbl_Informacoes.Cursor = Cursors.Hand;
            Lbl_Informacoes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Lbl_Informacoes.Location = new Point(153, 169);
            Lbl_Informacoes.Name = "Lbl_Informacoes";
            Lbl_Informacoes.Size = new Size(25, 21);
            Lbl_Informacoes.TabIndex = 16;
            Lbl_Informacoes.Text = "ⓘ";
            Lbl_Informacoes.Click += Lbl_Informacoes_Click;
            // 
            // Cbx_Evento
            // 
            Cbx_Evento.AutoSize = true;
            Cbx_Evento.Font = new Font("Segoe UI", 9F);
            Cbx_Evento.Location = new Point(56, 173);
            Cbx_Evento.Margin = new Padding(3, 2, 3, 2);
            Cbx_Evento.Name = "Cbx_Evento";
            Cbx_Evento.Size = new Size(93, 19);
            Cbx_Evento.TabIndex = 15;
            Cbx_Evento.Text = "Tem Evento?";
            Cbx_Evento.UseVisualStyleBackColor = true;
            Cbx_Evento.CheckedChanged += Cbx_Evento_CheckedChanged;
            // 
            // Lbl_Prever
            // 
            Lbl_Prever.AutoSize = true;
            Lbl_Prever.Font = new Font("Segoe UI", 9F);
            Lbl_Prever.Location = new Point(56, 33);
            Lbl_Prever.Name = "Lbl_Prever";
            Lbl_Prever.Size = new Size(115, 15);
            Lbl_Prever.TabIndex = 13;
            Lbl_Prever.Text = "Prever quantos dias?";
            // 
            // Cbx_Prever
            // 
            Cbx_Prever.FormattingEnabled = true;
            Cbx_Prever.Location = new Point(56, 50);
            Cbx_Prever.Margin = new Padding(3, 2, 3, 2);
            Cbx_Prever.Name = "Cbx_Prever";
            Cbx_Prever.Size = new Size(121, 23);
            Cbx_Prever.TabIndex = 14;
            // 
            // Lbl_Cidade
            // 
            Lbl_Cidade.AutoSize = true;
            Lbl_Cidade.Font = new Font("Segoe UI", 9F);
            Lbl_Cidade.Location = new Point(56, 96);
            Lbl_Cidade.Name = "Lbl_Cidade";
            Lbl_Cidade.Size = new Size(44, 15);
            Lbl_Cidade.TabIndex = 11;
            Lbl_Cidade.Text = "Cidade";
            // 
            // Cbx_Cidade
            // 
            Cbx_Cidade.FormattingEnabled = true;
            Cbx_Cidade.Location = new Point(56, 113);
            Cbx_Cidade.Margin = new Padding(3, 2, 3, 2);
            Cbx_Cidade.Name = "Cbx_Cidade";
            Cbx_Cidade.Size = new Size(121, 23);
            Cbx_Cidade.TabIndex = 12;
            // 
            // Btn_VerificaIA
            // 
            Btn_VerificaIA.BackColor = Color.DodgerBlue;
            Btn_VerificaIA.Cursor = Cursors.Hand;
            Btn_VerificaIA.Font = new Font("Segoe UI Emoji", 9F);
            Btn_VerificaIA.ForeColor = Color.Transparent;
            Btn_VerificaIA.Location = new Point(68, 239);
            Btn_VerificaIA.Name = "Btn_VerificaIA";
            Btn_VerificaIA.Size = new Size(115, 32);
            Btn_VerificaIA.TabIndex = 10;
            Btn_VerificaIA.Text = "Verificar IA";
            Btn_VerificaIA.UseVisualStyleBackColor = false;
            Btn_VerificaIA.Click += Btn_VerificaIA_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 304);
            Controls.Add(Btn_VerificaIA);
            Controls.Add(Grp_Infos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoftSmart";
            Grp_Infos.ResumeLayout(false);
            Grp_Infos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox Grp_Infos;
        private Button Btn_VerificaIA;
        private Label Lbl_Cidade;
        private ComboBox Cbx_Cidade;
        private Label Lbl_Prever;
        private ComboBox Cbx_Prever;
        private Label Lbl_Informacoes;
        private CheckBox Cbx_Evento;
    }
}
