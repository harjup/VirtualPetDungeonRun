using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour 
{
	
	public GameObject fruitPrefab;
	int prefabsSpawned = 0;
	
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("SpawnFruit",0f,1f);
	}
	
	void Update()
	{		
		if (prefabsSpawned >= 10)
		{
			CancelInvoke();	
		}
		
	}
	
	void SpawnFruit()
	{
		GameObject g = Instantiate(fruitPrefab, GeneratePosition(), Quaternion.identity) as GameObject;
		Collectable c = g.GetComponent<Collectable>();
		
		c.Init(TypesOfFruit.GetFruit(TypesOfFruit.fruits.StrongerFruit));
		
		prefabsSpawned++;
	}
	
	
	Vector3 GeneratePosition()
	{
		return new Vector3(
			Random.Range(0f,10f),
			Random.Range(0f,10f),
			Random.Range(0f,10f)
			);	
	}
	
	
	void OnGUI()
	{
		Rect backButtonPos = new Rect(
			NormalizeToScreen(dimension.x, .9f),
			NormalizeToScreen(dimension.y, .9f),
			NormalizeToScreen(dimension.x, .1f),
			NormalizeToScreen(dimension.y, .05f)
			);
		
		if (GUI.Button(backButtonPos, "Back to Garden"))
		{
			Application.LoadLevel("GardenTest");	
		}
		
	}
	
	enum dimension {x, y};
	
	float NormalizeToScreen(dimension d, float ratio)
	{
		if (d == dimension.x)
		{
			return ratio * Screen.width;	
		}
		
		if (d == dimension.y)
		{
			return ratio * Screen.height;
		}
		
		return -1f;
	}
}
