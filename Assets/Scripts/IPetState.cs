/// <summary>
/// Extends IState to allow Pet States to have the current IPet input
/// </summary>
public interface IPetState 
{
	//Returns the name of the current state script
	string GetName();
	
	//When state is active, called every frame
	void Run();
	
	//Sets the state to refer to the correct Pet interface
	void SetMyPet(IPet _myPet);
}
