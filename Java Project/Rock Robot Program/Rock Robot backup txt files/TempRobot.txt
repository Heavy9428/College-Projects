//Matthew Trebing
//Oop Program 3
//Dr. Stringfellow
//October 26th, 2015

import java.util.*;

public class TempRobot extends Robot
{
	
	private int temp;
	
	public TempRobot()
	{
		super();
		temp = 0;
	}
	
	public TempRobot(TempRobot other)
	{
		super(other);
		temp = other.temp;
	}
	
	public TempRobot(int newtemp)
	{
		super();
		temp= newtemp;
	}
	
	public void takeTemp()
	{
		Random random = new Random();
		String way1="";
		String way=setDirection(way1);
		int x= 0;
		int y= 0;
		
		x = random.nextInt(100);
		y = random.nextInt(100);
		
		temp = random.nextInt(330);
		temp -= 250;
		
		
		addtoLog(getDirection(way)+"\t"+"\t"+temp+"°F"+"\t"+"\t"+"("+x+","+y+")"
				+				"\t"+"\t"+format.format(distance(x,y))+"\n");

		moveRobot(x,y);
	}
	
	
}
