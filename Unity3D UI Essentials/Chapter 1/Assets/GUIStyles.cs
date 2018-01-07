using UnityEngine;
[ExecuteInEditMode]
public class GUIStyles : MonoBehaviour {

	public GUIStyle myGUIStyle;

	void OnGUI() {
		GUI.Label(new Rect(25, 15, 100, 30), "Label", myGUIStyle);
	}
}
