namespace Softcase.Desktop.Forms
{
    partial class FormDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDashboard));
            flp_Galeria = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flp_Galeria
            // 
            flp_Galeria.AutoScroll = true;
            flp_Galeria.Dock = DockStyle.Fill;
            flp_Galeria.Location = new Point(0, 0);
            flp_Galeria.Name = "flp_Galeria";
            flp_Galeria.Size = new Size(312, 352);
            flp_Galeria.TabIndex = 0;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 352);
            Controls.Add(flp_Galeria);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Previsão";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flp_Galeria;
    }
}