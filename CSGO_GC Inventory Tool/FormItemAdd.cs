using CSGO_GC_Inventory_Tool.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSGO_GC_Inventory_Tool.Enums;

namespace CSGO_GC_Inventory_Tool
{
    public partial class FormItemAdd : Form
    {
        InventoryHandler inventoryHandler;
        Form1 form1;
        public FormItemAdd(InventoryHandler handler, Form1 form1)
        {
            InitializeComponent();
            inventoryHandler = handler;
            this.form1 = form1;
        }

        private void FormItemAdd_Load(object sender, EventArgs e)
        {
            listBoxCases.DataSource = CrateMap.Names.Values.ToList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                inventoryHandler.AddCase(CrateMap.Names.FirstOrDefault(x => x.Value == listBoxCases.SelectedItem).Key);
            }
            form1.ApplyFilter("");
            form1.UpdateItemList();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = textBoxSearch.Text.ToLower();

            var filtered = CrateMap.Names
                .Where(x => x.Value.ToLower().Contains(filter))
                .Select(x => x.Value)
                .ToList();

            listBoxCases.DataSource = filtered;
        }
    }
}
