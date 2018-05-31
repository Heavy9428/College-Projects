//Matthew Trebing
//Oop Program 3
//Dr. Stringfellow
//October 26th, 2015

import java.text.DecimalFormat;
import java.util.*;

public abstract class Robot 
{
	
	private int x;
	private int y;
	private boolean activeRobot;
	private int totaldistance;
	private ArrayList<Rock> rocklist;
	private String Log;
	public static DecimalFormat format = new DecimalFormat("0.00");

	public Robot()
	{
		setX(0);
		setY(0);
		totaldistance = 0;
		Log ="";
		activeRobot = false;
	}
	
	public Robot(Robot other)
	{
		setX(other.getX());
		setY(other.getY());
		totaldistance = other.totaldistance;
		Log = other.Log;
		activeRobot = false;
	}
	
	public Robot(int newx,int newy, int newtotal)
	{
		setX(newx);
		setY(newy);
		totaldistance=newtotal;
		Log="";
		activeRobot = false;
	}
	
	public int getxrobot()
	{
		return getX();
	}
	
	public void setxrobot(int value)
	{
		setX(value);
	}
	
	public int getyrobot()
	{
		return getY();
	}
	
	public void setyrobot(int value)
	{
		setY(value);
	}
	
	protected void moveRobot(int x, int y)
	{
		totaldistance+=distance(x,y);
		this.setX(x);
		this.setY(y);
	}
	
	protected void addtoLog(String Log)
	{
		this.Log += Log;
	}
	
	public boolean Roboton()
	{
		return activeRobot=true;
	}
	
	public boolean Robotoff()
	{
		return activeRobot = false;
	}
	
	public double totaldistance()
	{
		return totaldistance;
	}
	
	public double distance(int x, int y)
	{	
		//This is the distance Formula
		return Math.sqrt(Math.pow(this.getX() - x,2)
						+Math.pow(this.getY() - y,2));
	}
	
	public String getLog()
	{
		return Log;
	}
	
	public String setDirection(String way)
	{
		Random random = new Random();
		int direction = 0;
		direction = random.nextInt(3);
		
		if(direction == 0)
		{
			way = "North";
		}
		
		else if(direction==1)
		{
			way = "South";
		}
		
		else if(direction==2)
		{
			way = "East";
		}
		else if(direction==3)
		{
			way = "West";
		}
		return way;
	}
	
	
	public String getDirection(String way)
	{
		return way;
	}

	public int getX() {
		return x;
	}

	public void setX(int x) {
		this.x = x;
	}

	public int getY() {
		return y;
	}

	public void setY(int y) {
		this.y = y;
	}
	
}