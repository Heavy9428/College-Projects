public class Record 
{
	//Default Constructor
	public Record()
	{
		tType= 'a';
		datetime = "x";
		qty = 0;
		cost = 0;
	}
	
	//Paramerterized constructor
	public Record(char newtType, String newdatetime, int newqty, double newcost)
	{
		tType = newtType;
		datetime = newdatetime;
		qty = newqty;
		cost = newcost;
	}
	
	//copy Constructor
	public Record(Record copy)
	{
		tType = copy.tType;
		cost = copy.cost;
		datetime = copy.datetime;
		qty = copy.qty;
	}
	
	public void settype(char a)
	{
		tType = 'a';
	}
	
	public char gettType()
	{
		return tType;
	}
	
	public void setdatetime(String x)
	{
		datetime = "x";
	}
	
	public String getdatetime()
	{
		return datetime;
	}
	
	public void setqty(int newqty)
	{
		qty = newqty;
	}
	
	public int getqty()
	{
		return qty;
	}
	
	public void setcost(double newcost)
	{
		cost = newcost;
	}
	
	public double getcost()
	{
		return cost;
	}
	private char tType;
	private String datetime;
	private int qty;
	private double cost;
}
