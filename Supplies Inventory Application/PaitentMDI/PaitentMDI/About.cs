using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaitentMDI
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        public void about_output()
        {
            aboutoutput.AppendText("Inventory Progam\n\n\n");
            aboutoutput.AppendText("Version: 1.0.1\n\n\n");
            aboutoutput.AppendText("Programmer: Matthew Trebing");
        }
    }
}
