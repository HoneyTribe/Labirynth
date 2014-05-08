using UnityEngine;
using System.Collections;

public class TextAction : Action  {

	GameObject camera;
	int textureId;
	string text;

	public TextAction(GameObject camera, int textureId, string text)
	{
		this.camera = camera;
		this.textureId = textureId;
		this.text = text;
	}

	public void act()
	{

	}

	public bool finished()
	{
		return false;
	}
}
