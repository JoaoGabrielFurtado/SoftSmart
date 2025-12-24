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
            Dgv_Infos = new DataGridView();
            Grp_Infos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv_Infos).BeginInit();
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
            Grp_Infos.Location = new Point(29, 31);
            Grp_Infos.Name = "Grp_Infos";
            Grp_Infos.Size = new Size(381, 162);
            Grp_Infos.TabIndex = 8;
            Grp_Infos.TabStop = false;
            Grp_Infos.Text = "Informações";
            // 
            // Lbl_Informacoes
            // 
            Lbl_Informacoes.AutoSize = true;
            Lbl_Informacoes.Cursor = Cursors.Hand;
            Lbl_Informacoes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Lbl_Informacoes.Location = new Point(137, 110);
            Lbl_Informacoes.Name = "Lbl_Informacoes";
            Lbl_Informacoes.Size = new Size(30, 28);
            Lbl_Informacoes.TabIndex = 16;
            Lbl_Informacoes.Text = "ⓘ";
            Lbl_Informacoes.Click += Lbl_Informacoes_Click;
            // 
            // Cbx_Evento
            // 
            Cbx_Evento.AutoSize = true;
            Cbx_Evento.Font = new Font("Segoe UI", 9F);
            Cbx_Evento.Location = new Point(26, 114);
            Cbx_Evento.Name = "Cbx_Evento";
            Cbx_Evento.Size = new Size(115, 24);
            Cbx_Evento.TabIndex = 15;
            Cbx_Evento.Text = "Tem Evento?";
            Cbx_Evento.UseVisualStyleBackColor = true;
            Cbx_Evento.CheckedChanged += Cbx_Evento_CheckedChanged;
            // 
            // Lbl_Prever
            // 
            Lbl_Prever.AutoSize = true;
            Lbl_Prever.Font = new Font("Segoe UI", 9F);
            Lbl_Prever.Location = new Point(26, 41);
            Lbl_Prever.Name = "Lbl_Prever";
            Lbl_Prever.Size = new Size(145, 20);
            Lbl_Prever.TabIndex = 13;
            Lbl_Prever.Text = "Prever quantos dias?";
            // 
            // Cbx_Prever
            // 
            Cbx_Prever.FormattingEnabled = true;
            Cbx_Prever.Location = new Point(26, 64);
            Cbx_Prever.Name = "Cbx_Prever";
            Cbx_Prever.Size = new Size(138, 28);
            Cbx_Prever.TabIndex = 14;
            // 
            // Lbl_Cidade
            // 
            Lbl_Cidade.AutoSize = true;
            Lbl_Cidade.Font = new Font("Segoe UI", 9F);
            Lbl_Cidade.Location = new Point(218, 41);
            Lbl_Cidade.Name = "Lbl_Cidade";
            Lbl_Cidade.Size = new Size(56, 20);
            Lbl_Cidade.TabIndex = 11;
            Lbl_Cidade.Text = "Cidade";
            // 
            // Cbx_Cidade
            // 
            Cbx_Cidade.FormattingEnabled = true;
            Cbx_Cidade.Location = new Point(218, 64);
            Cbx_Cidade.Name = "Cbx_Cidade";
            Cbx_Cidade.Size = new Size(138, 28);
            Cbx_Cidade.TabIndex = 12;
            // 
            // Btn_VerificaIA
            // 
            Btn_VerificaIA.BackColor = Color.DodgerBlue;
            Btn_VerificaIA.Cursor = Cursors.Hand;
            Btn_VerificaIA.Font = new Font("Segoe UI Emoji", 9F);
            Btn_VerificaIA.ForeColor = Color.Transparent;
            Btn_VerificaIA.Location = new Point(166, 209);
            Btn_VerificaIA.Margin = new Padding(3, 4, 3, 4);
            Btn_VerificaIA.Name = "Btn_VerificaIA";
            Btn_VerificaIA.Size = new Size(120, 43);
            Btn_VerificaIA.TabIndex = 10;
            Btn_VerificaIA.Text = "Verificar IA";
            Btn_VerificaIA.UseVisualStyleBackColor = false;
            Btn_VerificaIA.Click += Btn_VerificaIA_Click;
            // 
            // Dgv_Infos
            // 
            Dgv_Infos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Infos.Location = new Point(437, 45);
            Dgv_Infos.Margin = new Padding(3, 4, 3, 4);
            Dgv_Infos.Name = "Dgv_Infos";
            Dgv_Infos.RowHeadersWidth = 51;
            Dgv_Infos.Size = new Size(503, 172);
            Dgv_Infos.TabIndex = 11;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 265);
            Controls.Add(Dgv_Infos);
            Controls.Add(Btn_VerificaIA);
            Controls.Add(Grp_Infos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoftSmart";
            Grp_Infos.ResumeLayout(false);
            Grp_Infos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv_Infos).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox Grp_Infos;
        private Button Btn_VerificaIA;
        private Label Lbl_Cidade;
        private ComboBox Cbx_Cidade;
        private Label Lbl_Prever;
        private ComboBox Cbx_Prever;
        private DataGridView Dgv_Infos;
        private Label Lbl_Informacoes;
        private CheckBox Cbx_Evento;
    }
}
