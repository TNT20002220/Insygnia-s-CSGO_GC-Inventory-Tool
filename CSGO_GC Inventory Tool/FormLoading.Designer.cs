namespace CSGO_GC_Inventory_Tool
{
    partial class FormLoading
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
            labelStatus = new Label();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(12, 9);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(72, 20);
            labelStatus.TabIndex = 0;
            labelStatus.Text = "Loading...";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 32);
            progressBar1.Maximum = 8;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(219, 10);
            progressBar1.TabIndex = 1;
            // 
            // FormLoading
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(243, 53);
            ControlBox = false;
            Controls.Add(progressBar1);
            Controls.Add(labelStatus);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormLoading";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loading Item Creator";
            TopMost = true;
            Load += FormLoading_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelStatus;
        private ProgressBar progressBar1;
    }
}