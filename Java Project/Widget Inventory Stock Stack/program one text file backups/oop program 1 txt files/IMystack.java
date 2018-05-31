public interface IMystack 
{
	//Returns true if Mystack is full
	//param: none
	//Returns: boolean
	public boolean isFull();
	
	//Returns true if Mystack is full
	//param: none
	//Returns: boolean
	public boolean isEmpty();
	
	//Inserts a new element into the top of my stack
	//param: widget to be pushed
	public void push(Record widget);
	
	//Removes the top element from the stack 
	//Returns the item and it is removed
	public Record pop();
	
}
