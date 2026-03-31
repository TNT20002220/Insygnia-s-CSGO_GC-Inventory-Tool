namespace CSGO_GC_Inventory_Tool
{
    partial class FormItemAdd
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
            listBoxCases = new ListBox();
            labelNumberOf = new Label();
            numericUpDown1 = new NumericUpDown();
            buttonAdd = new Button();
            labelSearch = new Label();
            textBoxSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // listBoxCases
            // 
            listBoxCases.FormattingEnabled = true;
            listBoxCases.Location = new Point(12, 80);
            listBoxCases.Name = "listBoxCases";
            listBoxCases.Size = new Size(391, 304);
            listBoxCases.TabIndex = 0;
            // 
            // labelNumberOf
            // 
            labelNumberOf.AutoSize = true;
            labelNumberOf.Location = new Point(12, 9);
            labelNumberOf.Name = "labelNumberOf";
            labelNumberOf.Size = new Size(124, 20);
            labelNumberOf.TabIndex = 1;
            labelNumberOf.Text = "Number of Items:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(142, 7);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(95, 27);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonAdd.Location = new Point(255, 7);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(148, 27);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(12, 43);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(56, 20);
            labelSearch.TabIndex = 4;
            labelSearch.Text = "Search:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(74, 40);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(329, 27);
            textBoxSearch.TabIndex = 5;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // FormItemAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 398);
            Controls.Add(textBoxSearch);
            Controls.Add(labelSearch);
            Controls.Add(buttonAdd);
            Controls.Add(numericUpDown1);
            Controls.Add(labelNumberOf);
            Controls.Add(listBoxCases);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormItemAdd";
            Text = "Add Cases";
            Load += FormItemAdd_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxCases;
        private Label labelNumberOf;
        private NumericUpDown numericUpDown1;
        private Button buttonAdd;
        private Label labelSearch;
        private TextBox textBoxSearch;
    }
}