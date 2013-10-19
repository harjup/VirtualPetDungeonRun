/// <summary>
/// Interface for running states
/// </summary>
public interface IState
{
	//Returns the name of the current state script
	string GetName();
	
	//When state is active, called every frame
	void Run();
	
}
