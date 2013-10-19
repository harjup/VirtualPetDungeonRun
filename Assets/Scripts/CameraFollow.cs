using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	GameObject petObject;
	
	// Use this for initialization
	void Start () 
	{
		petObject = GameObject.Find("Pet");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 targetPos = new Vector3(
			petObject.transform.position.x + 10f,
			transform.position.y,
			petObject.transform.position.z 
			);
		
		iTween.MoveUpdate(this.gameObject, targetPos, 1f);
	}
}
