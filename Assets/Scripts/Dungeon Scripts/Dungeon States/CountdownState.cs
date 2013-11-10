using UnityEngine;
using System.Collections;

public class CountdownState : MonoBehaviour, IState 
{
	private const string stateName = "Countdown";
	private const string transitionToDungeonRun = "Start Run";
	
	private bool isInit = true;
	private float countdownTimer;			//Timer counting down to start of game
	private float countdownTimerMax = 1f;
	
	private int currentSecond;				//The current second on the countdown
	private int secondLastFrame = 0;		//The second from last frame
	
	public Texture2D countdownMeter;
	
	public string GetName()
	{
		return stateName;
	}
	
	//Initialize the state in here
	void Init()
	{
		countdownTimer = countdownTimerMax;
	}
	
	
	public void Run()
	{
		if (isInit)
		{
			Init();
			isInit = false;
		}
		
		countdownTimer -= Time.deltaTime;
		
		currentSecond = Mathf.CeilToInt(countdownTimer);
		
		if (currentSecond != secondLastFrame)
		{
			secondLastFrame = currentSecond;
		}
		
		//Display a countdown
		
		//Prompt the user to play a minigame while countdown is running
		
		
		
		
		//When countdown hits zero, go to Dungeon Run
		if (currentSecond <= 0f)
		{
			EndState();	
		}
	}
	
	//Run when transitioning to a new state
	void EndState()
	{
		
		//Initialize Go! Graphic
		Debug.Log("Go!");
		
		
		
		TransitionToDungeonRun();
	}
	
	void TransitionToDungeonRun()
	{
		PlayMakerFSM.BroadcastEvent(transitionToDungeonRun);
		PlayMakerFSM.BroadcastEvent("Countdown Complete");
		iTween.Stop();
	}
	
	void OnGUI()
	{
		GUIStyle style = new GUIStyle();
		style.fontSize = 50;
		GUI.TextArea(new Rect(60, 5,40,40),currentSecond.ToString(), style);
		
		
		
		float meterProgress = countdownTimer - currentSecond + 1;
		
   		if (Event.current.type == EventType.Repaint && currentSecond > 0)
  	 	{
     	// Paint the full bar. 
    	Graphics.DrawTexture(
        new Rect(100,40,200 * meterProgress,25), 
        countdownMeter, 
        new Rect(0,0,meterProgress,1) ,0,0,0,0);
   		} 
	}
	
}
