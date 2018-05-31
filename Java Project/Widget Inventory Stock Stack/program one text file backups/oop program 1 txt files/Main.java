//Matthew Trebing
//CMPS 2144
//14-Sep-15
//This program will create a stack and will store a record
//of information to store in the stack, then will use a push and 
//pop to get data from the record stack.

import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.text.DecimalFormat;
import java.util.Scanner;

public class MAIN 
{

	public static Mystack stack;
	public static PrintWriter output;
	public static DecimalFormat format = new DecimalFormat("0.00");
	
	public static void main(String[] args) 
	{
		
		Scanner in = new Scanner(System.in);
		Record record = null;
		stack = new Mystack();
		
		setOutput(in);
		
		Welcomemessage();
		
		record = getInput(in); // gets the first set of date 
		
		while(record.gettType()!='q') // as long as a q is not typed in it will 	
		{							 // continue to ask for a s or r
			record = getInput(in);	// continues to get input until a q is typed in	
		}
		
		Closingmessage();
		
		output.close();
	}

	public static void Welcomemessage()
	{
		System.out.println("               Welcome          ");
		output.println("             Welcome              ");
		output.println();
		System.out.println();
		System.out.println("This program was written by Matthew Trebing.");
		output.println("This program was written by Matthew Trebing");
		output.println();
		System.out.println();
		System.out.println("This program will keep a record using a stack.");
		output.println("This program will keep a record using a stack.");
	}
	
	public static void setOutput(Scanner in)
	{
		System.out.println("Please enter in the file name");
		try
		{
			output = new PrintWriter(new FileWriter(in.next()));
		}
		catch(IOException e) // uses a try/catch to make sure the output opens correctly
		{
			System.err.println("Caught IOException" + e.getMessage());
		}
	}
	
	public static Record getInput(Scanner in)
	{
		
		Record record;
		char tType;
		String datetime = "Junk";
		int qty=0;
		double cost=0;
		double totalcost = 0;
		System.out.println("Please type in a r for Record, s for Sale or a q for Quit");
		
		tType = in.next().charAt(0);
		// if else statement to execute the program if a R, S or any other
	   //  letter is typed into the keyboard.
	if(tType==('R') || tType ==('r'))
	{
			datetime = in.next();
			qty = in.nextInt();
			cost = in.nextDouble();
			totalcost = qty * cost; // Calculates the total cost of the 
			record = new Record(tType, datetime, qty, cost); // creates a record to hold onto the date to 
															// be pushed to the stack
			System.out.println(qty +" WIDGETS RECIVED AT $" + format.format(cost) +". - SALE:  $" +format.format(totalcost));
			System.out.println();
			output.println(qty +" WIDGETS RECIVED AT $" + format.format(cost) +". - SALE:  $" +format.format(totalcost));
			output.println();
			
			stack.push(record);
	}
	else if (tType==('S')|| tType==('s'))
	{
		datetime=in.next();
		qty = in.nextInt();
		record = new Record(tType, datetime, qty, cost); //creates a new record to hold the data to be
														// processed.
		processdata(record); //if a S is typed this sends you to the process function
		
	}
	else // will only process if something other the a r s or q is typed in.
	{
		record = new Record(tType, datetime, qty, cost);
		System.out.println("Enter in a R or a S!"); 
	}
	return record; //will return the record to the main program
	
}
	
	public static void processdata(Record record) 
	{			
			int remaining = record.getqty();
			double MaxSale = 0;
			int soldQty=0;
			double recordsale = 0;
			Record sale;
			
			while(remaining > 0) //This while loop will only execute if the remaining widgets are greater the zero
			{
				sale=stack.pop(); // pops off each stack and continues to do until reaming is = -1
				
				if (sale == null)
				{
					//Prints out how many widgets are not available for sale by 
				   // subtracting the quantity from the record from how many were sold
					System.out.println(record.getqty()- soldQty + " WIDGETS NOT AVAILABLE FOR SALE");
					output.println(record.getqty()- soldQty + " WIDGETS NOT AVAILABLE FOR SALE");
					
					return;
				}
				
				
				if (sale.getqty() <= remaining ) // this if statement will only run if the record sale is less then 
												//  or equal to the remaining balance
				{
					remaining -= sale.getqty(); // subtracts the sale from the remaining balance and sets it equal to itself
					recordsale = sale.getcost() * sale.getqty() * 1.2; //multiplies the cost and the quantity then multiplies
																	  // it by the 20% mark up to get the total for the record sale 
					MaxSale += recordsale; // keeps a running total for the max sale by adding it to the record sale 
					System.out.println(sale.getqty() + " WIDGETS SOLD AT $" + format.format(sale.getcost()*1.2) 
									    + " - SALE:" + format.format(recordsale));
					output.println(sale.getqty() + " WIDGETS SOLD AT $" + format.format(sale.getcost()*1.2) 
				    							 + " - SALE:" + format.format(recordsale));
					output.println();
				}
				
				else if (sale.getqty() > remaining) // will only run if the sale quantity is greater the remaining
				{
					recordsale = sale.getcost() * remaining * 1.2; // sets the record sale equal to the sale cost times the remaining
																  // widgets and the marks it up by 20%
					sale.setqty(sale.getqty()-remaining);
					MaxSale+=recordsale; // sets the max sale to equal the record sale 
					System.out.println(remaining + " WIDGETS SOLD AT $" + format.format(sale.getcost()*1.2)  + " - SALE:" + format.format(recordsale));
					output.println(remaining + " WIDGETS SOLD AT $" + format.format(sale.getcost()*1.2)  + " - SALE:" + format.format(recordsale));
					remaining = 0;
					stack.push(sale); // push any reaming record sales back onto the stack to be processed later
				}
				
			}
	
			System.out.println();
			System.out.println("TOTAL FOR THIS SALE: " + format.format(MaxSale));
			System.out.println();
			output.println();
			output.println("TOTAL FOR THIS SALE: " + format.format(MaxSale));
			output.println();
	}
	
	public static void Closingmessage()
	{
		System.out.println();
		System.out.println("Thank you for using this program!");
		output.println();
		output.println("Thank you for using this program");
	}
	
	
	
	
}