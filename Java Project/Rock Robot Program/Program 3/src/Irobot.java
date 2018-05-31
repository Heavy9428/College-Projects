//Matthew Trebing
//Oop Program 3
//Dr. Stringfellow
//October 26th, 2015

public interface Irobot 
{
	//This will check to see if the robot is turned on
	//Returns either true of false
	public boolean Roboton();
	
	//This will check to see if the robot is off
	//Returns either a true or a false
	public boolean Robotoff();
		
	//This will get the x coord for the Robot
	//It will be used as the starting location 
	public int getxrobot();
	
	//This will get the y coord for the Robot
	//It will be used as the starting location
	public int getyrobot();
	
	//This will set the x coord for the Robot
	//This will set the starting location 
	public void setxrobot(int value);
	
	//This will set the y coord for the Robot
	//This will set the starting location 
	public void setyrobot(int value);

	//This will add the distances together
	//and then keep adding it to the total distance
	//and return the total distance to the pick
	//up number rock function in the Robot class
	public void adddistance(double distance);
	
	//This will return the distance of the robot 
	//and the closest rock to the robot.
	public double distance(Rock rock);
	
	//This will find the closest rock and check
	//it with each of the rocks in the array 
	public Rock findclosestrock();
	
	//This function will pick up the closest rock
	//by first finding the closest rock and then 
	//changing that rock to the one being picked up
	//and then set the new x and y of the rock 
	//and keep looping until the array list is complete or 
	//a user defined number is hit
	public void pickupnumrock(int number);
	
	//This will return the Robot's log back to a function in main 
	//so it can be output to out file
	public String getLog();
	
	//This function uses a random number to generate 
	//a direction that the robot goes to pick up a rock 
	//uses a if statement to execute
	public String setDirection(String way);
	
	//This function return the direction
	public String getDirection(String way);	
}
