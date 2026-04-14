using CSGO_GC_Inventory_Tool.Classes;
using CSGO_GC_Inventory_Tool.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSGO_GC_Inventory_Tool
{
    public partial class FormItemCreator : Form
    {
        InventoryHandler inventoryHandler;
        Form1 form1;
        bool loading;
        int quality = 0;
        public FormItemCreator(InventoryHandler handler, Form1 form1)
        {
            this.inventoryHandler = handler;
            this.form1 = form1;
            InitializeComponent();
        }

        private void FormItemCreator_Load(object sender, EventArgs e)
        {
            var loadingForm = new FormLoading();
            MainForm_Load(loadingForm);
            panelRarityColor.BackColor = GetRarityColor(Convert.ToInt32(numericUpDownRarity.Value));
        }

        public static string GetDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attr?.Description ?? value.ToString();
        }

        private async Task LoadDataAsync(FormLoading formLoading)
        {
            await Task.Run(() =>
            {
                this.Invoke(new Action(async () =>
                {
                    formLoading.SetStatus("Loading Weapons...");
                    formLoading.SetProgress(1);
                    formLoading.Refresh();
                    comboBoxWeapons.DataSource = Enum.GetValues(typeof(Weapon));
                    comboBoxWeapons.Format += (s, e) =>
                    {
                        if (e.ListItem is Enum enumValue)
                        {
                            e.Value = GetDescription(enumValue);
                        }
                    };

                    formLoading.SetStatus("Loading Finishes...");
                    formLoading.SetProgress(2);
                    formLoading.Refresh();
                    comboBoxFinishes.DataSource = FinishMap.Names.ToList();
                    comboBoxFinishes.DisplayMember = "Value";
                    comboBoxFinishes.ValueMember = "Key";

                    formLoading.SetStatus("Loading Agents...");
                    formLoading.SetProgress(3);
                    formLoading.Refresh();
                    comboBoxAgents.DataSource = AgentMap.Names.ToList();
                    comboBoxAgents.DisplayMember = "Value";
                    comboBoxAgents.ValueMember = "Key";

                    formLoading.SetStatus("Loading Collectibles...");
                    formLoading.SetProgress(4);
                    formLoading.Refresh();
                    comboBoxCollectibles.DataSource = CollectibleMap.Names.ToList();
                    comboBoxCollectibles.DisplayMember = "Value";
                    comboBoxCollectibles.ValueMember = "Key";

                    formLoading.SetStatus("Loading Stickers...");
                    formLoading.SetProgress(5);
                    formLoading.Refresh();
                    comboBoxStickers.DataSource = StickerMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Sticker | ", "")
                    })
                    .ToList();
                    comboBoxStickers.DisplayMember = "Value";
                    comboBoxStickers.ValueMember = "Key";

                    formLoading.SetStatus("Loading Patches...");
                    formLoading.SetProgress(6);
                    formLoading.Refresh();
                    comboBoxPatches.DataSource = PatchMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Patch | ", "")
                    })
                    .ToList();
                    comboBoxPatches.DisplayMember = "Value";
                    comboBoxPatches.ValueMember = "Key";

                    formLoading.SetStatus("Loading Music Kits...");
                    formLoading.SetProgress(7);
                    formLoading.Refresh();
                    comboBoxMusicKits.DataSource = MusicMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Music Kit | ", "")
                    })
                    .ToList();
                    comboBoxMusicKits.DisplayMember = "Value";
                    comboBoxMusicKits.ValueMember = "Key";

                    formLoading.SetStatus("Loading Graffities...");
                    formLoading.SetProgress(8);
                    formLoading.Refresh();
                    comboBoxGraffities.DataSource = GraffitiMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Sealed Graffiti | ", "")
                    })
                    .ToList();
                    comboBoxGraffities.DisplayMember = "Value";
                    comboBoxGraffities.ValueMember = "Key";

                    formLoading.SetStatus("Loading Keys...");
                    formLoading.SetProgress(9);
                    formLoading.Refresh();
                    comboBoxKeys.DataSource = KeyMap.Names.ToList();
                    comboBoxKeys.DisplayMember = "Value";
                    comboBoxKeys.ValueMember = "Key";
                }));
            });
        }

        private async void MainForm_Load(FormLoading formLoading)
        {
            if (!loading)
            {
                formLoading.Show();
                formLoading.Refresh();
                loading = true;
                await LoadDataAsync(formLoading);
                loading = false;
                formLoading.Close();
                checkBoxSticker5.Enabled = false;
            }
        }

        private async Task LoadDataWeaponStickers(FormLoading formLoading)
        {
            await Task.Run(() =>
            {
                this.Invoke(new Action(async () =>
                {
                    formLoading.SetStatus("Loading Weapon Stickers... 1/5");
                    formLoading.SetProgress(1);
                    formLoading.Refresh();
                    comboBoxSticker1.DataSource = StickerMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Sticker | ", "")
                    })
                    .ToList();
                    comboBoxSticker1.DisplayMember = "Value";
                    comboBoxSticker1.ValueMember = "Key";

                    formLoading.SetStatus("Loading Weapon Stickers... 2/5");
                    formLoading.SetProgress(3);
                    formLoading.Refresh();
                    comboBoxSticker2.DataSource = StickerMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Sticker | ", "")
                    })
                    .ToList();
                    comboBoxSticker2.DisplayMember = "Value";
                    comboBoxSticker2.ValueMember = "Key";

                    formLoading.SetStatus("Loading Weapon Stickers... 3/5");
                    formLoading.SetProgress(5);
                    formLoading.Refresh();
                    comboBoxSticker3.DataSource = StickerMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Sticker | ", "")
                    })
                    .ToList();
                    comboBoxSticker3.DisplayMember = "Value";
                    comboBoxSticker3.ValueMember = "Key";

                    formLoading.SetStatus("Loading Weapon Stickers... 4/5");
                    formLoading.SetProgress(7);
                    formLoading.Refresh();
                    comboBoxSticker4.DataSource = StickerMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Sticker | ", "")
                    })
                    .ToList();
                    comboBoxSticker4.DisplayMember = "Value";
                    comboBoxSticker4.ValueMember = "Key";

                    formLoading.SetStatus("Loading Weapon Stickers... 5/5");
                    formLoading.SetProgress(9);
                    formLoading.Refresh();
                    comboBoxSticker5.DataSource = StickerMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Sticker | ", "")
                    })
                    .ToList();
                    comboBoxSticker5.DisplayMember = "Value";
                    comboBoxSticker5.ValueMember = "Key";
                }));
            });
        }

        private async void WeaponStickers_Load(FormLoading formLoading)
        {
            while (loading)
            {
                await Task.Delay(50);
            }
            formLoading.Show();
            formLoading.Refresh();

            loading = true;
            await LoadDataWeaponStickers(formLoading);
            loading = false;

            formLoading.Close();
        }

        private async Task LoadDataAgentPatches(FormLoading formLoading)
        {
            await Task.Run(() =>
            {
                this.Invoke(new Action(async () =>
                {
                    formLoading.SetStatus("Loading Agent Patches... 1/3");
                    formLoading.SetProgress(3);
                    formLoading.Refresh();
                    comboBoxSticker1.DataSource = PatchMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Patch | ", "")
                    })
                    .ToList();
                    comboBoxSticker1.DisplayMember = "Value";
                    comboBoxSticker1.ValueMember = "Key";

                    formLoading.SetStatus("Loading Agent Patches... 2/3");
                    formLoading.SetProgress(6);
                    formLoading.Refresh();
                    comboBoxSticker2.DataSource = PatchMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Patch | ", "")
                    })
                    .ToList();
                    comboBoxSticker2.DisplayMember = "Value";
                    comboBoxSticker2.ValueMember = "Key";

                    formLoading.SetStatus("Loading Agent Patches 3/3");
                    formLoading.SetProgress(9);
                    formLoading.Refresh();
                    comboBoxSticker3.DataSource = PatchMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Patch | ", "")
                    })
                    .ToList();
                    comboBoxSticker3.DisplayMember = "Value";
                    comboBoxSticker3.ValueMember = "Key";
                }));
            });
        }

        private async void AgentPatches_Load(FormLoading formLoading)
        {
            while (loading)
            {
                await Task.Delay(50);
            }
            formLoading.Show();
            formLoading.Refresh();

            loading = true;
            await LoadDataAgentPatches(formLoading);
            loading = false;

            formLoading.Close();
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

        private void SetComboBoxesEnabled(Control parent, bool enabled)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is System.Windows.Forms.ComboBox cb)
                {
                    cb.Enabled = enabled;
                }

                // Recurse into child containers
                if (ctrl.HasChildren)
                {
                    SetComboBoxesEnabled(ctrl, enabled);
                }
            }
        }

        private void SetItemPropertiesEnabled(bool enabled)
        {
            foreach (Control ctrl in groupBoxProperties.Controls)
            {
                ctrl.Enabled = enabled;
            }
            labelRarity.Enabled = true;
            numericUpDownRarity.Enabled = true;
            labelName.Enabled = true;
            panelRarityColor.Enabled = true;
            labelQuality.Enabled = true;
            comboBoxSticker1.Enabled = false;
            comboBoxSticker2.Enabled = false;
            comboBoxSticker3.Enabled = false;
            comboBoxSticker4.Enabled = false;
            comboBoxSticker5.Enabled = false;
            labelScrape1.Enabled = false;
            labelScrape2.Enabled = false;
            labelScrape3.Enabled = false;
            labelScrape4.Enabled = false;
            labelScrape5.Enabled = false;
            textBoxScrape1.Enabled = false;
            textBoxScrape2.Enabled = false;
            textBoxScrape3.Enabled = false;
            textBoxScrape4.Enabled = false;
            textBoxScrape5.Enabled = false;
            checkBoxStatTrak.Checked = false;
            checkBoxSticker1.Checked = false;
            checkBoxSticker2.Checked = false;
            checkBoxSticker3.Checked = false;
            checkBoxSticker4.Checked = false;
            checkBoxSticker5.Checked = false;
            numericUpDownRarity.Value = 0;
            buttonSave.Enabled = true;
        }

        private void radioButtonWeapon_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWeapon.Checked)
            {
                var correctSource = StickerMap.Names
                    .Select(kv => new
                    {
                        kv.Key,
                        Value = kv.Value.Replace("Sticker | ", "")
                    })
                    .ToList();

                if (comboBoxSticker1.DataSource != correctSource || comboBoxSticker2.DataSource != correctSource || comboBoxSticker3.DataSource != correctSource || comboBoxSticker4.DataSource != correctSource)
                {
                    FormLoading formLoading = new FormLoading();
                    WeaponStickers_Load(formLoading);
                }
            }
            this.Invoke(new Action(() =>
            {
                SetComboBoxesEnabled(panelItemType, false);
                comboBoxWeapons.Enabled = true;

                SetItemPropertiesEnabled(true);
                checkBoxSticker1.Text = "Sticker 1";
                checkBoxSticker2.Text = "Sticker 2";
                checkBoxSticker3.Text = "Sticker 3";
                labelGraffitiColor.Enabled = false;
                numericUpDownGraffitiColor.Enabled = false;
                UpdateName();
                UpdateQuality();
            }));
        }

        private void radioButtonSticker_CheckedChanged(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                SetComboBoxesEnabled(panelItemType, false);
                comboBoxStickers.Enabled = true;

                SetItemPropertiesEnabled(false);
                UpdateName();
            }));
        }

        private void radioButtonPatch_CheckedChanged(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                SetComboBoxesEnabled(panelItemType, false);
                comboBoxPatches.Enabled = true;

                SetItemPropertiesEnabled(false);
                UpdateName();
            }));
        }

        private void radioButtonGraffiti_CheckedChanged(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                SetComboBoxesEnabled(panelItemType, false);
                comboBoxGraffities.Enabled = true;

                SetItemPropertiesEnabled(false);
                labelGraffitiColor.Enabled = true;
                numericUpDownGraffitiColor.Enabled = true;
                UpdateName();
            }));
        }

        private void radioButtonAgent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAgent.Checked)
            {
                var correctSource = AgentMap.Names.ToList();

                if (comboBoxSticker1.DataSource != correctSource || comboBoxSticker2.DataSource != correctSource || comboBoxSticker3.DataSource != correctSource)
                {
                    FormLoading formLoading = new FormLoading();
                    AgentPatches_Load(formLoading);
                }
            }
            this.Invoke(new Action(() =>
            {
                SetComboBoxesEnabled(panelItemType, false);
                comboBoxAgents.Enabled = true;

                SetItemPropertiesEnabled(false);
                UpdateName();
                checkBoxSticker1.Enabled = true;
                checkBoxSticker1.Text = "Patch 1";
                checkBoxSticker2.Enabled = true;
                checkBoxSticker2.Text = "Patch 2";
                checkBoxSticker3.Enabled = true;
                checkBoxSticker3.Text = "Patch 3";
            }));
        }

        private void radioButtonCollectible_CheckedChanged(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                SetComboBoxesEnabled(panelItemType, false);
                comboBoxCollectibles.Enabled = true;

                SetItemPropertiesEnabled(false);
                UpdateName();
            }));
        }

        private void radioButtonMusicKit_CheckedChanged(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                SetComboBoxesEnabled(panelItemType, false);
                comboBoxMusicKits.Enabled = true;

                SetItemPropertiesEnabled(false);
                UpdateName();
                checkBoxStatTrak.Enabled = true;
                numericUpDownStatTrakKills.Enabled = true;
            }));
        }

        private void radioButtonKey_CheckedChanged(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                SetComboBoxesEnabled(panelItemType, false);
                comboBoxKeys.Enabled = true;

                SetItemPropertiesEnabled(false);
                UpdateName();
                labelRarity.Enabled = false;
                numericUpDownRarity.Enabled = false;
                numericUpDownRarity.Value = 1;
            }));
        }

        private void checkBoxSticker1_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSticker1.Enabled = checkBoxSticker1.Checked;
            labelScrape1.Enabled = checkBoxSticker1.Checked;
            textBoxScrape1.Enabled = checkBoxSticker1.Checked;
        }

        private void checkBoxSticker2_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSticker2.Enabled = checkBoxSticker2.Checked;
            labelScrape2.Enabled = checkBoxSticker2.Checked;
            textBoxScrape2.Enabled = checkBoxSticker2.Checked;
        }

        private void checkBoxSticker3_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSticker3.Enabled = checkBoxSticker3.Checked;
            labelScrape3.Enabled = checkBoxSticker3.Checked;
            textBoxScrape3.Enabled = checkBoxSticker3.Checked;
        }

        private void checkBoxSticker4_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSticker4.Enabled = checkBoxSticker4.Checked;
            labelScrape4.Enabled = checkBoxSticker4.Checked;
            textBoxScrape4.Enabled = checkBoxSticker4.Checked;
        }

        private void checkBoxSticker5_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSticker5.Enabled = checkBoxSticker5.Checked;
            labelScrape5.Enabled = checkBoxSticker5.Checked;
            textBoxScrape5.Enabled = checkBoxSticker5.Checked;
        }

        private void numericUpDownRarity_ValueChanged(object sender, EventArgs e)
        {
            panelRarityColor.BackColor = GetRarityColor(Convert.ToInt32(numericUpDownRarity.Value));
        }

        private void UpdateWeaponStickerControls()
        {
            checkBoxSticker1.Checked = false;
            checkBoxSticker2.Checked = false;
            checkBoxSticker3.Checked = false;
            checkBoxSticker4.Checked = false;
            checkBoxSticker5.Checked = false;
            if ((int)comboBoxWeapons.SelectedItem >= 500)
            {
                checkBoxSticker1.Enabled = false;
                checkBoxSticker2.Enabled = false;
                checkBoxSticker3.Enabled = false;
                checkBoxSticker4.Enabled = false;
                checkBoxSticker5.Enabled = false;
                comboBoxSticker1.Enabled = false;
                comboBoxSticker2.Enabled = false;
                comboBoxSticker3.Enabled = false;
                comboBoxSticker4.Enabled = false;
                comboBoxSticker5.Enabled = false;
                labelScrape1.Enabled = false;
                labelScrape2.Enabled = false;
                labelScrape3.Enabled = false;
                labelScrape4.Enabled = false;
                labelScrape5.Enabled = false;
                textBoxScrape1.Enabled = false;
                textBoxScrape2.Enabled = false;
                textBoxScrape3.Enabled = false;
                textBoxScrape4.Enabled = false;
                textBoxScrape5.Enabled = false;
            }
            else if ((int)comboBoxWeapons.SelectedItem == (int)Weapon.g3sg1)
            {
                checkBoxSticker1.Enabled = true;
                checkBoxSticker2.Enabled = true;
                checkBoxSticker3.Enabled = true;
                checkBoxSticker4.Enabled = true;
                checkBoxSticker5.Enabled = true;
            }
            else
            {
                checkBoxSticker1.Enabled = true;
                checkBoxSticker2.Enabled = true;
                checkBoxSticker3.Enabled = true;
                checkBoxSticker4.Enabled = true;
                checkBoxSticker5.Enabled = false;
            }
        }

        private void comboBoxWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWeaponStickerControls();
            UpdateName();
            UpdateQuality();
        }

        private void UpdateName()
        {
            string newName = "";
            if (radioButtonWeapon.Checked && comboBoxWeapons.SelectedItem != null && comboBoxFinishes.SelectedItem != null)
            {
                var selected = (KeyValuePair<int, string>)comboBoxFinishes.SelectedItem;
                newName = $"{GetDescription((Weapon)comboBoxWeapons.SelectedItem)} | {(FinishMap.Names.TryGetValue(selected.Key, out var name) ? name : $"<Unknown Finish>")}";
            }
            if (radioButtonAgent.Checked && comboBoxAgents.SelectedValue != null) newName = $"{(AgentMap.Names.TryGetValue(int.Parse(comboBoxAgents.SelectedValue.ToString()), out var name) ? name : $"<Unknown Agent>")}";
            if (radioButtonSticker.Checked && comboBoxStickers.SelectedValue != null) newName = $"{(StickerMap.Names.TryGetValue(int.Parse(comboBoxStickers.SelectedValue.ToString()), out var name) ? name : $"<Unknown Sticker>")}";
            if (radioButtonCollectible.Checked && comboBoxCollectibles.SelectedValue != null) newName = $"{(CollectibleMap.Names.TryGetValue(int.Parse(comboBoxCollectibles.SelectedValue.ToString()), out var name) ? name : $"<Unknown Collectible>")}";
            if (radioButtonPatch.Checked && comboBoxPatches.SelectedValue != null) newName = $"{(PatchMap.Names.TryGetValue(int.Parse(comboBoxPatches.SelectedValue.ToString()), out var name) ? name : $"<Unknown Patch>")}";
            if (radioButtonMusicKit.Checked && comboBoxMusicKits.SelectedValue != null) newName = $"{(MusicMap.Names.TryGetValue(int.Parse(comboBoxMusicKits.SelectedValue.ToString()), out var name) ? name : $"<Unknown Music Kit>")}";
            if (radioButtonGraffiti.Checked && comboBoxGraffities.SelectedValue != null) newName = $"{(GraffitiMap.Names.TryGetValue(int.Parse(comboBoxGraffities.SelectedValue.ToString()), out var name) ? name : $"<Unknown Graffiti>")}";
            if (radioButtonKey.Checked && comboBoxKeys.SelectedValue != null) newName = $"{(KeyMap.Names.TryGetValue(int.Parse(comboBoxKeys.SelectedValue.ToString()), out var name) ? name : $"<Unknown Key>")}";
            labelName.Text = newName;
        }

        private void comboBoxStickers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateName();
        }

        private void comboBoxPatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateName();
        }

        private void comboBoxGraffities_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateName();
        }

        private void comboBoxAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateName();
        }

        private void comboBoxCollectibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateName();
        }

        private void comboBoxMusicKits_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateName();
        }

        private void comboBoxKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateName();
        }

        private void comboBoxFinishes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateName();
        }

        private void UpdateQuality()
        {
            if (radioButtonWeapon.Checked && (int)comboBoxWeapons.SelectedItem >= 500 && !checkBoxStatTrak.Checked)
            {
                labelQuality.Text = "Quality: 3";
                quality = 3;
            }
            else if (checkBoxStatTrak.Checked)
            {
                labelQuality.Text = "Quality: 9";
                quality = 9;
            }
            else
            {
                labelQuality.Text = "Quality: 0";
                quality = 0;
            }
        }

        private void checkBoxStatTrak_CheckedChanged(object sender, EventArgs e)
        {
            UpdateQuality();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int newDefindex = 0;
            if (radioButtonWeapon.Checked) newDefindex = (int)comboBoxWeapons.SelectedItem;
            if (radioButtonAgent.Checked) newDefindex = ((KeyValuePair<int, string>)comboBoxAgents.SelectedItem).Key;
            if (radioButtonSticker.Checked) newDefindex = 1209;
            if (radioButtonCollectible.Checked) newDefindex = ((KeyValuePair<int, string>)comboBoxCollectibles.SelectedItem).Key;
            if (radioButtonPatch.Checked) newDefindex = 4609;
            if (radioButtonMusicKit.Checked) newDefindex = 1314;
            if (radioButtonGraffiti.Checked) newDefindex = 1348;
            if (radioButtonKey.Checked) newDefindex = ((KeyValuePair<int, string>)comboBoxKeys.SelectedItem).Key;
            MessageBox.Show($"{newDefindex}");
        }
    }
}
