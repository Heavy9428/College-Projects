//Matthew Trebing
//Oop Program 3
//Dr. Stringfellow
//October 26th, 2015

import java.util.ArrayList;

public class RockRobot extends Robot
{
	private ArrayList<Rock> rocklist;
	private int pickedup;
	public RockRobot(ArrayList<Rock> list)
	{
		super();
		rocklist = list;
		pickedup=0;
	}
	
	//Robot Copy Constructor
	public RockRobot(RockRobot other ,ArrayList<Rock> list)
	{
		super(other);
		rocklist = list;	
		pickedup = other.pickedup;
	}
	
	//Paramaterized Constructor
	public RockRobot(int newx,int newy,int newpickedup,
				 int newtotal,ArrayList<Rock> list)
	{
	
		super(newx,newy, newtotal);
		rocklist = list;
		pickedup=0;
		
	}
	
	public void pickupnumrock(int number)
	{
		Rock rock = null;
		String way1="";
		String way=setDirection(way1);
		
		for(int i=0; i < number; i++)
		{
			rock = findclosestrock();
			rock.changePickedup();
			
			addtoLog(getDirection(way)+"\t"+"\t"+"\t"
						+rock.getrockposition()+"\t"+"      ("
						+rock.getxcoord()+","+rock.getycoord()+")"+"\t"+"\t"
					    +format.format(distance(rock.getxcoord()
					    ,rock.getycoord()))+"\n");
			
			moveRobot(rock.getxcoord(), rock.getycoord());
			pickedup++;
		}
	}
	
	public int getpickedup()
	{
		return pickedup;
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
			if(!drock.isPickedup() && distance(drock.getxcoord(), 
				drock.getycoord()) < distance)
			{
				//sets the distance of the last rock to the new distance
				distance = distance(drock.getxcoord(),drock.getycoord());
				rock = drock;
			}
		}
			return rock;
	}
}
