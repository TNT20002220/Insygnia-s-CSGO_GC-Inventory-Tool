namespace CSGO_GC_Inventory_Tool
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
            listBoxItems = new ListBox();
            buttonSelectInv = new Button();
            buttonRemoveDupes = new Button();
            buttonNormalize = new Button();
            groupBoxItemTools = new GroupBox();
            labelGraffitiColor = new Label();
            labelSticker4 = new Label();
            labelSticker3 = new Label();
            labelSticker2 = new Label();
            labelSticker1 = new Label();
            labelSelectedCustomName = new Label();
            buttonModify = new Button();
            buttonCopy = new Button();
            buttonDuplicate = new Button();
            buttonDelete = new Button();
            labelSelectedWear = new Label();
            labelSelectedPattern = new Label();
            labelSelectedFinish = new Label();
            labelSelectedRarity = new Label();
            labelSelectedQuality = new Label();
            labelSelectedDefIndex = new Label();
            labelSelectedInventoryId = new Label();
            labelSelectedItemId = new Label();
            labelSelectedItemName = new Label();
            labelHighInvId = new Label();
            labelHighItemId = new Label();
            textBoxSearchItems = new TextBox();
            labelItems = new Label();
            labelSearch = new Label();
            buttonAddCases = new Button();
            buttonCreateInv = new Button();
            buttonAddItem = new Button();
            groupBoxItemTools.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxItems
            // 
            listBoxItems.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxItems.Enabled = false;
            listBoxItems.FormattingEnabled = true;
            listBoxItems.Location = new Point(12, 52);
            listBoxItems.Name = "listBoxItems";
            listBoxItems.Size = new Size(248, 384);
            listBoxItems.TabIndex = 0;
            listBoxItems.SelectedIndexChanged += listBoxItems_SelectedIndexChanged;
            // 
            // buttonSelectInv
            // 
            buttonSelectInv.Location = new Point(371, 12);
            buttonSelectInv.Name = "buttonSelectInv";
            buttonSelectInv.Size = new Size(100, 54);
            buttonSelectInv.TabIndex = 1;
            buttonSelectInv.Text = "Modify Inventory";
            buttonSelectInv.UseVisualStyleBackColor = true;
            buttonSelectInv.Click += buttonSelectInv_Click;
            // 
            // buttonRemoveDupes
            // 
            buttonRemoveDupes.Enabled = false;
            buttonRemoveDupes.Location = new Point(477, 12);
            buttonRemoveDupes.Name = "buttonRemoveDupes";
            buttonRemoveDupes.Size = new Size(138, 54);
            buttonRemoveDupes.TabIndex = 2;
            buttonRemoveDupes.Text = "Remove Duplicate Skins";
            buttonRemoveDupes.UseVisualStyleBackColor = true;
            buttonRemoveDupes.Click += buttonRemoveDupes_Click;
            // 
            // buttonNormalize
            // 
            buttonNormalize.Enabled = false;
            buttonNormalize.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            buttonNormalize.Location = new Point(621, 72);
            buttonNormalize.Name = "buttonNormalize";
            buttonNormalize.Size = new Size(211, 57);
            buttonNormalize.TabIndex = 3;
            buttonNormalize.Text = "Save Inventory";
            buttonNormalize.UseVisualStyleBackColor = true;
            buttonNormalize.Click += buttonNormalize_Click;
            // 
            // groupBoxItemTools
            // 
            groupBoxItemTools.Controls.Add(labelGraffitiColor);
            groupBoxItemTools.Controls.Add(labelSticker4);
            groupBoxItemTools.Controls.Add(labelSticker3);
            groupBoxItemTools.Controls.Add(labelSticker2);
            groupBoxItemTools.Controls.Add(labelSticker1);
            groupBoxItemTools.Controls.Add(labelSelectedCustomName);
            groupBoxItemTools.Controls.Add(buttonModify);
            groupBoxItemTools.Controls.Add(buttonCopy);
            groupBoxItemTools.Controls.Add(buttonDuplicate);
            groupBoxItemTools.Controls.Add(buttonDelete);
            groupBoxItemTools.Controls.Add(labelSelectedWear);
            groupBoxItemTools.Controls.Add(labelSelectedPattern);
            groupBoxItemTools.Controls.Add(labelSelectedFinish);
            groupBoxItemTools.Controls.Add(labelSelectedRarity);
            groupBoxItemTools.Controls.Add(labelSelectedQuality);
            groupBoxItemTools.Controls.Add(labelSelectedDefIndex);
            groupBoxItemTools.Controls.Add(labelSelectedInventoryId);
            groupBoxItemTools.Controls.Add(labelSelectedItemId);
            groupBoxItemTools.Controls.Add(labelSelectedItemName);
            groupBoxItemTools.Location = new Point(266, 132);
            groupBoxItemTools.Name = "groupBoxItemTools";
            groupBoxItemTools.Size = new Size(566, 304);
            groupBoxItemTools.TabIndex = 4;
            groupBoxItemTools.TabStop = false;
            groupBoxItemTools.Text = "Selected Item";
            // 
            // labelGraffitiColor
            // 
            labelGraffitiColor.AutoSize = true;
            labelGraffitiColor.Location = new Point(210, 151);
            labelGraffitiColor.Name = "labelGraffitiColor";
            labelGraffitiColor.Size = new Size(203, 20);
            labelGraffitiColor.TabIndex = 19;
            labelGraffitiColor.Text = "Graffiti Color Index: Unknown";
            // 
            // labelSticker4
            // 
            labelSticker4.AutoSize = true;
            labelSticker4.Location = new Point(210, 131);
            labelSticker4.Name = "labelSticker4";
            labelSticker4.Size = new Size(214, 20);
            labelSticker4.TabIndex = 18;
            labelSticker4.Text = "Sticker/Patch 4 Index: Unknown";
            // 
            // labelSticker3
            // 
            labelSticker3.AutoSize = true;
            labelSticker3.Location = new Point(210, 111);
            labelSticker3.Name = "labelSticker3";
            labelSticker3.Size = new Size(214, 20);
            labelSticker3.TabIndex = 17;
            labelSticker3.Text = "Sticker/Patch 3 Index: Unknown";
            // 
            // labelSticker2
            // 
            labelSticker2.AutoSize = true;
            labelSticker2.Location = new Point(210, 91);
            labelSticker2.Name = "labelSticker2";
            labelSticker2.Size = new Size(214, 20);
            labelSticker2.TabIndex = 16;
            labelSticker2.Text = "Sticker/Patch 2 Index: Unknown";
            // 
            // labelSticker1
            // 
            labelSticker1.AutoSize = true;
            labelSticker1.Location = new Point(210, 71);
            labelSticker1.Name = "labelSticker1";
            labelSticker1.Size = new Size(254, 20);
            labelSticker1.TabIndex = 15;
            labelSticker1.Text = "Sticker/Patch/Graffiti Index: Unknown";
            // 
            // labelSelectedCustomName
            // 
            labelSelectedCustomName.AutoSize = true;
            labelSelectedCustomName.Location = new Point(210, 48);
            labelSelectedCustomName.Name = "labelSelectedCustomName";
            labelSelectedCustomName.Size = new Size(52, 20);
            labelSelectedCustomName.TabIndex = 14;
            labelSelectedCustomName.Text = "Name:";
            // 
            // buttonModify
            // 
            buttonModify.Enabled = false;
            buttonModify.Location = new Point(419, 214);
            buttonModify.Name = "buttonModify";
            buttonModify.Size = new Size(141, 84);
            buttonModify.TabIndex = 13;
            buttonModify.Text = "Modify Item";
            buttonModify.UseVisualStyleBackColor = true;
            buttonModify.Click += buttonModify_Click;
            // 
            // buttonCopy
            // 
            buttonCopy.Enabled = false;
            buttonCopy.Location = new Point(204, 214);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(93, 84);
            buttonCopy.TabIndex = 12;
            buttonCopy.Text = "View Item Code";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // buttonDuplicate
            // 
            buttonDuplicate.Enabled = false;
            buttonDuplicate.Location = new Point(105, 214);
            buttonDuplicate.Name = "buttonDuplicate";
            buttonDuplicate.Size = new Size(93, 84);
            buttonDuplicate.TabIndex = 11;
            buttonDuplicate.Text = "Duplicate Item";
            buttonDuplicate.UseVisualStyleBackColor = true;
            buttonDuplicate.Click += buttonDuplicate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Enabled = false;
            buttonDelete.Location = new Point(6, 214);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(93, 84);
            buttonDelete.TabIndex = 10;
            buttonDelete.Text = "Delete Item";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // labelSelectedWear
            // 
            labelSelectedWear.AutoSize = true;
            labelSelectedWear.Location = new Point(6, 191);
            labelSelectedWear.Name = "labelSelectedWear";
            labelSelectedWear.Size = new Size(111, 20);
            labelSelectedWear.TabIndex = 8;
            labelSelectedWear.Text = "Wear: Unknown";
            // 
            // labelSelectedPattern
            // 
            labelSelectedPattern.AutoSize = true;
            labelSelectedPattern.Location = new Point(6, 171);
            labelSelectedPattern.Name = "labelSelectedPattern";
            labelSelectedPattern.Size = new Size(163, 20);
            labelSelectedPattern.TabIndex = 7;
            labelSelectedPattern.Text = "Pattern Index: Unknown";
            // 
            // labelSelectedFinish
            // 
            labelSelectedFinish.AutoSize = true;
            labelSelectedFinish.Location = new Point(6, 151);
            labelSelectedFinish.Name = "labelSelectedFinish";
            labelSelectedFinish.Size = new Size(168, 20);
            labelSelectedFinish.TabIndex = 6;
            labelSelectedFinish.Text = "Finish catalog: Unknown";
            // 
            // labelSelectedRarity
            // 
            labelSelectedRarity.AutoSize = true;
            labelSelectedRarity.Location = new Point(6, 131);
            labelSelectedRarity.Name = "labelSelectedRarity";
            labelSelectedRarity.Size = new Size(115, 20);
            labelSelectedRarity.TabIndex = 5;
            labelSelectedRarity.Text = "Rarity: Unknown";
            // 
            // labelSelectedQuality
            // 
            labelSelectedQuality.AutoSize = true;
            labelSelectedQuality.Location = new Point(6, 111);
            labelSelectedQuality.Name = "labelSelectedQuality";
            labelSelectedQuality.Size = new Size(124, 20);
            labelSelectedQuality.TabIndex = 4;
            labelSelectedQuality.Text = "Quality: Unknown";
            // 
            // labelSelectedDefIndex
            // 
            labelSelectedDefIndex.AutoSize = true;
            labelSelectedDefIndex.Location = new Point(6, 91);
            labelSelectedDefIndex.Name = "labelSelectedDefIndex";
            labelSelectedDefIndex.Size = new Size(141, 20);
            labelSelectedDefIndex.TabIndex = 3;
            labelSelectedDefIndex.Text = "def_index: Unknown";
            // 
            // labelSelectedInventoryId
            // 
            labelSelectedInventoryId.AutoSize = true;
            labelSelectedInventoryId.Location = new Point(6, 71);
            labelSelectedInventoryId.Name = "labelSelectedInventoryId";
            labelSelectedInventoryId.Size = new Size(178, 20);
            labelSelectedInventoryId.TabIndex = 2;
            labelSelectedInventoryId.Text = "Inventory Index: Unknown";
            // 
            // labelSelectedItemId
            // 
            labelSelectedItemId.AutoSize = true;
            labelSelectedItemId.Location = new Point(6, 51);
            labelSelectedItemId.Name = "labelSelectedItemId";
            labelSelectedItemId.Size = new Size(147, 20);
            labelSelectedItemId.TabIndex = 1;
            labelSelectedItemId.Text = "Item Index: Unknown";
            // 
            // labelSelectedItemName
            // 
            labelSelectedItemName.AutoSize = true;
            labelSelectedItemName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelSelectedItemName.Location = new Point(6, 23);
            labelSelectedItemName.Name = "labelSelectedItemName";
            labelSelectedItemName.Size = new Size(162, 28);
            labelSelectedItemName.TabIndex = 0;
            labelSelectedItemName.Text = "No Item Selected";
            // 
            // labelHighInvId
            // 
            labelHighInvId.AutoSize = true;
            labelHighInvId.Location = new Point(266, 69);
            labelHighInvId.Name = "labelHighInvId";
            labelHighInvId.Size = new Size(233, 20);
            labelHighInvId.TabIndex = 5;
            labelHighInvId.Text = "Highest Inventory Index: Unknown";
            // 
            // labelHighItemId
            // 
            labelHighItemId.AutoSize = true;
            labelHighItemId.Location = new Point(266, 89);
            labelHighItemId.Name = "labelHighItemId";
            labelHighItemId.Size = new Size(202, 20);
            labelHighItemId.TabIndex = 6;
            labelHighItemId.Text = "Highest Item Index: Unknown";
            // 
            // textBoxSearchItems
            // 
            textBoxSearchItems.Enabled = false;
            textBoxSearchItems.Location = new Point(74, 12);
            textBoxSearchItems.Name = "textBoxSearchItems";
            textBoxSearchItems.Size = new Size(186, 27);
            textBoxSearchItems.TabIndex = 7;
            textBoxSearchItems.TextChanged += textBoxSearchItems_TextChanged;
            // 
            // labelItems
            // 
            labelItems.AutoSize = true;
            labelItems.Location = new Point(266, 109);
            labelItems.Name = "labelItems";
            labelItems.Size = new Size(194, 20);
            labelItems.TabIndex = 8;
            labelItems.Text = "Items in Inventory: Unknown";
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(12, 15);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(56, 20);
            labelSearch.TabIndex = 9;
            labelSearch.Text = "Search:";
            // 
            // buttonAddCases
            // 
            buttonAddCases.Enabled = false;
            buttonAddCases.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonAddCases.Location = new Point(621, 12);
            buttonAddCases.Name = "buttonAddCases";
            buttonAddCases.Size = new Size(109, 54);
            buttonAddCases.TabIndex = 10;
            buttonAddCases.Text = "Add Cases";
            buttonAddCases.UseVisualStyleBackColor = true;
            buttonAddCases.Click += buttonAddCases_Click;
            // 
            // buttonCreateInv
            // 
            buttonCreateInv.Location = new Point(266, 12);
            buttonCreateInv.Name = "buttonCreateInv";
            buttonCreateInv.Size = new Size(99, 54);
            buttonCreateInv.TabIndex = 11;
            buttonCreateInv.Text = "New Inventory";
            buttonCreateInv.UseVisualStyleBackColor = true;
            buttonCreateInv.Click += buttonCreateInv_Click;
            // 
            // buttonAddItem
            // 
            buttonAddItem.Enabled = false;
            buttonAddItem.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonAddItem.Location = new Point(736, 12);
            buttonAddItem.Name = "buttonAddItem";
            buttonAddItem.Size = new Size(96, 54);
            buttonAddItem.TabIndex = 12;
            buttonAddItem.Text = "Add Item";
            buttonAddItem.UseVisualStyleBackColor = true;
            buttonAddItem.Click += buttonAddItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(844, 450);
            Controls.Add(buttonAddItem);
            Controls.Add(buttonCreateInv);
            Controls.Add(buttonAddCases);
            Controls.Add(labelSearch);
            Controls.Add(labelItems);
            Controls.Add(textBoxSearchItems);
            Controls.Add(labelHighItemId);
            Controls.Add(labelHighInvId);
            Controls.Add(groupBoxItemTools);
            Controls.Add(buttonNormalize);
            Controls.Add(buttonRemoveDupes);
            Controls.Add(buttonSelectInv);
            Controls.Add(listBoxItems);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Insygnia's CSGO_GC Inventory Tool 2.0";
            Load += Form1_Load;
            groupBoxItemTools.ResumeLayout(false);
            groupBoxItemTools.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxItems;
        private Button buttonSelectInv;
        private Button buttonRemoveDupes;
        private Button buttonNormalize;
        private GroupBox groupBoxItemTools;
        private Label labelSelectedItemName;
        private Label labelHighInvId;
        private Label labelHighItemId;
        private TextBox textBoxSearchItems;
        private Label labelSelectedItemId;
        private Label labelItems;
        private Label labelSelectedInventoryId;
        private Label labelSelectedDefIndex;
        private Label labelSelectedQuality;
        private Label labelSelectedRarity;
        private Label labelSelectedFinish;
        private Label labelSelectedPattern;
        private Label labelSelectedWear;
        private Label labelSearch;
        private Button buttonDuplicate;
        private Button buttonDelete;
        private Button buttonAddCases;
        private Button buttonCopy;
        private Button buttonModify;
        private Button buttonCreateInv;
        private Label labelSelectedCustomName;
        private Label labelSticker4;
        private Label labelSticker3;
        private Label labelSticker2;
        private Label labelSticker1;
        private Label labelGraffitiColor;
        private Button buttonAddItem;
    }
}
