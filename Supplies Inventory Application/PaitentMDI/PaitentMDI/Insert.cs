//Matthew Trebing
//Insert Form
//11/29/16
//Program 7
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
    public partial class Insert : Form
    {
        private Records Record = new Records();

        public Insert()
        {
            InitializeComponent();
        }

        //Purpose:: To get the selected record information
        //from the text box
        //Requires:: Filled in text boxes
        //Returns:: A valid record 
        private void Insert_OK_Click(object sender, EventArgs e)
        { 
            //Will check to see if each item in the record is filled in
            //then will clear it after it has been passed to record
            try
            { 
                Record.ID = Convert.ToInt32(Item_ID_Text.Text);
                Record.Name = Item_Name_Text.Text;
                Record.QtyReq = Convert.ToInt32(QTY_Required_Text.Text);
                Record.Quantity = Convert.ToInt32(Qty_Hand_Text.Text);
                this.Close();
            }
            catch(SystemException)
            {
                //will tell the user that they are missing fields and will not insert or update the item
                MessageBox.Show("Missing one or more fields", "Missing Item or Items", MessageBoxButtons.OK);
            }
        }

        //Purpose:: To hide the insert form if the user selected cancel
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            
            this.Hide();//hides the form   
        }

        //returns the valid record
        public Records get_Record
        {
            get { return Record; }
        }
    }
}
