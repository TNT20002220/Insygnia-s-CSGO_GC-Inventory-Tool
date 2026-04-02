using CSGO_GC_Inventory_Tool.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_GC_Inventory_Tool.Classes
{
    public class Item
    {
        InventoryHandler inventoryHandler;
        bool isWeapon = true;
        int itemId;
        int defIndex;
        int invId;
        int quality;
        int rarity;
        bool inUse;
        int paintId;
        int pattern;
        double wear;
        string customName;
        string[] equippedState;
        List<string> attributes;
        int stickerId;

        public bool IsWeapon => isWeapon;
        public bool IsSticker => defIndex == 1209;
        public bool IsMusicKit => defIndex == 1314;
        public int MusicId
        {
            get
            {
                if (IsMusicKit)
                {
                    foreach (string line in Attributes)
                    {
                        if (line.Split('"').Length > 1 && line.Split('"')[1].Contains("166")) return int.Parse(line.Split('"')[3]);
                    }
                }
                return 0;
            }
        }
        public bool IsGraffiti => defIndex == 1348;
        public int GraffitiColor
        {
            get
            {
                if (IsGraffiti)
                {
                    foreach (string line in Attributes)
                    {
                        if (line.Split('"').Length > 1 && line.Split('"')[1].Contains("233")) return int.Parse(line.Split('"')[3]);
                    }
                }
                return 0;
            }
        }
        public bool IsPatch => defIndex == 4609;
        public bool IsAgent => AgentMap.Names.ContainsKey(defIndex);
        public int StickerId => stickerId;
        public string Sticker1Scrape
        {
            get
            {
                foreach (string line in Attributes)
                {
                    if (line.Split('"').Length > 1 && line.Split('"')[1].Contains("114")) return line.Split('"')[3];
                }
                return "0";
            }
        }
        public int Sticker2Id
        {
            get
            {
                foreach (string line in Attributes)
                {
                    if (line.Split('"').Length > 1 && line.Split('"')[1].Contains("117")) return int.Parse(line.Split('"')[3]);
                }
                return 0;
            }
        }
        public string Sticker2Scrape
        {
            get
            {
                foreach (string line in Attributes)
                {
                    if (line.Split('"').Length > 1 && line.Split('"')[1].Contains("118")) return line.Split('"')[3];
                }
                return "0";
            }
        }
        public int Sticker3Id
        {
            get
            {
                foreach (string line in Attributes)
                {
                    if (line.Split('"').Length > 1 && line.Split('"')[1].Contains("121")) return int.Parse(line.Split('"')[3]);
                }
                return 0;
            }
        }
        public string Sticker3Scrape
        {
            get
            {
                foreach (string line in Attributes)
                {
                    if (line.Split('"').Length > 1 && line.Split('"')[1].Contains("122")) return line.Split('"')[3];
                }
                return "0";
            }
        }
        public int Sticker4Id
        {
            get
            {
                foreach (string line in Attributes)
                {
                    if (line.Split('"').Length > 1 && line.Split('"')[1].Contains("125")) return int.Parse(line.Split('"')[3]);
                }
                return 0;
            }
        }
        public string Sticker4Scrape
        {
            get
            {
                foreach (string line in Attributes)
                {
                    if (line.Split('"').Length > 1 && line.Split('"')[1].Contains("126")) return line.Split('"')[3];
                }
                return "0";
            }
        }
        public bool InUse => inUse;
        public string ItemName
        {
            get
            {
                if (Enum.IsDefined(typeof(Weapon), defIndex))
                {
                    return GetDescription((Weapon)defIndex);
                }

                if (CrateMap.Names.ContainsKey(defIndex))
                {
                    return CrateMap.Names.TryGetValue(defIndex, out var name) ? name : $"Unknown Container ({defIndex})";
                }

                if (AgentMap.Names.ContainsKey(defIndex))
                {
                    return AgentMap.Names.TryGetValue(defIndex, out var name) ? name : $"Unknown Agent ({defIndex})";
                }

                if (KeyMap.Names.ContainsKey(defIndex))
                {
                    return KeyMap.Names.TryGetValue(defIndex, out var name) ? name : $"Unknown Key ({defIndex})";
                }

                if (CollectibleMap.Names.ContainsKey(defIndex))
                {
                    return CollectibleMap.Names.TryGetValue(defIndex, out var name) ? name : $"Unknown Collectible ({defIndex})";
                }

                if (IsPatch)
                {
                    return PatchMap.Names.TryGetValue(stickerId, out var name) ? name : $"Unknown Patch ({stickerId})";
                }

                if (IsMusicKit)
                {
                    return MusicMap.Names.TryGetValue(MusicId, out var name) ? name : $"Unknown Music Kit ({MusicId})";
                }

                if (IsGraffiti)
                {
                    return GraffitiMap.Names.TryGetValue(stickerId, out var name) ? name : $"Unknown Graffiti ({stickerId})";
                }

                if (IsPatch)
                {
                    return PatchMap.Names.TryGetValue(stickerId, out var name) ? name : $"Unknown Patch ({stickerId})";
                }

                if (IsSticker)
                {
                    return StickerMap.Names.TryGetValue(stickerId, out var name) ? name : $"Unknown Sticker ({stickerId})";
                }

                if (defIndex == 1201)
                {
                    return "Storage Unit";
                }

                return $"Unknown ({defIndex})";
            }
        }
        public string FinishName => FinishMap.Names.TryGetValue(paintId, out var name) ? name : $"Vanilla";
        public int ItemId => itemId;
        public int InvId => invId;
        public int DefIndex => defIndex;
        public int Quality => quality;
        public int Rarity => rarity;
        public string CustomName => customName;
        public int PaintId => paintId;
        public int Pattern => pattern;
        public double Wear => wear;
        public string[] EquippedState => equippedState;
        public List<string> Attributes => attributes;
        public bool IsStatTrak
        { get 
            {
                bool has80 = false;
                bool has81 = false;
                foreach (string line in Attributes)
                {
                    if (line.Split('"').Length > 1 && line.Split('"')[1].Contains("80")) has80 = true;
                    if (line.Split('"').Length > 1 && line.Split('"')[1].Contains("81")) has81 = true;
                }
                if (has80 && has81) return true;
                return false;
            } 
        }
        public int StatTrakKills { 
            get
            {
                if (IsStatTrak)
                {
                    foreach (string line in Attributes)
                    {
                        if (line.Split('"').Length > 1 && line.Split('"')[1].Contains("80")) return int.Parse(line.Split('"')[3]);
                    }
                }
                return 0;
            }
        }
        public string Name => this.ToString();

        public Item(InventoryHandler handler, int defIndex, int itemId, int invId, int quality, int rarity, bool inUse, int stickerId)
        {
            inventoryHandler = handler;
            this.defIndex = defIndex;
            if (!Enum.IsDefined(typeof(Weapon), defIndex)) isWeapon = false;
            this.itemId = itemId;
            this.invId = invId;
            this.quality = quality;
            this.rarity = rarity;
            this.inUse = inUse;
            this.equippedState = new string[]{ "" };
            this.attributes = new List<string>();
            this.stickerId = stickerId;
        }

        public Item(InventoryHandler handler, int defIndex, int itemId, int invId, int quality, int rarity, bool inUse, int stickerId, string customName)
        {
            inventoryHandler = handler;
            this.defIndex = defIndex;
            if (!Enum.IsDefined(typeof(Weapon), defIndex)) isWeapon = false;
            this.itemId = itemId;
            this.invId = invId;
            this.quality = quality;
            this.rarity = rarity;
            this.customName = customName;
            this.inUse = inUse;
            this.equippedState = new string[] { "" };
            this.attributes = new List<string>();
            this.stickerId = stickerId;
        }

        public void SetWeaponInfo(int paintId, int pattern, double wear)
        {
            if (!isWeapon) return;

            this.paintId = paintId;
            this.pattern = pattern;
            this.wear = wear;
        }

        public void SetEquippedState(string[] equippedState)
        {
            this.equippedState = equippedState;
        }

        public void SetAttributes(List<string> attributes)
        {
            this.attributes = attributes;
        }

        public static string GetDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attr?.Description ?? value.ToString();
        }

        public override string ToString()
        {
            if (isWeapon)
            {
                if (IsStatTrak) return $"StatTrak {ItemName} | {FinishName}";
                return $"{ItemName} | {FinishName}";
            }
            else if (IsStatTrak) return $"StatTrak {ItemName}";
            else return $"{ItemName}";
        }

        public string Write(int index)
        {
            if (customName != null)
            {
                return $"\t\"{index}\"" +
                $"\n\t{{" +
                $"\n\t\t\"inventory\"\t\t\"{index}\"" +
                $"\n\t\t\"def_index\"\t\t\"{defIndex}\"" +
                $"\n\t\t\"level\"\t\t\"1\"" +
                $"\n\t\t\"quality\"\t\t\"{quality}\"" +
                $"\n\t\t\"flags\"\t\t\"0\"" +
                $"\n\t\t\"origin\"\t\t\"8\"" +
                $"\n\t\t\"custom_name\"\t\t\"{customName}\"" +
                $"\n\t\t\"in_use\"\t\t\"0\"" +
                $"\n\t\t\"rarity\"\t\t\"{rarity}\"" +
                $"\n{string.Join("\n", attributes)}" +
                $"\n{string.Join("\n", equippedState)}" +
                $"\n\t}}";
            }
            return $"\t\"{index}\"" +
                $"\n\t{{" +
                $"\n\t\t\"inventory\"\t\t\"{index}\"" +
                $"\n\t\t\"def_index\"\t\t\"{defIndex}\"" +
                $"\n\t\t\"level\"\t\t\"1\"" +
                $"\n\t\t\"quality\"\t\t\"{quality}\"" +
                $"\n\t\t\"flags\"\t\t\"0\"" +
                $"\n\t\t\"origin\"\t\t\"8\"" +
                $"\n\t\t\"in_use\"\t\t\"0\"" +
                $"\n\t\t\"rarity\"\t\t\"{rarity}\"" +
                $"\n{string.Join("\n", attributes)}" +
                $"\n{string.Join("\n", equippedState)}" +
                $"\n\t}}";
        }
    }
}
