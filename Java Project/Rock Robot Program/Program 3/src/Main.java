//Matthew Trebing
//Oop Program 3
//Dr. Stringfellow
//October 26th, 2015
//This program uses a array to hold multiple rocks
//and then calculates the minimum distance between 
//a robot and another rock, then it will calculate the
//new minimum distance between the robot and a new closest rock after
//the robot picks up the previous rock as well as taking random temps
//from random locations on Mars

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
		RockRobot robot = new RockRobot(rocklist);
		TempRobot robot2 = new TempRobot();
	
		BufferedReader in = null;
		
		String Filename = Readinput();
		
		try 
		{
			in = new BufferedReader(new FileReader(Filename));
			
			PrintHeading();
			turnon(robot, robot2);
			
			for(int l=0; l <=2; l++)
			{
			// all my rocks from the file have been added to the array
			rocklist = addRocks(in, rocklist); 			
			attainRocks(robot, rocklist,l);
			attainTemp(robot2);
			}
			
			Robotlogs(robot);
			Templogs(robot2);
			turnoff(robot, robot2);
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
	
	
	//This will print out my heading file to the screen and
	//to the out file that was created in setOutput
	public static void PrintHeading()
	{
		System.out.println("Matthew Trebing");
		System.out.println("Dr. Stringfellow");
		System.out.println("OOP Program 3\n");
	}
	
	//This function turns on the Robot
	public static void turnon(RockRobot robot, TempRobot robot2)
	{
		System.out.println("Turning on the Robot's to start the mission\n");	
		robot.Roboton();
		robot2.Roboton();
	}
	
	//This function will read in the integers of two values in the in file
	//and then set it to a rock and set it's x and y integers and
	//then add that to a array list, this function uses a try and catch 
	//to make sure the file is converted correctly or if it was unable
	//to get any information from the file
	public static ArrayList<Rock> addRocks
	(BufferedReader in, ArrayList<Rock> rocklist)
	{
		String s = null;
		Rock rock = null;
		try 
		{
			// will keep going until you hit the end of file
			while ((s = in.readLine()) != null) 
			{
			  StringTokenizer t = new StringTokenizer(s);
			  int x = Integer.parseInt(t.nextToken());
			  int y = Integer.parseInt(t.nextToken());
			  
			 //creates a new rock and then
			 //sets its x and y before adding it 
			 //to the rock list
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
	
	//This function will attain the rocks from the rock list.
	public static void attainRocks(RockRobot Rockrobot, 
									ArrayList<Rock> rocklist, int l)
	{
		int x = 0;
		int y = 0;
		Rockrobot.setxrobot(x);
		Rockrobot.setyrobot(y);
		Rockrobot.pickupnumrock(l);
	}	
	
	//This function will take and then receive the temp of 
	//random spot's on mars
	public static void attainTemp(TempRobot robot2)
	{	
		robot2.takeTemp();	
	}	
	
	//Prints out the robot's "log" and then prints it to the screen 
	//and to the out file
	public static void Robotlogs(Robot robot)
	{	
		System.out.println("                          ROCKROBOT");
		System.out.println("Direction"+"\tRocks Collected"
							+ "\t    Position"+ "\t Distance (in Miles)");
		System.out.format(robot.getLog());
		System.out.println();
		System.out.println("Total distance covered: "
							+robot.totaldistance()+" miles");
	}
	
	//Prints out the robot's "log" and then prints it to the screen 
	//and to the out file
	public static void Templogs(Robot robot2)
	{
		System.out.println();
		System.out.println("                           TEMPROBOT");
		System.out.println("Direction"+"\tTempreture"+ "\tPosition"
							+ "\tDistance (in Miles)");
		System.out.println(robot2.getLog());
		System.out.println("Total distance covered: "
							+robot2.totaldistance()+" miles"+'\n');
	}
	
	//This function turns off the robot
	public static void turnoff(RockRobot robot, TempRobot robot2)
	{
		System.out.println("Mission Complete, turning off");
		robot.Robotoff();
		robot2.Robotoff();
	}
}