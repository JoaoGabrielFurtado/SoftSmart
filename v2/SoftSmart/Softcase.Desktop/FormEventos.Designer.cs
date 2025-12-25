namespace Softcase.Desktop
{
    partial class Eventos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eventos));
            Lbl_InfoEventos = new Label();
            Btn_ConcluirEventos = new Button();
            Flp_PainelDias = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // Lbl_InfoEventos
            // 
            Lbl_InfoEventos.AutoSize = true;
            Lbl_InfoEventos.BackColor = Color.DodgerBlue;
            Lbl_InfoEventos.BorderStyle = BorderStyle.FixedSingle;
            Lbl_InfoEventos.Font = new Font("Microsoft JhengHei", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_InfoEventos.ForeColor = SystemColors.ActiveCaptionText;
            Lbl_InfoEventos.Location = new Point(10, 7);
            Lbl_InfoEventos.Name = "Lbl_InfoEventos";
            Lbl_InfoEventos.Size = new Size(182, 52);
            Lbl_InfoEventos.TabIndex = 0;
            Lbl_InfoEventos.Text = "Confirme os dias\r\nque terão eventos\r\n";
            Lbl_InfoEventos.TextAlign = ContentAlignment.TopCenter;
            // 
            // Btn_ConcluirEventos
            // 
            Btn_ConcluirEventos.BackColor = Color.DodgerBlue;
            Btn_ConcluirEventos.ForeColor = SystemColors.ButtonFace;
            Btn_ConcluirEventos.Location = new Point(65, 200);
            Btn_ConcluirEventos.Margin = new Padding(3, 2, 3, 2);
            Btn_ConcluirEventos.Name = "Btn_ConcluirEventos";
            Btn_ConcluirEventos.Size = new Size(82, 22);
            Btn_ConcluirEventos.TabIndex = 1;
            Btn_ConcluirEventos.Text = "Concluir";
            Btn_ConcluirEventos.UseVisualStyleBackColor = false;
            Btn_ConcluirEventos.Click += Btn_ConcluirEventos_Click;
            // 
            // Flp_PainelDias
            // 
            Flp_PainelDias.AutoScroll = true;
            Flp_PainelDias.Location = new Point(58, 71);
            Flp_PainelDias.Margin = new Padding(3, 2, 3, 2);
            Flp_PainelDias.Name = "Flp_PainelDias";
            Flp_PainelDias.Size = new Size(122, 124);
            Flp_PainelDias.TabIndex = 2;
            // 
            // Eventos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(202, 230);
            Controls.Add(Flp_PainelDias);
            Controls.Add(Btn_ConcluirEventos);
            Controls.Add(Lbl_InfoEventos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Eventos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eventos";
            Load += FormEventos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lbl_InfoEventos;
        private Button Btn_ConcluirEventos;
        private FlowLayoutPanel Flp_PainelDias;
    }
}