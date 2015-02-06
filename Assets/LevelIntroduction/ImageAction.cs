using UnityEngine;
using System.Collections;

public class ImageAction : Action  {

	IntroductionController introductionController;
	float time = 0;
	Texture2D image;
	
	GameObject camera;
	float randomNumber;

	public ImageAction(string imageName)
	{
		this.introductionController = GameObject.Find ("GameController").GetComponent<IntroductionController> ();
		image = (Texture2D) Resources.Load(imageName, typeof(Texture2D));
		this.camera = GameObject.Find ("MainCamera_Front");
	}

	public void act()
	{
		time += Time.deltaTime;
		introductionController.setImage (image);

		//camera
		randomNumber = Time.time % 3;

		if(randomNumber >=0 && randomNumber <1)
		{
			this.camera.transform.position = new Vector3(0, 45, 15);
			this.camera.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else if(randomNumber >=1 && randomNumber <2)
		{
			
			this.camera.transform.position = new Vector3(8, 8, 15);
			this.camera.transform.rotation = Quaternion.Euler(-40, 250, 0);
		}
		else
		{
			this.camera.transform.position = new Vector3(0, 34, -13);
			this.camera.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}

	public bool isFinished()
	{
		if (time > 4f) 
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
