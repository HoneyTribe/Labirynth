using UnityEngine;
using System.Collections;

public class SplashController : MonoBehaviour {

	public static SplashController instance;
	public Texture2D mainSplashTexture;	

	private GUIStyle mainSplashStyle = new GUIStyle();
	private GUIStyle mainBackgroundStyle = new GUIStyle();
	private bool visible = true;

	void Start()
	{
		instance = this;

		// main splash
		mainSplashStyle.normal.background = mainSplashTexture;
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,Color.black);
		texture.Apply();
		mainBackgroundStyle.normal.background = texture;
	}

	void OnGUI () 
	{
		if (visible)
		{
			GUI.depth = 0;
			float height = Screen.width * 900/1600;
			GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height ), mainBackgroundStyle);
			GUI.Box (new Rect(0, (Screen.height - height)/2, Screen.width, height), "", mainSplashStyle);
			GUI.EndGroup();
		}
	}

	public void setVisible(bool visible)
	{
		this.visible = visible;
	}

	public bool isVisible()
	{
		return visible;
	}
}
