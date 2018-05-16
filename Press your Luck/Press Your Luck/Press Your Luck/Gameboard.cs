//Matthew Trebing and Mackey Divine
//10/6/2016
//Contemporary Programming
//This is the main form where the flow of the game is 
//handled. It calls the other classes that is holding the 
//information for the questions and the players.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Press_Your_Luck
{
    public partial class Gameboard : Form
    {
        private int a, b, c, x = 0;
        private int round2;
        private const int NUM_BOXES = 18;

        private Question q = new Question();
        private Random random = new Random();
        private Player p1 = new Player();
        private Player p2 = new Player();
        private Player p3 = new Player();
        private Dictionary<string, string> getQuestions;
        private KeyValuePair<string, string> quesAns;
        private string filemoney, answer, useranswer;
        private const string Spin_Music = @"SpinBoard.wav";
        private SoundPlayer spinsound = new SoundPlayer(Spin_Music);
        PictureBox[] pictureBox = new PictureBox[NUM_BOXES];

        public Gameboard()
        {

            InitializeComponent();
            hideComponents(); //Hides the Components
            beginagain(); // sets everything to zero if needed
            randomize(); // randomizes the board
            getQuestions = q.Provide_Dictionary(); //provides the dictonary from the Question Class 
            Boarder_Box.BackColor = Color.Transparent; // allows you to see behind the boarder box
            Boarder_Box.Parent = pictureBox[1]; // sets boarder box to picturebox location 0
        }

        //Purpose: When Clicked it will output the instructions for the game
        //and show and hide any components that is needed
        //Requires: Nothing
        //Returns: Nothing
        private void Play_Button_Click(object sender, EventArgs e)
        {
            Question_Box.Show();
            Question_Box.Font = new Font("Arial", 15, FontStyle.Regular);
            Question_Box.AppendText(string.Format("Welcome to the Press Your Luck Game!"));
            Question_Box.AppendText(string.Format(" This is a Game Played with Three Players!"));
            Question_Box.AppendText(string.Format(" You will first answer four trivia questions."));
            Question_Box.AppendText(string.Format(" After that starting with player."));
            Question_Box.AppendText(string.Format(" earn money"));
            Question_Box.AppendText(string.Format(" by spinning a randomly moving board."));
            Question_Box.AppendText(string.Format(" Watch out though hit a whammy and lose it all."));
            Question_Box.AppendText(string.Format("Once all names are entered please"));
            Question_Box.AppendText(string.Format(" hit Start Game to continue!\n"));
            Question_Box.AppendText(string.Format("Now, will you please enter in your name's"));
            Play_Button.Hide();
            Set_Name.Show();
            Player1_textBox.Show();
            playertwo_TextBox.Show();
            Playerthree_textBox.Show();
            Playerthree_label.Show();
            Playertwo_Label.Show();
            Playerone_Label.Show();

        }

        //Purpose: When Clicked it set the names for the three players
        //and will check to see if all three boxes have names in them
        //Requires: Nothing
        //Returns: Nothing
        private void Set_Name_Click(object sender, EventArgs e)
        {
            {
                Playeronename.Clear();
                playertwoname.Clear();
                Playerthreename.Clear();

                //Conditional Statement to check and see if the enter three names into the text box
                if (Player1_textBox.Text == "" || playertwo_TextBox.Text == "" ||
                    Playerthree_textBox.Text == "")
                {
                    MessageBox.Show("Must enter a name for all Players", 
                                    "Missing a Name or Names!", MessageBoxButtons.OK);
                }
                else
                {
                    p1.pName = Player1_textBox.Text; //sets name for player one
                    Playeronename.AppendText(p1.pName);//outputs name for player one


                    p2.pName = playertwo_TextBox.Text; //sets name for player two
                    playertwoname.AppendText(p2.pName);//outputs name for player two


                    p3.pName = Playerthree_textBox.Text; //sets name for player three
                    Playerthreename.AppendText(p3.pName);//outputs name for player three

                    //Hides Boxes and labels that are no longer needed
                    Set_Name.Hide();
                    Player1_textBox.Hide();
                    playertwo_TextBox.Hide();
                    Playerthree_textBox.Hide();
                    Playerthree_label.Hide();
                    Playertwo_Label.Hide();
                    Playerone_Label.Hide();
                    rounds(); //calls the round function to begin round one
                }
            }
        }

        //Purpose: When clicked it will a bool value and call
        //check question to see if the answer is correct or not
        //then calls current player to output if they were wrong or not
        //Requires: A boolian value and the current player
        //Returns:Nothing for the button
        private void Answer_Button_Click_1(object sender, EventArgs e)
        {
            if (c <= 11)
            {
                bool a = checkQuestion();

                if (c == 0 || c == 3 || c == 6 || c == 9)
                {
                    if (a == true)
                    {
                        p1.Espins++;
                        PlayeroneEspincount.Clear();
                        PlayeroneEspincount.AppendText(Convert.ToString(p1.Espins));
                        Question_Box.AppendText("\n\n\n");
                        Question_Box.AppendText(p2.pName + " it is your turn");
                    }
                    else
                    {
                        Question_Box.AppendText("\n\n\n");
                        Question_Box.AppendText(p2.pName + " it is your turn");
                    }
                    c++;
                }
                else if (c == 1 || c == 4 || c == 7 || c == 10)
                {
                    if (a == true)
                    {
                        p2.Espins++;
                        PlayertwoEspincount.Clear();
                        PlayertwoEspincount.AppendText(Convert.ToString(p2.Espins));
                        Question_Box.AppendText("\n\n\n");
                        Question_Box.AppendText(p3.pName + " it is your turn");
                    }
                    else
                    {
                        Question_Box.AppendText("\n\n\n");
                        Question_Box.AppendText(p3.pName + " it is your turn");
                    }
                    c++;
                }
                else
                {
                    if (a == true)
                    {
                        p3.Espins++;
                        PlayerthreeEspincount.Clear();
                        PlayerthreeEspincount.AppendText(Convert.ToString(p3.Espins));
                        Question_Box.AppendText("\n\n\n");
                        Question_Box.AppendText(p1.pName + " it is your turn");
                    }
                    else
                    {
                        Question_Box.AppendText("\n\n\n");
                        Question_Box.AppendText(p1.pName + " it is your turn");
                    }

                    if (c == 11)
                    {
                        Answer_Button.Hide();
                        Next_Question_Button.Hide();
                        Answers_Textbox.Hide();
                        Spin_Round_Instruction.Show();
                    }
                    c++;
                }
            }
        }

        //Purpose:When clicked it will get the next question from the 
        //dictionary and output it to the screen
        //Requires: A file to have been opened and a dictonary to have been filled
        //Reutns:Nothing
        private void Next_Question_Button_Click_1(object sender, EventArgs e)
        {
            Question_Box.Clear();
            Answers_Textbox.Clear();
            quesAns = getQuestions.ElementAt<KeyValuePair<string, string>>(random.Next(0, 74));
            Question_Box.AppendText(quesAns.Key);
            Answer_Button.Show();
        }

        //Purpose:When clicked it will show the Instructions 
        //for how to proceed during the spin round
        //Requires:Nothing
        //Returns::Nothing
        private void Spin_Round_Instruction_Click(object sender, EventArgs e)
        {
            spinInstructions();//goes to the spin instruction
            Begin_Spin_Round.Show();
            Spin_Round_Instruction.Hide();

        }

        //Purpose: To remove the Question_Box that currently has the 
        //Spin instructions
        //Requires:Nothing
        //Returns:Nothing
        private void Begin_Spin_Round_Click(object sender, EventArgs e)
        {
            Question_Box.Hide();
            SpinButton.Show();
            Begin_Spin_Round.Hide();
            Boarder_Box.Show();
            Quit_Button.Show();
            checkSpin(); //checks to see who goes first
        }

        //Purpose:To spin the board and see if the player is awarded
        //and cash
        //Requires:At least one player has a spin
        //Returns::Nothing
        private void SpinButton_Click(object sender, EventArgs e)
        {
            //checks to see if all the players have finished spinning
            if (p1.Espins == 0 && p2.Espins == 0 && p3.Espins == 0)
            {
                MessageBox.Show("No one has any spins left", "Spin", MessageBoxButtons.OK);
                SpinButton.Hide();
                if (round2 == 0)
                {
                    Next_Round_button.Show(); // goes to the next round
                    round2++;//icrements it by one so it is unable 
                }
                else
                {
                    displayWinners(); // if two rounds played it goes to the winner function
                }
            }

            //if the players have spins 
            else
            {
                Question_Box.Hide();
                Boarder_Box.Show();
                playerSpins(); //process the spins
            }
        }


        //Purpose:To begin the next round
        //Requires :Nothing
        //Returns : Nothing
        private void Next_Round_button_Click(object sender, EventArgs e)
        {
            Question_Box.Show();
            Next_Round_button.Hide();
            c = 0; // resets c to 0 for player questions
            rounds();
        }

        //Purpose: To close the game
        //Requires: Nothing
        //Returns:Nothing
        private void Quit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Purpose: To close the game when asked if they want to play
        //another round
        //Requires: Nothing
        //Returns:Nothing
        private void No_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Purpose:To see if the Player would like to play another game
        //Requires: Nothing
        //Returns:Nothing
        private void Yes_Button_Click(object sender, EventArgs e)
        {
            beginagain();
            Yes_Button.Hide();
            No_Button.Hide();
            rounds();
        }
        //Below are the various functions used that are implemented in 
        //the buttons listed above.

        //Purpose: To Hide all Components that are not 
        //needed at the begining of the game
        //Requires:Nothing
        //Returns;Nothing
        private void hideComponents()
        {
            Question_Box.Hide();
            Boarder_Box.Hide();
            Answers_Textbox.Hide();
            Answer_Button.Hide();
            Start_Button.Hide();
            Next_Question_Button.Hide();
            SpinButton.Hide();
            Begin_Spin_Round.Hide();
            Spin_Round_Instruction.Hide();
            Set_Name.Hide();
            Player1_textBox.Hide();
            playertwo_TextBox.Hide();
            Playerthree_textBox.Hide();
            Playerthree_label.Hide();
            Playertwo_Label.Hide();
            Playerone_Label.Hide();
            Yes_Button.Hide();
            No_Button.Hide();
            Next_Round_button.Hide();
            Quit_Button.Hide();
        }

        //Purpose:To randomize the board at the start
        //and when the player is spinning the board
        private void randomize()
        {
            pictureBox[0] = pictureBox1;
            pictureBox[1] = pictureBox2;
            pictureBox[2] = pictureBox3;
            pictureBox[3] = pictureBox4;
            pictureBox[4] = pictureBox5;
            pictureBox[5] = pictureBox6;
            pictureBox[6] = pictureBox7;
            pictureBox[7] = pictureBox8;
            pictureBox[8] = pictureBox9;
            pictureBox[9] = pictureBox10;
            pictureBox[10] = pictureBox11;
            pictureBox[11] = pictureBox12;
            pictureBox[12] = pictureBox13;
            pictureBox[13] = pictureBox14;
            pictureBox[14] = pictureBox15;
            pictureBox[15] = pictureBox16;
            pictureBox[16] = pictureBox17;
            pictureBox[17] = pictureBox18;

            //gets first random
            int index1 = random.Next(0, 30);
            for (int index2 = 0; index2 < NUM_BOXES; ++index2)
            {
                //Slows down the spinning so the player can watch
                System.Threading.Thread.Sleep((3));
                //Sets a random image to a random picturebox from the array
                pictureBox[index2].Image = imageList1.Images[index1];
                //gets next random
                index1 = random.Next(0, 30);
            }
        }

        //Purpose: Begins the rounds and gets the first question and tells
        //Player one to go first
        //Requires: Nothing
        //Retuns: Nothing
        private void rounds()
        {
            int index = random.Next(0, 74); //Finds a randon number for the question
            Answer_Button.Show();
            Question_Box.Clear();
            Answers_Textbox.Show();
            //Conditional loop that tells player one they answer first
            while (x < 1)
            {
                Question_Box.AppendText(p1.pName + " you are up first!");
                Question_Box.AppendText("\n\n");
                x += 2;
            }
            //Gets the Question and answer
            quesAns = getQuestions.ElementAt<KeyValuePair<string, string>>(index);
            Question_Box.AppendText(quesAns.Key);
            x = 0;//used to reset the loop back to 0 for the next round
        }

        //Purpose: To check and see if the answer is correct or not
        //Requires:The answer key, and a boolean value preset to false
        //Retuns: True or false 
        private bool checkQuestion()
        {
            //recives the typed in answer from the answer_box 
            //and will allow it to be typed in using any form or string
            useranswer = Answers_Textbox.Text.ToUpper();
            //sets the answer key to answer
            answer = quesAns.Value.ToUpper();

            //Conditional statement to tell the user
            //if the answer is correct or not
            if (useranswer == answer)
            {
                Question_Box.Clear();
                Question_Box.AppendText("You are Correct!");
                Answer_Button.Hide();
                Next_Question_Button.Show();
                return true;
            }
            else
                Question_Box.Clear();
            Question_Box.AppendText("That is Incorrect! ");
            Question_Box.AppendText("The correct answer was " + quesAns.Value);
            Answer_Button.Hide();
            Next_Question_Button.Show();
            return false;
        }

        //Purpose::To output the Spin instructions to the screen
        //Requires Nothing
        //returns: Nothing
        private void spinInstructions()
        {
            Question_Box.Clear();
            Question_Box.Font = new Font("Arial", 15, FontStyle.Regular);
            Question_Box.AppendText(string.Format("We will now begin the Spin Round! "));
            Question_Box.AppendText(string.Format("Starting with "+ p1.pName + " each player will"));
            Question_Box.AppendText(string.Format(" take turns earning cash by spinning the board"));
            Question_Box.AppendText(string.Format(" Each time you land on a whammy,"));
            Question_Box.AppendText(string.Format(" you lose ALL of your money. "));
            Question_Box.AppendText(string.Format(" Press the Start Spinner to begin "));
        }

        //Purpose to see who spins first
        //Requires:Nothing
        //Returns:Nothing
        private void checkSpin()
        {
            if (p1.Espins != 0)
            {
                MessageBox.Show(p1.pName + " time to spin", "Spin", MessageBoxButtons.OK);
            }
            else if (p2.Espins != 0)
            {
                MessageBox.Show(p2.pName + " time to spin", "Spin", MessageBoxButtons.OK);
            }
            else if (p3.Espins != 0)
            {
                MessageBox.Show(p3.pName + " time to spin", "Spin", MessageBoxButtons.OK);
            }
        }

        //Purpose: to process the spins for each player
        //Recuires: a player
        //Returns:Nothing
        private void playerSpins()
        {
            if (p1.Espins != 0)
            {
                changePlaces(p1);
                if (p1.Espins == 0 && p2.Espins != 0)
                {
                    MessageBox.Show(p2.pName + " time to spin", "Spin", MessageBoxButtons.OK);
                }
            }
            else if (p2.Espins != 0)
            {
                changePlaces(p2);
                if (p2.Espins == 0 && p3.Espins != 0)
                {
                    MessageBox.Show(p3.pName + " time to spin", "Spin", MessageBoxButtons.OK);
                }
            }
            else if (p3.Espins != 0)
            {
                changePlaces(p3);
            }
            else
            {
                MessageBox.Show("No one has any spins", "Spin", MessageBoxButtons.OK);
            }
        }

        //Purpose to process the spins for the current player
        //requires:the current player, spins
        //returns:cash value to their respective textbox
        private void changePlaces(Player play)
        {
            int i = 0; // will reset the do while loop for each
                       //new spin 
            spinsound.PlayLooping();
            do
            {
                
                int r = random.Next(0, 18);
                randomize(); // randomizes the board
                Boarder_Box.Parent = pictureBox[r];//setting the boarder box to a random picbox
                this.Refresh(); //refreshes the form to show where the boarder is located
                pictureBox[r].Image = imageList1.Images[r]; // finds the correct image 
                filemoney = imageList1.Images.Keys[r]; // sets the image to the path
                i++;
            } while (i < 25);
            spinsound.Stop();//stops the sound

            //Purpose: checks to see if the file image is a whammy or not
            //if it is then it sets the current players cash to zero
            //and out puts it to their respective cash box
            //Requies: A current image file, a current player, and spins
            //returns: The cash value for the player
            if ((filemoney == "Whammy.png") || (filemoney == "whammy1.png")||(filemoney=="Wham.png")||
                (filemoney == "Whammy2.pgn")|| (filemoney=="wham1.png"))
            {
                a = 0;
                b = 0;
                if (play == p1)
                {
                    Playeronecash.Clear();
                    Playeronecash.AppendText(Convert.ToString("$ "+ a));
                    p1.Espins--;
                    PlayeroneEspincount.Clear();
                    PlayeroneEspincount.AppendText(Convert.ToString(p1.Espins));
                    p1.cash = a;
                }
                else if (play == p2)
                {
                    Playertwocash.Clear();
                    Playertwocash.AppendText(Convert.ToString("$ " + a));
                    p2.Espins--;
                    PlayertwoEspincount.Clear();
                    PlayertwoEspincount.AppendText(Convert.ToString(p2.Espins));
                    p2.cash = a;
                }
                else
                {
                    Playerthreecash.Clear();
                    Playerthreecash.AppendText(Convert.ToString("$ " + a));
                    p3.Espins--;
                    PlayerthreeEspincount.Clear();
                    PlayerthreeEspincount.AppendText(Convert.ToString(p3.Espins));
                    p3.cash = a;
                }
            }
            else
            {
                if (play == p1)
                {
                    Playeronecash.Clear();
                    p1.Espins--;
                    PlayeroneEspincount.Clear();
                    PlayeroneEspincount.AppendText(Convert.ToString(p1.Espins));
                    b = calculateMoney(a, p1);
                    Playeronecash.AppendText(("$ " + Convert.ToString(b)));
                    p1.cash = b; //sets cash to compare winnner later
                }
                else if (play == p2)
                {
                    Playertwocash.Clear();
                    p2.Espins--;
                    PlayertwoEspincount.Clear();
                    PlayertwoEspincount.AppendText(Convert.ToString(p2.Espins));
                    b = calculateMoney(a, p2);
                    Playertwocash.AppendText(("$ " + Convert.ToString(b)));
                    p2.cash = b;//sets the cash to compare it to the winner later
                }
                else if (play == p3)
                {
                    Playerthreecash.Clear();
                    p3.Espins--;
                    PlayerthreeEspincount.Clear();
                    PlayerthreeEspincount.AppendText(Convert.ToString(p3.Espins));
                    b = calculateMoney(a, p3);
                    Playerthreecash.AppendText(("$ " + Convert.ToString(b)));
                    p3.cash = b;//sets the cash to compare it to the winner later
                }
            }
        }

        //Purpose: to convert the file name into a integer value
        //requires a int to set it to and the current player
        //Returns the current players cash
        private int calculateMoney(int a, Player player)
        {
            a = Convert.ToInt32(Path.GetFileNameWithoutExtension(filemoney));
            player.cash += a;
            return player.cash;
        }

        //Purpose:to Display the winners and ask if the players
        //would like to play again 
        //Requires:the players current cash from the player class
        //Returns:Nothing
        private void displayWinners()
        {
            Question_Box.Show();
            Question_Box.Clear();

            //Conditional statements to see who has the most cash
            if (p1.cash > p2.cash && p1.cash > p3.cash)
            {
                Question_Box.AppendText(p1.pName + " is the winner! With $" + p1.cash + "\n");
                Question_Box.AppendText("Would you like to play another game?");
            }
            else if (p2.cash > p1.cash && p2.cash > p3.cash)
            {
                Question_Box.AppendText(p2.pName + " is the winner! With $" + p2.cash + "\n");
                Question_Box.AppendText("Would you like to play another game?");
            }
            else if (p3.cash > p1.cash && p3.cash > p2.cash)
            {
                Question_Box.AppendText(p3.pName + " is the winner! With $" + p3.cash + "\n");
                Question_Box.AppendText("Would you like to play another game?");
            }
            else
            {
                Question_Box.AppendText(p1.pName + " " + p2.pName + " " + p3.pName + 
                                        " Looks like no one won!\n");
                Question_Box.AppendText("Would you like to play another game?");
            }
            Yes_Button.Show();
            No_Button.Show();
        }

        //Purpose:To reset all values back to zero
        //Requires: Nothing
        //Returns :Nothing
        private void beginagain()
        {
            p1.cash = 0;
            p2.cash = 0;
            p3.cash = 0;
            c = 0;

            PlayeroneEspincount.Clear();
            PlayertwoEspincount.Clear();
            PlayerthreeEspincount.Clear();
            Playeronecash.Clear();
            Playertwocash.Clear();
            Playerthreecash.Clear();

            PlayeroneEspincount.AppendText(string.Format(Convert.ToString(p1.Espins)));
            PlayertwoEspincount.AppendText(string.Format(Convert.ToString(p2.Espins)));
            PlayerthreeEspincount.AppendText(string.Format(Convert.ToString(p3.Espins)));
            PlayeronePspincount.AppendText(string.Format(Convert.ToString(p1.pSpins)));
            PlayertwoPspincount.AppendText(string.Format(Convert.ToString(p2.pSpins)));
            PlayerthreePspincount.AppendText(string.Format(Convert.ToString(p3.pSpins)));
            Playeronecash.AppendText("$" + Convert.ToString(p1.cash));
            Playertwocash.AppendText("$" + Convert.ToString(p2.cash));
            Playerthreecash.AppendText("$" + Convert.ToString(p3.cash));
        }
    }
}
