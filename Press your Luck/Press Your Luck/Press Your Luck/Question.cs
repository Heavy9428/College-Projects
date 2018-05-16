//Matthew Trebing and Mackey Divine
//10/6/2016
//Contemporary Programming
//This is the Question Class it will retrive the 
//question and answer keys in a dictonary and 
//return it to main to be processed during
//a trivia game

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Press_Your_Luck
{
    class Question
    {
        //Sets up the dictonary to hold two strings
        private Dictionary<string, string> questNAns = new Dictionary<string, string>();

        //Looks for the luckfile in the debug folder
        System.IO.StreamReader file = new System.IO.StreamReader(@"luckfile.txt");
        

        public Question()
        {
            string line, line2;

            line = file.ReadLine();
            //try and catch to see if the file can be found
            try
            {
                while (line != null) // Read the file and display it line by line.
                {
                    line2 = file.ReadLine();

                    if (!questNAns.ContainsKey(line))
                        questNAns.Add(line, line2);

                    line = file.ReadLine();
                }
            }
            catch(InvalidCastException)
            {
                MessageBox.Show("Unable to open file", "ERROR", MessageBoxButtons.OK);
            }


        }

        //This will return the Question and Answer
        //string when called in the main form 
        public Dictionary<string, string> Provide_Dictionary()
        {
            return questNAns;
        }

    }

}

