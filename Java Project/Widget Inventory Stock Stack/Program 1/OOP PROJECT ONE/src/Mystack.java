public class Mystack implements IMystack
{	
	public final int MAXSIZE = 100; 
	private int top;
	private int maxStack;
	private Record widgets[]; // A record of widgets
	//Default
	
	public Mystack()
	{
		
		top = -1;
		maxStack = MAXSIZE;
		widgets = new Record[maxStack];
		for(int i=0; i< MAXSIZE; i++)
		{
			widgets[i] = new Record();
		}
	}
	
	//Parameterized
	public Mystack(int max)
	{
		maxStack = max;
		top = - 1;
		widgets = new Record [max];		
		for(int i=0; i<= MAXSIZE; i++)
		{
			widgets[i] = new Record();
		}
	}
	
	//Copy Constructor
	/*public Mystack(Mystack other)
	{
		Record widget;
		top = other.top;
		maxStack = other.maxStack;
		for (int i=0; i <= maxStack; i++)
		{
		widgets[i].setqty(other.getqty());
		widgets[i].setdatetime(other.getdatetime());
		widgets[i].setcost(other.getcost());	
		}
	}*/
	
	
	public boolean isEmpty()
	{
		if (top == -1)
		{
			System.out.println("Can not pop an empty stack");
			return true;
		}
		else 
		{
			return false;
		}
	}
	
	public boolean isFull()
	{
		if(top==MAXSIZE)
		{
			System.out.println("THE STACK IS FULL");
			return true;
		}
		else 
		{
			return false;
		}
	}
	
	public void push (Record widget)
	{
		
		if(top == widgets.length)
		{
			System.out.println("will not work");
		}
		else
		{
			
			top+=1;
			widgets[top].setqty(widget.getqty());
			widgets[top].setdatetime(widget.getdatetime());
			widgets[top].setcost(widget.getcost());
			
		}
	}
	
	public Record pop()
	{
		Record widget = null;
		if (top >=0)
		{
			widget = widgets[top];
			widget.setqty(widgets[top].getqty());
			widget.setdatetime(widgets[top].getdatetime());
			widget.setcost(widgets[top].getcost());
			top--;
		}
		
		return widget;
		
	}
	
	

}
		