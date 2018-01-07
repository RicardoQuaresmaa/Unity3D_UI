using UnityEngine;
[ExecuteInEditMode]
public class GUISkins : MonoBehaviour {
	
	public GUISkin mySkin;
	void OnGUI()
	{
		GUI.skin = mySkin;
		GUI.Label(new Rect(25, 15, 100, 30), "Label");
		//Draw the rest of your controls
	}
}

