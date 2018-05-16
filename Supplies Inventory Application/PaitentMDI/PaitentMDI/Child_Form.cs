//Matthew Trebing
//Program 7
//Child form
//11/29/16
using System;
using System.Collections;
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
    public partial class Child_Form : Form
    {
        ArrayList keeper;
        string itemsstring = "";
        string header;
        public string file_name;
        public int item_nums;
       
        public Child_Form()
        {
            InitializeComponent();
        }

        //Initalizes the Child form and sets the name
        //and adds the inital file to the listbox
        public Child_Form(string title, ArrayList Keeper)
        {
            InitializeComponent();

            //sets the name of the Form
            Text = title;

            Practice_Name.Text = "Practice name: " + "" + Text;
            
            //sets the arraylist to keeper
            keeper = Keeper;

            header = "ID\t\t" + "Name\t\t\t" + "Quantity Required\t\t\t" + "Quantity";
            
            Records_For_Patients.Items.Add(header);

            //for each existing item in the keeper array
            //adds it to the list box
            foreach (var item in keeper)
            {
                //adds the record item to the listbox to 
                //display it on the form
                addtolistbox((Records)item);
            }
            getcount();
        }

        //Purpose: To insert a record into the keeper array
        //Requires: A currect record
        //Returns: The added item to the listbox and the keeper array
        public void Insert_Record(Records record)
        {
            //memory issues added this
            //to avoid duplication in the keeper array
            Records r = new Records();
            r.ID = record.ID;
            r.Name = record.Name;
            r.QtyReq = record.QtyReq;
            r.Quantity = record.Quantity;

            //adds the record to the keeper array list
            keeper.Add(r);

            //adds the record to the listbox
            addtolistbox(r);
        }

        //Purpose: To add the item to the list box
        //Requires: A item string and a valid listbox
        //Returns: A new item to the listbox 
        public void addtolistbox(Records item)
        {
            //converts the items to a string name
            itemsstring =item.ToString();
             
            //Adds the item string to the list box
            Records_For_Patients.Items.Add(itemsstring);
            item_nums++;
            getcount();
        }

        //Purpose: To update the list box
        //Requires: A selected item in the listbox
        //Returns: A updated item
        public void updatelistbox(Records record)
        {
            //will select the index that is currently selected
            int i = Records_For_Patients.SelectedIndex;

            //will set the record to a string and add it to the
            //listbox updated
            Records_For_Patients.Items[i] = record.ToString();

            //removes
            keeper.RemoveAt(i);

            //adds to the end
            keeper.Add(record);
        }

        //Purpose:To remove a item
        //Requires:A Selected item
        //Returns:: Nothing item was removed
        public void deleteitem()
        {
            //removes the item from the listbox
            Records_For_Patients.Items.RemoveAt(Records_For_Patients.SelectedIndex);

            //and the array
            keeper.RemoveAt(Records_For_Patients.SelectedIndex+1);
            item_nums--;
            getcount();
        }

        public ArrayList getkeeper
        {
            get { return keeper; }
        } 

        //Purpose to get the count of what items
        //are in the listbox and also updates it
        //when you add or delete a item;
        public void getcount()
        {
            
            item_nums = Records_For_Patients.Items.Count-1;
            if (item_nums <= 0)
            {
                item_nums = 0;
                Item_Information.Text = "There is " + item_nums + " item in the current list";
            }
            else
            {
                Item_Information.Text = "There is " + item_nums + " item in the current list";
            }
        }
    }
}

