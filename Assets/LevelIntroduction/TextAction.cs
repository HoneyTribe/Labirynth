using UnityEngine;
using System.Collections;

public class TextAction : Action  {

	IntroductionController introductionController;
	GameObject camera;
	float time = 0;
	int textureId;
	string text;
	int position = 0;

	public TextAction(int textureId, string text)
	{
		this.introductionController = GameObject.Find ("GameController").GetComponent<IntroductionController> ();
		this.camera = GameObject.Find ("MainCamera_Front");
		this.textureId = textureId;
		this.text = text;
	}

	public void act()
	{
		time += Time.deltaTime;
		if (position != text.Length)
		{
			if (time > 0.03f)
			{
				position ++;
				time = 0;
			}

			introductionController.setTextureId (textureId);
			introductionController.setText (text.Substring(0, position));
		}
	}

	public bool isFinished()
	{
		if (time > 2f) 
		{
			introductionController.setTextureId (-1);
			introductionController.setText (null);
			return true;
		}
		else
		{
			return false;
		}
	}
}
