using CSGO_GC_Inventory_Tool.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSGO_GC_Inventory_Tool
{
    public partial class FormItemEdit : Form
    {
        Form1 form1;
        InventoryHandler inventoryHandler;
        Item selectedItem;
        public FormItemEdit(Form1 form1, InventoryHandler handler, Item item)
        {
            InitializeComponent();
            this.form1 = form1;
            this.inventoryHandler = handler;
            this.selectedItem = item;
        }

        private void FormItemEdit_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                textBoxDefIndex.Text = $"{selectedItem.DefIndex}";
                textBoxRarity.Text = $"{selectedItem.Rarity}";
                textBoxPaintId.Text = $"{selectedItem.PaintId}";
                textBoxPattern.Text = $"{selectedItem.Pattern}";
                textBoxWear.Text = $"{selectedItem.Wear}";
                textBoxStattrakKills.Text = $"{selectedItem.StatTrakKills}";
                if (selectedItem.CustomName != null) textBoxCustomName.Text = selectedItem.CustomName;
                if (selectedItem.IsStatTrak) checkBoxStatTrak.Checked = true;
                textBoxStickerId.Text = $"{selectedItem.StickerId}";
                textBoxSticker2.Text = $"{selectedItem.Sticker2Id}";
                textBoxSticker3.Text = $"{selectedItem.Sticker3Id}";
                textBoxSticker4.Text = $"{selectedItem.Sticker4Id}";
                textBoxSticker1Scrape.Text = selectedItem.Sticker1Scrape;
                textBoxSticker2Scrape.Text = selectedItem.Sticker2Scrape;
                textBoxSticker3Scrape.Text = selectedItem.Sticker3Scrape;
                textBoxSticker4Scrape.Text = selectedItem.Sticker4Scrape;
                if (selectedItem.IsGraffiti) textBoxGraffitiColor.Text = $"{selectedItem.GraffitiColor}";
                else textBoxGraffitiColor.Text = "0";
            }));
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int itemId = selectedItem.ItemId;
            int invId = selectedItem.InvId;
            int quality = 0;
            if (checkBoxStatTrak.Checked) quality = 9;
            else if (selectedItem.IsWeapon && selectedItem.DefIndex >= 500) quality = 3;
            inventoryHandler.Delete(selectedItem);
            Item modifiedItem;
            if (textBoxCustomName.Text != "") { modifiedItem = new Item(inventoryHandler, int.Parse(textBoxDefIndex.Text), itemId, invId, quality, int.Parse(textBoxRarity.Text), false, int.Parse(textBoxStickerId.Text), textBoxCustomName.Text); }
            else modifiedItem = new Item(inventoryHandler, int.Parse(textBoxDefIndex.Text), itemId, invId, quality, int.Parse(textBoxRarity.Text), false, int.Parse(textBoxStickerId.Text));
            double wearRaw = 0;
            if (textBoxWear.Text.Contains('.')) wearRaw = double.Parse(textBoxWear.Text.Split('.')[1]);
            else if (textBoxWear.Text.Contains(',')) wearRaw = double.Parse(textBoxWear.Text.Split(',')[1]);
            else
            {
                try
                {
                    wearRaw = int.Parse(textBoxWear.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Wear is in incorrect format. Defaulting to 0");
                    wearRaw = 0;
                }
            }
            double wear = wearRaw / 1000000;
            if (modifiedItem.IsWeapon || modifiedItem.IsSticker || modifiedItem.IsPatch || modifiedItem.IsGraffiti)
            {
                List<string> attributes = new List<string>();
                attributes.Add("\t\t\"attributes\"");
                attributes.Add("\t\t{");
                if (modifiedItem.IsWeapon)
                {
                    modifiedItem.SetWeaponInfo(int.Parse(textBoxPaintId.Text), int.Parse(textBoxPattern.Text), wear);
                    attributes.Add($"\t\t\t\"6\"\t\t\"{int.Parse(textBoxPaintId.Text)}.000000\"");
                    attributes.Add($"\t\t\t\"7\"\t\t\"{int.Parse(textBoxPattern.Text)}.000000\"");
                    attributes.Add($"\t\t\t\"8\"\t\t\"{wear.ToString(CultureInfo.InvariantCulture)}\"");
                    if (checkBoxStatTrak.Checked)
                    {
                        attributes.Add($"\t\t\t\"80\"\t\t\"{int.Parse(textBoxStattrakKills.Text)}\"");
                        attributes.Add($"\t\t\t\"81\"\t\t\"0\"");
                    }
                }
                if (textBoxStickerId.Text != "0")
                {
                    attributes.Add($"\t\t\t\"113\"\t\t\"{int.Parse(textBoxStickerId.Text)}\"");
                }
                if (textBoxSticker1Scrape.Text != "0")
                {
                    attributes.Add($"\t\t\t\"114\"\t\t\"{textBoxSticker1Scrape.Text}\"");
                }
                if (textBoxSticker2.Text != "0")
                {
                    attributes.Add($"\t\t\t\"117\"\t\t\"{int.Parse(textBoxSticker2.Text)}\"");
                }
                if (textBoxSticker2Scrape.Text != "0")
                {
                    attributes.Add($"\t\t\t\"118\"\t\t\"{textBoxSticker2Scrape.Text}\"");
                }
                if (textBoxSticker3.Text != "0")
                {
                    attributes.Add($"\t\t\t\"121\"\t\t\"{int.Parse(textBoxSticker3.Text)}\"");
                }
                if (textBoxSticker3Scrape.Text != "0")
                {
                    attributes.Add($"\t\t\t\"122\"\t\t\"{textBoxSticker3Scrape.Text}\"");
                }
                if (textBoxSticker4.Text != "0")
                {
                    attributes.Add($"\t\t\t\"125\"\t\t\"{int.Parse(textBoxSticker4.Text)}\"");
                }
                if (textBoxSticker4Scrape.Text != "0")
                {
                    attributes.Add($"\t\t\t\"126\"\t\t\"{textBoxSticker4Scrape.Text}\"");
                }
                if (modifiedItem.IsGraffiti)
                {
                    attributes.Add($"\t\t\t\"233\"\t\t\"{int.Parse(textBoxGraffitiColor.Text)}\"");
                }
                attributes.Add("\t\t}");
                modifiedItem.SetAttributes(attributes);
            }
            inventoryHandler.DuplicateItem(modifiedItem);
            form1.ApplyFilter("");
            form1.UpdateItemList();
            this.Close();
        }

        private void textBoxDefIndex_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Item dummy = new Item(inventoryHandler, int.Parse(textBoxDefIndex.Text), 0, 0, 0, 0, false, 0);
                if (dummy.IsWeapon && textBoxPaintId.Text != "") dummy.SetWeaponInfo(int.Parse(textBoxPaintId.Text), 0, 0);
                labelItemName.Text = dummy.Name;
                if (dummy.IsWeapon) labelStickerId.Text = "Sticker 1 Index:";
                else if (dummy.IsSticker) labelStickerId.Text = "Sticker Index:";
                else if (dummy.IsGraffiti) labelStickerId.Text = "Graffiti Index:";
                else if (dummy.IsPatch) labelStickerId.Text = "Patch Index:";
                else if (dummy.IsAgent)
                {
                    labelStickerId.Text = "Patch 1 Index:";
                    labelSticker2.Text = "Patch 2 Index:";
                    labelSticker3.Text = "Patch 3 Index:";
                }
                else
                {
                    labelStickerId.Text = "Sticker Index:";
                    labelSticker2.Text = "Sticker 2 Index:";
                    labelSticker3.Text = "Sticker 3 Index:";
                }
            }
            catch (Exception)
            {
                labelItemName.Text = "";
            }
        }

        private void textBoxPaintId_TextChanged(object sender, EventArgs e)
        {
            textBoxDefIndex_TextChanged((object) sender, e);
        }
    }
}
