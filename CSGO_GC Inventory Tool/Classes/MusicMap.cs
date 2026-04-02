using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSGO_GC_Inventory_Tool.Classes
{
    public static class MusicMap
    {
        public static Dictionary<int, string> Names { get; private set; }

        public static void Load(string path)
        {
            var json = File.ReadAllText(path);
            Names = JsonSerializer.Deserialize<Dictionary<int, string>>(json);
        }
    }
}
