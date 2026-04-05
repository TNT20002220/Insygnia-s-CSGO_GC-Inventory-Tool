using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CSGO_GC_Inventory_Tool
{
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
        }

        private void FormLoading_Load(object sender, EventArgs e)
        {

        }

        public void SetStatus(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetStatus(text)));
                return;
            }

            labelStatus.Text = text;
        }

        public void SetProgress(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetProgress(value)));
                return;
            }
            progressBar1.Value = value;
        }
    }
}
