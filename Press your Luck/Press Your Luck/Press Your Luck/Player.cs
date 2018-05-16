//Matthew Trebing and Mackey Divine
//10/6/2016
//Contemporary Programming
//This is the player class 
//it will hold the values for the players in the main class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Press_Your_Luck
{

    class Player
    {
        private int Money;
        private int Earned_Spins;
        private int Passed_Spins;
        private string name;
        

        //Constructor to initilize the values
        //to zero
        public Player()
        {

            Passed_Spins = 0;
            Earned_Spins = 0;
            Money = 0;
        }

        //Multiple gets and sets for the player's Earned and 
        //Passed Spins. Thier name and how much casy they made
        public int Espins
        {
            get
            {
                return Earned_Spins;
            }
            set
            {
                this.Earned_Spins = value < 0 ? this.Earned_Spins:value;
            }
        }
        public int pSpins
        {
            get
            {
                return Passed_Spins;
            }
            set
            {
                this.Passed_Spins = value < 0?this.Passed_Spins:value;
            }
        }
        public string pName
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }


        public int cash
        {
            get
            {
                return Money;
            }
            set
            {
                this.Money = value < 0 ? this.Money : value;
            }
        }





    }
}
