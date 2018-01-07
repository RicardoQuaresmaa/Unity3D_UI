using UnityEngine;
using System.Collections;
[ExecuteInEditMode] 
public class BasicGUI : MonoBehaviour {
	private Rect rctWindow1;
	private bool blnToggleState = false;
	private float fltSliderValue = 0.5f;
	private float fltScrollerValue = 0.5f;
	private Vector2 scrollPosition = Vector2.zero;
	private string textString = "Some text here";
	private int toolbarInt = 0;
	private string[] toolbarStrings = { "Toolbar1", "Toolbar2", "Toolbar3" };
	private int selectionGridInt = 0;
	private string[] selectionStrings = { "Grid 1", "Grid 2", "Grid 3", "Grid 4" };
	private int buttonCount, repeatButtonCount = 0;
	public Texture2D myTexture;
	public struct scrollNodeArray
	{
		public string itemType, itemName;
		public scrollNodeArray(string itemType, string itemName)
		{
			this.itemType = itemType;
			this.itemName = itemName;
		}
	}
	
	void Awake()
	{
		rctWindow1 = new Rect(500, 0, 475, 560);
	}
	
	void OnGUI()
	{
		BasicGUIControls();
		rctWindow1 = GUI.Window(0, rctWindow1, DoMyWindow, "Controls Window");
	}
	
	void DoMyWindow(int windowID)
	{
		BasicGUIControls();
		
		GUI.DragWindow();
	}
	
	void BasicGUIControls()
	{
		if (myTexture == null) 
		{
			myTexture = new Texture2D (125, 15);
		}
		GUI.Label(new Rect(25, 15, 100, 30), "Label");        
		GUI.Label(new Rect(125, 15, 100, 30), myTexture);
		GUI.Label(new Rect(125, 15, 100, 30), "Text overlay");
		GUI.DrawTexture(new Rect(350, 15, 100, 15), myTexture);
		GUI.DrawTextureWithTexCoords(new Rect(350, 35, 100, 15), myTexture,new Rect(10, 10, 50, 5));
		if (GUI.Button(new Rect(25, 40, 120, 30), "Button"))
		{
			buttonCount += 1;
		}
		if (GUI.RepeatButton(new Rect(170, 40, 170, 30), "RepeatButton"))
		{
			repeatButtonCount += 1;
		}
		GUI.Label(new Rect(25, 70, 100, 30), "Button Clicks: " + buttonCount);
		GUI.Label(new Rect(170, 70, 170, 50), "Repeat Button Clicks: " + repeatButtonCount);
		textString = GUI.TextField(new Rect(25, 100, 100, 30), textString);
		textString = GUI.TextArea(new Rect(150, 100, 200, 75), textString);
		textString = GUI.PasswordField(new Rect(375, 100, 90, 30), textString, '*');
		blnToggleState = GUI.Toggle(new Rect(25, 150, 250, 30), blnToggleState, "Toggle");
		toolbarInt = GUI.Toolbar(new Rect(25, 200, 200, 30), toolbarInt, toolbarStrings);
		selectionGridInt = GUI.SelectionGrid(new Rect(250, 200, 200, 60), selectionGridInt, selectionStrings, 2);
		
		fltSliderValue = GUI.HorizontalSlider(new Rect(25, 250, 100, 30), fltSliderValue, 0.0f, 10.0f);
		fltSliderValue = GUI.VerticalSlider(new Rect(150, 250, 25, 50), fltSliderValue, 10.0f, 0.0f);
		fltScrollerValue = GUI.HorizontalScrollbar(new Rect(25, 285, 100, 30), fltScrollerValue, 1.0f, 0.0f, 10.0f);
		fltScrollerValue = GUI.VerticalScrollbar(new Rect(200, 250, 25, 50), fltScrollerValue, 1.0f, 10.0f, 0.0f);
		
		scrollPosition = GUI.BeginScrollView(new Rect(25, 325, 300, 200), scrollPosition, new Rect(0, 0, 400, 400));
		for (int i = 0; i < 20; i++)
		{
			addScrollViewListItem(i, "I'm listItem number " + i);
		}
		GUI.EndScrollView();
		
		GUI.Box (new Rect (350, 350, 100, 130), "Settings");
		GUI.Label(new Rect(360, 370, 80, 30), "Label"); 
		textString = GUI.TextField(new Rect(360, 400, 80, 30), textString);
		if (GUI.Button (new Rect (360, 440, 80, 30), "Button")) {}
		
	}
	
	void addScrollViewListItem(int i, string strItemName)
	{
		GUI.Label(new Rect(25, 25 + (i * 25), 150, 25), strItemName);
		blnToggleState = GUI.Toggle(new Rect(175, 25 + (i * 25), 100, 25), blnToggleState, "");
	}
}
