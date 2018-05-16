//Matthew Trebing
//Program 7
//11/29/16
//This program demonstrates the use of MDI's
//and using listboxes to create a inventory list
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaitentMDI
{

    public partial class ParentForm : Form
    {
        private string practice_name;
        Insert Insert_form = new Insert();
        ArrayList keeper = new ArrayList();
        BinaryFormatter BFT = new BinaryFormatter();
        About about = new About();

        public string File_Name;

        public ParentForm()
        {
            InitializeComponent();
        }

        //One Event Handler to Open either the the Dental Clinic
        //or the Foot Clinic
        private void open_clinic_click(object sender,EventArgs e)
        {
           //sets the arguemnt sender as a item of toolstripmenu
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string tempfile;

            //If statement the will check the text of the item and select the correct 
            //practice to open their file.

            if(item.Text== "Dental Clinics")
            {
                practice_name = "Lake Dental Clinic";
            }
            else
            {
                practice_name = "Jinkins Foot Clinic";
            }
            
            //Will pass the array list keeper to the open file to fill it
            //with the data
            tempfile=open_file(keeper);

            //creates the child form and gives it the practice name and the array list
            Child_Form child = new Child_Form(practice_name, keeper);
            child.file_name = tempfile; 

            //sets the mdi parent to the main form
            child.MdiParent = this;

            //shows the child
            child.Show();
        }

        //Purpos:To open the files
        //Requires a array to fill values in 
        //Return: The open files 
        public string open_file(ArrayList keeper)
        {
            
            Records record;
            
            //Will check to see what the practice name 
            //to open up the correct file
            if (practice_name == "Lake Dental Clinic")
            {
                File_Name = "DentalList.inv";
            }
            else
            {
                File_Name = "FootClinic.inv";
            }
           
            //Creates a new filestream to open/create and read whats in the file
            FileStream file = new FileStream(File_Name, FileMode.OpenOrCreate, FileAccess.Read);

            //clears out the array list to refill after each reopening
            keeper.Clear();

            //While the file position is less then the length
            while (true)
            {
                try
                {
                    //you assign a record for each item in the file 
                    //and deseralizes it
                    record = (Records)BFT.Deserialize(file);
                    //adds the record to the keeper
                    keeper.Add(record);
                }
                catch (IOException)
                {
                    MessageBox.Show("Cannot close", "Cannot Close", MessageBoxButtons.OK);
                }
                
                catch(SerializationException)
                {
                    file.Close();
                    return File_Name;
                }
                catch(Exception)
                {
                    MessageBox.Show("File already opened", "File opened already", MessageBoxButtons.OK);
                }
            }
        }

        //Purpose: To Have one event handler to control multiple menu options
        //Requires: The correct click
        //Returns:Nothing
        private void menuChoice_Click(object sender, EventArgs e)
        {
            //Creates a item from the tool strip menu item
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            //creates a temp record
            Records temp;

            //Casts the active child form to the active child
            Child_Form active = (Child_Form)this.ActiveMdiChild;

            //If there is a active child
            //continue through the if statement
            if (active != null)
            {
                //shows the Insert form if Delete if not selected
                if (item.Text != "Delete")
                {
                    //shows the insert form dialog
                    Insert_form.ShowDialog();
                }
                //gets the record and sets it to temp
                temp = Insert_form.get_Record;

                //switch statement to control 
                //which item was selected
                switch (item.Text)
                {
                    //Will Insert the Record to the end of the 
                    //arrray list
                    case "Insert":
                    active.Insert_Record(temp);
                    break;

                    //Will Update the selected record
                    case "Update":
                    active.updatelistbox(temp);
                    break;

                    //Will delete the selected record
                    //also will confirm if you want to delete the selected
                    //record
                    case "Delete":
                    if(MessageBox.Show("Are you sure you want to Delete", "Confirm", 
                       MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                        {
                            active.deleteitem();
                        }
                                              
                    break;
                    default:
                    break;
                }
            }
        }

        //Purpose:Will Save the file 
        //requires: A file to save it to 
        //Returns: A Saved file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FileStream output;
            
            //will go through each child form and save them 
            foreach (Child_Form child in this.MdiChildren)
            {
                //Creates a output to save it to 
                //child.file_name selects the current selected child form 
                output = new FileStream(child.file_name, FileMode.OpenOrCreate, FileAccess.Write);

                //For each loop to serialize each item 
                //from the array list and add it to the output
                foreach (var item in child.getkeeper)
                {
                    BFT.Serialize(output, item);
                }

                //Closes the outputs
                output.Close();
            }
        }

        //Purpose: Closes the file if exit is selected
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.about_output();
            about.Show();
        }
    }
}

