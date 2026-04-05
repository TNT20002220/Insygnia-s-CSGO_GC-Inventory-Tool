using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSGO_GC_Inventory_Tool.Classes;
using CSGO_GC_Inventory_Tool.Enums;

namespace CSGO_GC_Inventory_Tool
{
    public partial class FormItemCreator : Form
    {
        InventoryHandler inventoryHandler;
        Form1 form1;
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

                    formLoading.SetStatus("Loading Agents...");
                    formLoading.SetProgress(2);
                    formLoading.Refresh();
                    comboBoxAgents.DataSource = AgentMap.Names.ToList();
                    comboBoxAgents.DisplayMember = "Value";
                    comboBoxAgents.ValueMember = "Key";

                    formLoading.SetStatus("Loading Collectibles...");
                    formLoading.SetProgress(3);
                    formLoading.Refresh();
                    comboBoxCollectibles.DataSource = CollectibleMap.Names.ToList();
                    comboBoxCollectibles.DisplayMember = "Value";
                    comboBoxCollectibles.ValueMember = "Key";

                    formLoading.SetStatus("Loading Stickers...");
                    formLoading.SetProgress(4);
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
                    formLoading.SetProgress(5);
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
                    formLoading.SetProgress(6);
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
                    formLoading.SetProgress(7);
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
                    formLoading.SetProgress(8);
                    formLoading.Refresh();
                    comboBoxKeys.DataSource = KeyMap.Names.ToList();
                    comboBoxKeys.DisplayMember = "Value";
                    comboBoxKeys.ValueMember = "Key";
                }));
            });
        }

        private async void MainForm_Load(FormLoading formLoading)
        {
            formLoading.Show();
            formLoading.Refresh();

            await LoadDataAsync(formLoading);

            formLoading.Close();
        }
    }
}
