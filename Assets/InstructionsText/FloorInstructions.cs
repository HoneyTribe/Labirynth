using UnityEngine;
using System.Collections;

public class FloorInstructions : MonoBehaviour
{
	private ScoreController scoreController;
	private TopLightController topLightController;
	private GameObject arrowCentre;
	public Texture instructionsFloor_01;
	public Texture instructionsFloor_02;
	public Texture instructionsFloor_03;

	void Start()
	{
		scoreController = GameObject.Find ("GameController").GetComponent<ScoreController> ();
		topLightController = GameObject.Find ("TopLight").GetComponent<TopLightController> ();
		arrowCentre = GameObject.Find ("ArrowCentre");
	}


	public void ChangeInstructions ()
	{
		if (topLightController.enterLight == true)
		{
			arrowCentre.transform.Translate(0,-1,0);
			if (scoreController.publicScore > 0)
			{
				renderer.material.mainTexture = instructionsFloor_02;
			}

			else
			{
				renderer.material.mainTexture = instructionsFloor_02;
			}
		}

		else
			if (scoreController.publicScore > 0)
			{
				renderer.material.mainTexture = instructionsFloor_01;
				arrowCentre.transform.Translate(0,1,0);
			}
			
			else
			{
				renderer.material.mainTexture = instructionsFloor_03;
			}


		
	}



}