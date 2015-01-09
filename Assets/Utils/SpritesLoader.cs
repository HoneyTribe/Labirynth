using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpritesLoader {

	private const int IMAGE_HEIGHT = 320;

	public static GUIStyle[] getPlayerSprites(Texture2D playersTexture)
	{
		GUIStyle[] styles = new GUIStyle[4];		

		styles[0] = new GUIStyle ();
		Color[] button1Colors = playersTexture.GetPixels (0, 0, IMAGE_HEIGHT, IMAGE_HEIGHT);
		Texture2D button1Texture = new Texture2D(IMAGE_HEIGHT, IMAGE_HEIGHT);
		button1Texture.SetPixels(button1Colors);
		button1Texture.Apply ();
		styles[0].normal.background = button1Texture;

		styles[1] = new GUIStyle ();
		Color[] button2Colors = playersTexture.GetPixels (320, 0, IMAGE_HEIGHT, IMAGE_HEIGHT);
		Texture2D button2Texture = new Texture2D(IMAGE_HEIGHT, IMAGE_HEIGHT);
		button2Texture.SetPixels(button2Colors);
		button2Texture.Apply ();
		styles[1].normal.background = button2Texture;

		styles[2] = new GUIStyle ();
		Color[] button3Colors = playersTexture.GetPixels (640, 0, IMAGE_HEIGHT, IMAGE_HEIGHT);
		Texture2D button3Texture = new Texture2D(IMAGE_HEIGHT, IMAGE_HEIGHT);
		button3Texture.SetPixels(button3Colors);
		button3Texture.Apply ();
		styles[2].normal.background = button3Texture;

		styles[3] = new GUIStyle ();
		Color[] button4Colors = playersTexture.GetPixels (960, 0, IMAGE_HEIGHT, IMAGE_HEIGHT);
		Texture2D button4Texture = new Texture2D(IMAGE_HEIGHT, IMAGE_HEIGHT);
		button4Texture.SetPixels(button4Colors);
		button4Texture.Apply ();
		styles[3].normal.background = button4Texture;

		return styles;
	}

	public static GUIStyle getTexture(Texture2D texture)
	{
		GUIStyle style = new GUIStyle ();
		style.normal.background = texture;

		return style;
	}
}
