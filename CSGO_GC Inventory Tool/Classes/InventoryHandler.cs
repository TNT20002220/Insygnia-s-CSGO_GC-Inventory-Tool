using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_GC_Inventory_Tool.Classes
{
    public class InventoryHandler
    {
        string inventoryPath;
        List<Item> items;
        int highestItemId = 0;
        int highestInvId = 0;
        bool exists = false;

        public string Path { get { return inventoryPath; } set { if (value != null && value is string) inventoryPath = value; } }
        public List<Item> Items => items;
        public int HighestItemId => highestItemId;
        public int HighestInvId => highestInvId;
        public bool Exists => exists;

        public InventoryHandler()
        {
            inventoryPath = "inventory.txt";
            items = new List<Item>();
        }

        public void SetInventoryPath(string path)
        {
            Path = path;
        }

        public void CreateEmptyInventory()
        {
            highestInvId = 0;
            highestItemId = 0;
            inventoryPath = "inventory.txt";
            this.items = new List<Item>();
            exists = true;
        }

        public int ParseInventoryFile()
        {
            if (!File.Exists(inventoryPath))
            {
                MessageBox.Show("inventory.txt not found");
                return 0;
            }
            else if (File.ReadAllLines(inventoryPath).Length == 0)
            {
                DialogResult dialog = MessageBox.Show("inventory.txt is empty. Do you want to format it?", "Format inventory?", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    CreateEmptyInventory();
                }
                return 0;
            }
            else if ((File.ReadAllLines(inventoryPath).Length < 3 && File.ReadAllLines(inventoryPath).Length != 0) || File.ReadAllLines(inventoryPath)[0] != "\"items\"" || File.ReadAllLines(inventoryPath)[1] != "{" || File.ReadAllLines(inventoryPath)[File.ReadAllLines(inventoryPath).Length - 1] != "}")
            {
                MessageBox.Show("Invalid inventory.txt");
                return 0;
            }
            else
            {
                highestInvId = 0;
                highestItemId = 0;
                this.items = new List<Item>();
                int items = 0;
                int inUseItems = 0;
                string[] rawInventory = File.ReadAllLines(inventoryPath);
                for (int i = 0; i < rawInventory.Length; i++)
                {
                    if (rawInventory[i] == "\t{")
                    {
                        items++;
                        int newItemId = int.Parse(rawInventory[i - 1].Split('"')[1]);
                        int newInvId = 0;
                        int newDefIndex = 0;
                        int newQuality = 0;
                        int newRarity = 0;
                        string newCustomName = "";
                        bool newInUse = false;
                        int newPaintId = 0;
                        int newPatternId = 0;
                        double newWear = 0;
                        string[] newEquippedState = new string[5];
                        List<string> newAttributes = new List<string>();
                        int newStickerId = 0;
                        int j = i - 1;
                        while (rawInventory[j] != "\t}")
                        {
                            string[] currentLine = rawInventory[j].Split('"');
                            if (currentLine.Length == 3 && currentLine[1] == "equipped_state")
                            {
                                int k = j;
                                int equippedIdx = 0;
                                while (rawInventory[k] != "\t\t}")
                                {
                                    newEquippedState[equippedIdx] = rawInventory[k];
                                    equippedIdx++;
                                    k++;
                                }
                                newEquippedState[equippedIdx] = "\t\t}";
                                //MessageBox.Show(string.Join(",", newEquippedState));
                            }
                            if (currentLine.Length == 3 && currentLine[1] == "attributes")
                            {
                                int k = j;
                                while (rawInventory[k] != "\t\t}")
                                {
                                    newAttributes.Add(rawInventory[k]);
                                    k++;
                                }
                                newAttributes.Add("\t\t}");
                                //MessageBox.Show(string.Join("", newAttributes));
                            }
                            if (currentLine.Length > 3)
                            {
                                if (currentLine[1] == "inventory") newInvId = int.Parse(currentLine[3]);
                                if (currentLine[1] == "def_index") newDefIndex = int.Parse(currentLine[3]);
                                if (currentLine[1] == "quality") newQuality = int.Parse(currentLine[3]);
                                if (currentLine[1] == "rarity") newRarity = int.Parse(currentLine[3]);
                                if (currentLine[1] == "custom_name") newCustomName = currentLine[3];
                                if (currentLine[1] == "6") newPaintId = int.Parse(currentLine[3].Split('.')[0]);
                                if (currentLine[1] == "7") newPatternId = int.Parse(currentLine[3].Split('.')[0]);
                                if (currentLine[1] == "8")
                                {
                                    try
                                    {
                                        newWear = double.Parse(currentLine[3].Split('.')[1]) / 1000000;
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Invalid item wear found. Defaulting to 0");
                                        newWear = 0;
                                    }
                                }
                                if (currentLine[1] == "in_use")
                                {
                                    if (currentLine[3] == "0") newInUse = false;
                                    else
                                    {
                                        newInUse = true;
                                        inUseItems++;
                                    }
                                }
                                if (currentLine[1] == "113") newStickerId = int.Parse(currentLine[3]);
                            }
                            j++;
                        }
                        if (newItemId > highestItemId) highestItemId = newItemId;
                        if (newInvId > highestInvId) highestInvId = newInvId;
                        if (newCustomName == "") this.items.Add(new Item(this, newDefIndex, newItemId, newInvId, newQuality, newRarity, newInUse, newStickerId));
                        else this.items.Add(new Item(this, newDefIndex, newItemId, newInvId, newQuality, newRarity, newInUse, newStickerId, newCustomName));
                        if (this.items[this.items.Count() - 1].IsWeapon) this.items[this.items.Count() - 1].SetWeaponInfo(newPaintId, newPatternId, newWear);
                        this.items[this.items.Count() - 1].SetEquippedState(newEquippedState);
                        this.items[this.items.Count() - 1].SetAttributes(newAttributes);
                    }
                }
                this.items = this.items
                    .OrderByDescending(item => item.Rarity)
                    .ThenByDescending(item => item.IsStatTrak)
                    .ThenBy(item => item.ToString())
                    .ThenBy(item => item.Wear)
                    .ToList();
                exists = true;
                return items;
            }
        }

        public void WriteNormalizedInventory()
        {
            string path = "inventory.txt";
            if (inventoryPath != "") path = inventoryPath;
            int index = 1;
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("\"items\"");
            sw.WriteLine("{");
            foreach (Item item in items)
            {
                sw.WriteLine(item.Write(index));
                index++;
            }
            sw.WriteLine("}");
            sw.Close();
            fs.Close();
            MessageBox.Show("Successfully normalized inventory");
            ParseInventoryFile();
            RefreshIndexes();
        }

        public void DuplicateItem(Item item)
        {
            if (item.CustomName != null) items.Add(new Item(this, item.DefIndex, highestItemId + 1, highestInvId + 1, item.Quality, item.Rarity, item.InUse, item.StickerId, item.CustomName));
            else items.Add(new Item(this, item.DefIndex, highestItemId + 1, highestInvId + 1, item.Quality, item.Rarity, item.InUse, item.StickerId));
            if (items[items.Count() - 1].IsWeapon) items[items.Count() - 1].SetWeaponInfo(item.PaintId, item.Pattern, item.Wear);
            items[items.Count() - 1].SetAttributes(item.Attributes);
            items[items.Count() - 1].SetEquippedState(item.EquippedState);
            RefreshIndexes();
        }

        public void RefreshIndexes()
        {
            highestInvId = 0;
            highestItemId = 0;
            foreach (Item item in items)
            {
                if (item.ItemId > highestItemId) highestItemId = item.ItemId;
                if (item.InvId > highestInvId) highestInvId = item.InvId;
            }
        }

        public void Delete(Item item)
        {
            Items.Remove(item);
            RefreshIndexes();
        }

        public void AddCase(int defIndex)
        {
            items.Add(new Item(this, defIndex, highestItemId + 1, highestInvId + 1, 4, 1, false, 0));
            RefreshIndexes();
        }

        public void RemoveDupes()
        {
            var weaponsToTrim = items
            .Where(item => item.DefIndex < 500);

            // Items to keep untouched
            var otherItems = items
                .Where(item => item.DefIndex >= 500);

            // Apply "lowest float per paint index"
            var trimmedWeapons = weaponsToTrim
                .GroupBy(item => item.PaintId)
                .Select(group => group
                    .Aggregate((min, current) =>
                        current.Wear < min.Wear ? current : min));

            // Combine both sets
            trimmedWeapons = trimmedWeapons
                .Concat(otherItems)
                .ToList();

            items = trimmedWeapons
                .OrderByDescending(item => item.Rarity)
                .ThenByDescending(item => item.IsStatTrak)
                .ThenBy(item => item.ToString())
                .ThenBy(item => item.Wear)
                .ToList();
            RefreshIndexes();
        }

        public void RemoveBulk(Item selectedItem)
        {
            List<Item> itemsToDelete = new List<Item>();
            foreach (Item item in items)
            {
                if (item.IsWeapon && selectedItem.IsWeapon && item.PaintId == selectedItem.PaintId && item.DefIndex == selectedItem.DefIndex) itemsToDelete.Add(item);
                else if (item.IsAgent && selectedItem.IsAgent && item.DefIndex == selectedItem.DefIndex) itemsToDelete.Add(item);
                else if (item.IsGraffiti && selectedItem.IsGraffiti && item.StickerId == selectedItem.StickerId) itemsToDelete.Add(item);
                else if (item.IsMusicKit && selectedItem.IsMusicKit && item.MusicId == selectedItem.MusicId) itemsToDelete.Add(item);
                else if (item.IsPatch && selectedItem.IsPatch && item.StickerId == selectedItem.StickerId) itemsToDelete.Add(item);
                else if (item.IsSticker && selectedItem.IsSticker && item.StickerId == selectedItem.StickerId) itemsToDelete.Add(item);
                else if (!item.IsWeapon && !item.IsAgent && !item.IsGraffiti && !item.IsMusicKit && !item.IsPatch && !item.IsSticker && item.DefIndex == selectedItem.DefIndex) itemsToDelete.Add(item);
            }
            DialogResult dialog = MessageBox.Show($"Are you sure you want to delete {itemsToDelete.Count()} of {selectedItem}?", "Are you sure?", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                foreach (Item item in itemsToDelete)
                {
                    items.Remove(item);
                }
            }
            RefreshIndexes();
        }
    }
}
