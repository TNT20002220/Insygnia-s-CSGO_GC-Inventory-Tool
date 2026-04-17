using CSGO_GC_Inventory_Tool.Classes;
using System.Text.Json;
using System.Windows.Forms;

namespace CSGO_GC_Inventory_Tool
{
    public partial class Form1 : Form
    {
        List<Item> filteredItems = new List<Item>();
        InventoryHandler inventoryHandler = new InventoryHandler();

        public List<Item> FilteredItems => filteredItems;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MusicMap.Load(@"items\music_kits_min.json");
            GraffitiMap.Load(@"items\graffiti_min.json");
            PatchMap.Load(@"items\patches_min.json");
            CollectibleMap.Load(@"items\collectibles_min.json");
            StickerMap.Load(@"items\stickers_min.json");
            KeyMap.Load(@"items\keys_min.json");
            FinishMap.Load(@"items\finishes_min.json");
            AgentMap.Load(@"items\agents_min.json");
            CrateMap.Load(@"items\crates_min.json");
            listBoxItems.DrawItem += listBoxItems_DrawItem;
        }

        private void listBoxItems_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var item = (Item)listBoxItems.Items[e.Index];

            // 1. Draw background (default)
            e.DrawBackground();

            // 2. Handle selection highlight (OVERRIDE background if selected)
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            if (isSelected)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }

            // 3. Determine rarity color
            Color rarityColor = GetRarityColor(item.Rarity);

            // 4. Draw colored bar
            var barRect = new Rectangle(e.Bounds.Left, e.Bounds.Top, 5, e.Bounds.Height);
            using (var brush = new SolidBrush(rarityColor))
            {
                e.Graphics.FillRectangle(brush, barRect);
            }

            // 5. Choose correct text color depending on selection
            Brush textBrush = isSelected
                ? SystemBrushes.HighlightText
                : new SolidBrush(e.ForeColor);

            // 6. Draw text
            var textRect = new Rectangle(e.Bounds.Left + 8, e.Bounds.Top, e.Bounds.Width - 8, e.Bounds.Height);
            e.Graphics.DrawString(item.ToString(), e.Font, textBrush, textRect);

            // 7. Focus rectangle (dotted outline)
            e.DrawFocusRectangle();
        }

        private Color GetRarityColor(int rarity)
        {
            return rarity switch
            {
                0 => Color.Gray,
                1 => Color.LightGray,
                2 => Color.LightBlue,
                3 => Color.Blue,
                4 => Color.RebeccaPurple,
                5 => Color.Magenta,
                6 => Color.Red,
                7 => Color.Orange,
                99 => Color.Cyan,
                _ => Color.Gray
            };
        }

        private void buttonSelectInv_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select inventory file";
                dialog.Filter = "Text files (*.txt)|*.txt";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    inventoryHandler.SetInventoryPath(dialog.FileName);
                    int items = inventoryHandler.ParseInventoryFile();
                    if (inventoryHandler.Exists)
                    {
                        ApplyFilter("");
                        UpdateItemList();
                        this.BeginInvoke(new Action(() =>
                        {
                            textBoxSearchItems.Enabled = true;
                            listBoxItems.Enabled = true;
                            buttonRemoveDupes.Enabled = true;
                            buttonNormalize.Enabled = true;
                            buttonAddCases.Enabled = true;
                            buttonDelete.Enabled = true;
                            buttonDuplicate.Enabled = true;
                            buttonCopy.Enabled = true;
                            buttonModify.Enabled = true;
                            buttonAddItem.Enabled = true;
                            buttonBulkDelete.Enabled = true;
                            MessageBox.Show($"Successfully loaded {items} items");
                        }));
                    }
                }
            }
        }

        public void UpdateItemList()
        {
            this.BeginInvoke(new Action(() =>
            {
                listBoxItems.DataSource = null;
                listBoxItems.DataSource = filteredItems;
                listBoxItems.DisplayMember = Name;
                labelHighInvId.Text = $"Highest Inventory Index: {inventoryHandler.HighestInvId}";
                labelHighItemId.Text = $"Highest Item Index: {inventoryHandler.HighestItemId}";
                labelItems.Text = $"Items in Inventory: {inventoryHandler.Items.Count()}";
            }));
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (filteredItems.Count() > 0 && listBoxItems.SelectedItem != null)
                {
                    labelSelectedItemName.Text = filteredItems[listBoxItems.SelectedIndex].ToString();
                    labelSelectedInventoryId.Text = $"Inventory Index: {filteredItems[listBoxItems.SelectedIndex].InvId}";
                    labelSelectedItemId.Text = $"Item Index: {filteredItems[listBoxItems.SelectedIndex].ItemId}";
                    labelSelectedDefIndex.Text = $"def_index: {filteredItems[listBoxItems.SelectedIndex].DefIndex}";
                    labelSelectedQuality.Text = $"Quality: {filteredItems[listBoxItems.SelectedIndex].Quality}";
                    labelSelectedRarity.Text = $"Rarity: {filteredItems[listBoxItems.SelectedIndex].Rarity}";
                    labelSelectedFinish.Text = $"Finish Catalog: {filteredItems[listBoxItems.SelectedIndex].PaintId}";
                    labelSelectedPattern.Text = $"Pattern Index: {filteredItems[listBoxItems.SelectedIndex].Pattern}";
                    labelSelectedWear.Text = $"Wear: {filteredItems[listBoxItems.SelectedIndex].Wear}";
                    if (filteredItems[listBoxItems.SelectedIndex].CustomName != null) labelSelectedCustomName.Text = $"Name: {filteredItems[listBoxItems.SelectedIndex].CustomName}";
                    else labelSelectedCustomName.Text = "Name:";
                    labelSticker1.Text = $"Sticker/Patch/Graffiti Index: {filteredItems[listBoxItems.SelectedIndex].StickerId}";
                    labelSticker2.Text = $"Sticker/Patch 2 Index: {filteredItems[listBoxItems.SelectedIndex].Sticker2Id}";
                    labelSticker3.Text = $"Sticker/Patch 3 Index: {filteredItems[listBoxItems.SelectedIndex].Sticker3Id}";
                    labelSticker4.Text = $"Sticker/Patch 4 Index: {filteredItems[listBoxItems.SelectedIndex].Sticker4Id}";
                    labelGraffitiColor.Text = $"Graffiti Color Index: {filteredItems[listBoxItems.SelectedIndex].GraffitiColor}";
                    //MessageBox.Show(string.Join(",", filteredItems[listBoxItems.SelectedIndex].EquippedState));
                }
            }));
        }

        private void textBoxSearchItems_TextChanged(object sender, EventArgs e)
        {
            listBoxItems.ClearSelected();
            ApplyFilter(textBoxSearchItems.Text);
            UpdateItemList();
        }

        public void ApplyFilter(string query)
        {
            filteredItems.Clear();

            foreach (var item in inventoryHandler.Items)
            {
                if (item.ToString().IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    filteredItems.Add(item);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedIndex < 0)
            {
                MessageBox.Show("No item selected");
                return;
            }
            DialogResult dialog = MessageBox.Show($"Are you sure you want to delete {filteredItems[listBoxItems.SelectedIndex].ToString()}?", "Are you sure?", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                inventoryHandler.Delete(filteredItems[listBoxItems.SelectedIndex]);
            }
            ApplyFilter(textBoxSearchItems.Text);
            UpdateItemList();
        }

        private void buttonAddCases_Click(object sender, EventArgs e)
        {
            FormItemAdd formItemAdd = new FormItemAdd(inventoryHandler, this);
            formItemAdd.ShowDialog();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedIndex < 0)
            {
                MessageBox.Show("No item selected");
                return;
            }
            MessageBox.Show(filteredItems[listBoxItems.SelectedIndex].Write(filteredItems[listBoxItems.SelectedIndex].InvId));
        }

        private void buttonNormalize_Click(object sender, EventArgs e)
        {
            inventoryHandler.WriteNormalizedInventory();
            ApplyFilter(textBoxSearchItems.Text);
            UpdateItemList();
        }

        private void buttonDuplicate_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedIndex < 0)
            {
                MessageBox.Show("No item selected");
                return;
            }
            inventoryHandler.DuplicateItem(filteredItems[listBoxItems.SelectedIndex]);
            ApplyFilter(textBoxSearchItems.Text);
            UpdateItemList();
        }

        private void buttonCreateInv_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Create empty inventory?", "Are you sure?", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                inventoryHandler.CreateEmptyInventory();
                if (inventoryHandler.Exists)
                {
                    ApplyFilter("");
                    UpdateItemList();
                    if (inventoryHandler.HighestItemId != inventoryHandler.HighestInvId || inventoryHandler.HighestInvId != inventoryHandler.Items.Count() || inventoryHandler.HighestItemId != inventoryHandler.Items.Count()) MessageBox.Show("Item indexes don't match. It is recommended to normalize the inventory");
                    this.BeginInvoke(new Action(() =>
                    {
                        textBoxSearchItems.Enabled = true;
                        listBoxItems.Enabled = true;
                        buttonRemoveDupes.Enabled = true;
                        buttonNormalize.Enabled = true;
                        buttonAddCases.Enabled = true;
                        buttonDelete.Enabled = true;
                        buttonDuplicate.Enabled = true;
                        buttonCopy.Enabled = true;
                        buttonModify.Enabled = true;
                        buttonAddItem.Enabled = true;
                        buttonBulkDelete.Enabled = true;
                    }));
                }
            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedIndex < 0)
            {
                MessageBox.Show("No item selected");
                return;
            }
            FormItemEdit formItemEdit = new FormItemEdit(this, inventoryHandler, filteredItems[listBoxItems.SelectedIndex]);
            formItemEdit.ShowDialog();
        }

        private void buttonRemoveDupes_Click(object sender, EventArgs e)
        {
            inventoryHandler.RemoveDupes();
            ApplyFilter("");
            UpdateItemList();
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            FormItemCreator formItemCreator = new FormItemCreator(inventoryHandler, this);
            formItemCreator.ShowDialog();
        }

        private void buttonBulkDelete_Click(object sender, EventArgs e)
        {
            inventoryHandler.RemoveBulk((Item)listBoxItems.SelectedItem);
            ApplyFilter("");
            UpdateItemList();
        }
    }
}
