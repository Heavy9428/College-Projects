//Matthew Trebing
//Oop Program 3
//Dr. Stringfellow
//October 26th, 2015

public interface Irock 
{	
	//This will get the xcoord from the infile
	//This returns the x value
	public int getxcoord();
	
	//This will get the y coord from the infile
	//This will return the y coord
	public int getycoord();
	
	//This will give x a value in the array	
	//This needs to have a valid x in the infile
	//This will return the value of x
	public void setxcoord(int value);
	
	//This will give y a value in the array	
	//This needs to have a valid y in the infile
	//This will return the value of y
	public void setycoord(int value);
	
	//Will return a true or false if the rock has been 
	//picked up or not
	public boolean isPickedup();
	
	//This will changed the picked up status of a rock
	//This will change picked up to the boolean value of true 
	public void changePickedup();
	
	//This will return the rock position of the rock in the array
	//as it is is counted by numrocks++
	public int getrockposition();
}
