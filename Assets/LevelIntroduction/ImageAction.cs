using UnityEngine;
using System.Collections;

public class ImageAction : Action  {

	IntroductionController introductionController;
	float time = 0;
	Texture2D image;

	public ImageAction(string imageName)
	{
		this.introductionController = GameObject.Find ("GameController").GetComponent<IntroductionController> ();
		image = (Texture2D) Resources.Load(imageName, typeof(Texture2D));
	}

	public void act()
	{
		time += Time.deltaTime;
		introductionController.setImage (image);
	}

	public bool isFinished()
	{
		if (time > 5f) 
		{
			introductionController.setImage (null);
			return true;
		}
		else
		{
			return false;
		}
	}
}
