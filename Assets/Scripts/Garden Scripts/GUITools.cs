using UnityEngine;
using System.Collections;

public static class GUITools 
{
	public enum dimension {x, y};
	
	public static float NormalizeToScreen(dimension d, float ratio)
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
