using UnityEngine;
using System.Collections;

public class CraneEnergyController : MonoBehaviour {

	public static CraneEnergyController instance;

	private const int progressBarSize = 100;
	private const float holdingCost = 0.125f; // You can hold an object 1/holdingCost seconds (8 seconds).
	private const float pickingUpCost = 0.05f; // constant cost of picking up - even if you failed
	private const float restoreVelocity = 0.066f; // It needs 1/restoreVelocity seconds to regenerate (215 seconds).
	private const float activationCost = 0.3f; 
	private const float smashingCost = 0.2f; // Wall smashing takes object 1/smashingCost seconds (5 seconds).

	private GUIStyle borderStyle;
	private GUIStyle outerStyle;
	private GUIStyle energyStyle;
	private GUIStyle lowEnergyStyle;
	private float energy = 1.0f;

	private bool isHeld;
	private bool beingSmashed;

	void Start()
	{
		instance = this;

		borderStyle = new GUIStyle ();
		Texture2D borderTexture = new Texture2D (1, 1);
		borderTexture.SetPixel (0, 0, Color.white);
		borderTexture.Apply ();
		borderStyle.normal.background = borderTexture;

		outerStyle = new GUIStyle ();
		Texture2D outerTexture = new Texture2D (1, 1);
		outerTexture.SetPixel (0, 0, Color.black);
		outerTexture.Apply ();
		outerStyle.normal.background = outerTexture;

		energyStyle = new GUIStyle ();
		Texture2D energyTexture = new Texture2D (1, 1);
		energyTexture.SetPixel (0, 0, Color.blue);
		energyTexture.Apply ();
		energyStyle.normal.background = energyTexture;

		lowEnergyStyle = new GUIStyle ();
		Texture2D lowEnergyTexture = new Texture2D (1, 1);
		lowEnergyTexture.SetPixel (0, 0, Color.red);
		lowEnergyTexture.Apply ();
		lowEnergyStyle.normal.background = lowEnergyTexture;
	}

	void OnGUI()
	{
		GUI.BeginGroup(new Rect ((Screen.width / 4) *3 - progressBarSize / 2, Screen.height - 20, progressBarSize, 10));
			GUI.Box (new Rect (0, 0, progressBarSize, 10), "", borderStyle);
			GUI.Box (new Rect (1, 1, progressBarSize - 2, 8), "", outerStyle);
			if (energy >= getMinCost())
			{
				GUI.Box (new Rect (1, 1, energy * (progressBarSize - 2), 8), "", energyStyle);
			}
			else
			{
				GUI.Box (new Rect (1, 1, energy * (progressBarSize - 2), 8), "", lowEnergyStyle);
			}
		GUI.EndGroup();
	}

	void Update()
	{
		if (isHeld)
		{
			changeEnergy (-Time.deltaTime * holdingCost);
			if (energy == 0f)
			{
				Debug.Log("hello");
				isHeld = false;
				gameObject.SendMessage("ForceDrop");
			}
		}
		else if (beingSmashed)
		{
			changeEnergy (-Time.deltaTime * smashingCost);
			if (energy == 0f)
			{
				beingSmashed = false;
				gameObject.SendMessage("DestroyWall");
			}
		}
		else
		{
			changeEnergy (Time.deltaTime * restoreVelocity);
		}
	}

	public void pickingUp()
	{
		changeEnergy (-pickingUpCost);
	}

	public void activating()
	{
		changeEnergy (-activationCost);
	}
	
	public void holding(bool isHeld)
	{
		this.isHeld = isHeld;
	}

	public void smashing()
	{
		this.beingSmashed = true;
	}

	private float getMinCost()
	{
		float minCost = 1f;
		if (LevelFinishedController.instance.getLevel() >= LevelFinishedController.instance.getFirstLevelWithCrane())
		{
			minCost = pickingUpCost;
		}
		
		if (LevelFinishedController.instance.getLevel() >= LevelFinishedController.instance.getFirstLevelWithSmasher())
		{
			if (minCost > 1f)
			{
				minCost = 1f;
			}
		}
		
		return minCost;
	}

	private void changeEnergy(float value)
	{
		energy += value;
		if (energy > 1.0f)
		{
			energy = 1.0f;
		}
		if (energy < 0.0f)
		{
			energy = 0.0f;
		}
	}

	public bool canPickUp()
	{
		return energy > pickingUpCost;
	}

	public bool canActivate()
	{
		return energy > activationCost;
	}

	public bool canSmash()
	{
		return energy == 1f;
	}
}
