//Matthew Trebing
//Oop Program 2
//Dr. Stringfellow
//October 1st, 2015

import java.text.DecimalFormat;
import java.util.*;

public class Robot implements Irobot
{
	private int x;
	private int y;
	boolean activeRobot = false;
	private int totaldistance;
	private ArrayList<Rock> rocklist;
	private String Log;
	public static DecimalFormat format = new DecimalFormat("0.00");

	//Robot Constructor
	public Robot(ArrayList<Rock> list)
	{
		x=0;
		y=0;
		totaldistance = 0;
		rocklist = list;
		Log ="";
	}
	
	//Robot Copy Constructor
	public Robot(Robot other ,ArrayList<Rock> list)
	{
		x=other.x;
		y=other.y;
		totaldistance = other.totaldistance;
		rocklist = list;
		Log = other.Log;
	}
	
	//Paramaterized Constructor
	public Robot(int newx, int newy , int newpickedup, int newtotal ,ArrayList<Rock> list)
	{
		x = newx;
		y = newy;
		totaldistance = newtotal;
		rocklist = list;
		Log = "";
	}
	
	public int getxrobot()
	{
		return x;
	}
	
	public void setxrobot(int value)
	{
		x= value;
	}
	
	public int getyrobot()
	{
		return y;
	}
	
	public void setyrobot(int value)
	{
		y = value;
	}
	
	public boolean Roboton()
	{
		return activeRobot=true;
	}
	
	public boolean Robotoff()
	{
		return activeRobot = false;
	}
	
	public void adddistance(double distance)
	{
		//Totaldistance = totaldistance + distance
		totaldistance += distance;
	}
	
	public double totaldistance()
	{
		return totaldistance;
	}
	
	public double distance(Rock rock)
	{	
		//This is the distance Formula
		return Math.sqrt(Math.pow(rock.getxcoord() - x,2)+Math.pow(rock.getycoord() - y,2));
	}
	
	public Rock findclosestrock()

	{
		//Sets distance to a high initial value to 
		//make sure the distance does not equal a array 
		//value by chance
		double distance = 99999999;
		
		Rock rock = null;
		
		//This is a for each loop 
		//The for each loop will keep running
		//for everything in the rocklist
		for (Rock drock :  rocklist )
		{
			//this will only run if the rock is not picked up and 
			//the distance of the rock is not less then the last distance
			if(!drock.isPickedup() && distance(drock) < distance)
			{
				//sets the distance of the last rock to the new distance
				distance = distance(drock);
				rock = drock;
			}
		}
			return rock;
	}

	public void pickupnumrock(int number)
	{
		Rock rock = null;
		for(int i=0; i < number; i++)
		{
			rock = findclosestrock();
			rock.changePickedup();
			Log += "\t"+rock.getrockposition()+"\t"+"      ("+rock.getxcoord()+","+rock.getycoord()+")"+"\t"+"\t"+format.format(distance(rock))+"\n";
			totaldistance+=distance(rock);
			x = rock.getxcoord();
			y = rock.getycoord();
		}
			Log = Log.replaceAll("\n", System.lineSeparator());
	}
	
	public String getLog()
	{
		return Log;
	}
}