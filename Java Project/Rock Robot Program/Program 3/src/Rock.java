//Matthew Trebing
//Oop Program 3
//Dr. Stringfellow
//October 26th, 2015

public class Rock implements Irock  
{
	private static int numRocks = 0;
	private int rockposition;
	private int x;
	private int y;
	private boolean pickedup;
	
	//Rock Constructor
	public Rock()
	{
		x = 0;
		y = 0;	
		pickedup = false;
		numRocks++;
		rockposition = numRocks;
	}
	
	//Rock Copy Constructor
	public Rock(Rock other)
	{
		x=other.x;
		y=other.y;
		pickedup = other.pickedup;
		numRocks++;
		rockposition = numRocks;
	}
	
	//Rock Paramaterized constructor
	public Rock(int newx, int newy)
	{
		newx=x;
		newy=y;
		pickedup = false;
		numRocks++;
		rockposition = numRocks;
	}
	
	public int getxcoord()
	{
		return x;
	}
	
	public void setxcoord(int value)
	{
		x = value;
	}
	
	public int getycoord()
	{
		return y;
	}
	
	public void setycoord(int value)
	{
		y = value;
	}
	
	public boolean isPickedup()
	{
		return pickedup;
	}
	
	public void changePickedup()
	{
		pickedup = true;
	}

	public int getrockposition()
	{
		return rockposition;
	}				
}
