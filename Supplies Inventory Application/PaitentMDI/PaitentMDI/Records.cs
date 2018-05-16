//Matthew Trebing
//11/29/16
//This is the record class file
//The code was given to the student 
//by Proffesor Stringfellow.
//The student updated it by adding in the the overloaded 
//to string method
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaitentMDI
{
   [Serializable]
    public class Records
    {
        
        public Records()
        {

        }
        public Records(int id,string name,int qtyReq,int quantiy)
        {
            ID = id;
            Name = name;
            QtyReq = qtyReq;
            Quantity = quantiy;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public double QtyReq { get; set; }
        public int Quantity { get; set;}
        

       //Purpose:: To ovveride the to string to add all the items as one line of code.
        public override string ToString()
        {

            string Id = Convert.ToString(ID);
            string name = Name;
            string qty = Convert.ToString(QtyReq);
            string qun = Convert.ToString(Quantity);
            string temp=String.Format("{0}{1}{2}{3}", Id.PadRight(32),name.PadRight(60),qty.PadRight(60),qun);
            return temp;
        }
    }
}
