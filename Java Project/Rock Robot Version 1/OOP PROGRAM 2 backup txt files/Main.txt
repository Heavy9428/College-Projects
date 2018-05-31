//Matthew Trebing
//Oop Program 2
//Dr. Stringfellow
//October 1st, 2015
//This program uses a array to hold multiple rocks
//and then calculates the minimum distance between 
//a robot and another rock, then it will calculate the
//new minimum distance between the robot and a new closest rock after
//the robot picks up the previous rock.

import java.io.*;
import java.text.*;
import java.util.*;
import javax.swing.*;

public class Main 
{	
	public static DecimalFormat format = new DecimalFormat("0.00");
	
	public static void main(String[] args) 
	{
		ArrayList<Rock> rocklist = new ArrayList<Rock>();
		Robot robot = new Robot(rocklist);
		Scanner input = new Scanner(System.in);
		BufferedReader in = null;
		
		String Filename = Readinput();
		
		try 
		{
			in = new BufferedReader(new FileReader(Filename));
			
			String outfilename = setOutput(input);
			PrintWriter outfile = new PrintWriter(outfilename);
			PrintHeading(outfile);
			
			rocklist = addRocks(in, rocklist); // all my rocks from the file have been added to the array
			attainRocks(robot, input, rocklist, outfile);
			Robotlogs(robot, outfile);
			in.close();
			outfile.close();
		}
		
		catch (IOException e) 
		{
			e.printStackTrace();
			System.out.println("unable to open");
		}	
	}
	
	//This will read a string and set the string file name 
	//as the input file
	public static String Readinput()
	{
		String inFile = JOptionPane.showInputDialog("Please "
			+ "enter the input file. If nothing is entered, "
            + " the default input file will be used: 'InFile.txt'\n");
		
		return inFile;
	}
	
	//This will set up your output and create it if needed
	public static String setOutput(Scanner in)
	{
		System.out.println("Please enter in the outfile name");
			String output = in.next();
			return output;
	}
	
	//This will print out my heading file to the screen and
	//to the out file that was created in setOutput
	public static void PrintHeading(PrintWriter outfile)
	{
		System.out.println("Matthew Trebing");
		outfile.println("Matthew Trebing");
		System.out.println("Dr. Stringfellow");
		outfile.println("Dr. Stringfellow");
		System.out.println("OOP Program 2\n");
		outfile.println("OOp Program 2\n");
		outfile.println("\n");
	}
	//This function will read in the integers of two values in the in file
	//and then set it to a rock and set it's x and y integers and
	//then add that to a array list, this function uses a try and catch 
	//to make sure the file is converted correctly or if it was unable
	//to get any information from the file
	public static ArrayList<Rock> addRocks(BufferedReader in, ArrayList<Rock> rocklist)
	{
		String s = null;
		Rock rock = null;
		try 
		{
			while ((s = in.readLine()) != null) // will keep going until you hit the end of file
			{
			  StringTokenizer t = new StringTokenizer(s);
			  int x = Integer.parseInt(t.nextToken());
			  int y = Integer.parseInt(t.nextToken());
			  
			 //creates a new rock and then
			 //sets its x and y before adding it 
			 //to the rocklist
			 rock = new Rock(x,y);
			 rock.setxcoord(x); 
			 rock.setycoord(y); 
			  
			 rocklist.add(rock);
			}
		} 
		catch (NumberFormatException e)
		{
			e.printStackTrace();
			System.out.println("couldnt convert string to int");
		}
		catch (IOException e)
		{
			e.printStackTrace();
			System.out.println("couldnt get line from file");
		}
		return rocklist;
	}
	
	//This function will have the robot attain the rocks from the array list.
	//By first turning on the robot and asking the user if the would like 
	//to set their own parameters for the robot or if they would like to use the default
	//values of (0,0) for the robot's starting position
	public static void attainRocks(Robot robot , Scanner in, ArrayList<Rock> rocklist, PrintWriter outfile)
	{
		
		char a = 'j';
		int x = 0;
		int y = 0;
		int rockamount = 0;
		
		System.out.println("Turning on Robot to start mission\n");
		
		//This turns on the robot
		robot.Roboton();
		
		System.out.println("Would you like to tell the robot where to start and how many rocks to pick up?");
		System.out.println("Type in a Y for Yes or a N for No");
		
		//Read in the character entered from the user
		a = in.next().charAt(0);
		
		//Will keep looping unless the user enters in a Y for yes 
		//or a N for a no
		while ((a != 'Y')&& (a !='y') && (a !='N') && (a !='n'))
		{
				System.out.println("Enter in a Y or a N");
				a = in.next().charAt(0);
		}
		
		//Will only execute if the character value entered in from the user is a Y or y
		if (( a =='Y') || a =='y')
		{
			System.out.println("Where whould you like to set the Robot X quardinet?");
			x = in.nextInt();
			robot.setxrobot(x); //Sets the x coord to a user defined coord
			outfile.println("You set the robot's x value to " + x + '\n');
			System.out.println("Where whould you like to set the Robot Y quardinet?");
			y = in.nextInt();
			robot.setyrobot(y); //Sets the y coord to a user defined coord
			outfile.println("You set the robot's y value to " + y + '\n');
			System.out.println("How many rocks would you like to pick up?");
			rockamount = in.nextInt(); //This will set the amount of rocks to pick up 
									  //from a user defined number
			
			outfile.println("You asked the robot to pick up " + rockamount + " Rocks\n");
			outfile.println('\n');
			
			//Checks to see if the user enters in a number that is bigger then the 
			//size of the array
			if(rockamount > rocklist.size())
			{
				System.out.println("There are only " + rocklist.size() + " rocks avaliabe to be picked up.\n");
				outfile.println("There are only " + rocklist.size() + " rocks avaliabe to be picked up.\n");
				outfile.println('\n');
				System.out.println("The robot will now pickup all avaliable rocks");
				robot.pickupnumrock(rocklist.size()); //If the user sets the value of the rock amount 
													 //to a number that is higher then the size of the array 
													//it will set the amount to pick up to the size of the array 
			}
			else
			{
				robot.pickupnumrock(rockamount); //As long as the amount given by the user is smaller or 
												//equal to the number in the array the robot will execute 
											   //the pick up num rock function in robot.
			}	
		}
		
		//If the user selects no then the robot will use the default values of (0,0)
		//and pick up the full amount in the array
		else if ((a=='N') || (a=='n'))
		{
			System.out.println("Normal paramaters were selected");
			robot.setxrobot(x);
			robot.setyrobot(y);
			robot.pickupnumrock(rocklist.size());
		}
		
		System.out.println("The robot has achived it's mission, powering off");
		robot.Robotoff(); //Turns the robot off
	}	
	
	//Prints out the robot's "log" and then prints it both to the screen 
	//and to the outfile
	public static void Robotlogs(Robot robot, PrintWriter outfile)
	{	
		System.out.println("Rocks Collected"+ "\t    Position"+ "\t Distance (in Miles)");
		outfile.println("Rocks Collected"+ "\t    Position"+ "\t Distance (in Miles)\n");
		System.out.format(robot.getLog());
		outfile.println(robot.getLog());
		System.out.println("Total distance covered: "+robot.totaldistance()+" miles");
		outfile.println("Total distance covered: "+robot.totaldistance()+" miles\n");
	}
}