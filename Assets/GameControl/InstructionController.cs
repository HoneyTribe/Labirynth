using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InstructionController : MonoBehaviour {

	public Texture2D instructionTexture;

	private GUIStyle instructionStyle = new GUIStyle();
	private GUIStyle backgroundStyle = new GUIStyle();

	void Start()
	{
		instructionStyle.normal.background = instructionTexture;
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,Color.black);
		texture.Apply();
		backgroundStyle.normal.background = texture;
	}

	void OnGUI () 
	{
		GUI.depth = 0;
		float height = Screen.width * 720 / 1280;
		GUI.BeginGroup (new Rect (0, 0, Screen.width, Screen.height), backgroundStyle);
		GUI.Box (new Rect (0, (Screen.height - height) / 2, Screen.width, height), "", instructionStyle);
		GUI.EndGroup ();
	}
}
