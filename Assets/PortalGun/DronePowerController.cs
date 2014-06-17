using UnityEngine;
using System.Collections;

public class DronePowerController : MonoBehaviour {

	public static DronePowerController instance;

	private const float settingUpCost = 0.3f; // constant cost of setting up a portal
	private const float usingStunGunCost = 0.25f; // constant cost of using stun gun
	private const float restoreVelocity = 0.066f; // It needs 1/restoreVelocity seconds to regenerate (15 seconds).

	private const int progressBarSize = 100;

	private GUIStyle borderStyle;
	private GUIStyle outerStyle;
	private GUIStyle energyStyle;
	private GUIStyle lowEnergyStyle;
	private float energy = 1f;

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

	void Update()
	{
		changeEnergy (Time.deltaTime * restoreVelocity);
	}

	void OnGUI()
	{
		GUI.BeginGroup(new Rect ((Screen.width / 4) - progressBarSize / 2, Screen.height - 20, progressBarSize, 10));
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

	public void settingUp()
	{
		changeEnergy (-settingUpCost);
	}

	public bool canSetUp()
	{
		return energy >= settingUpCost;
	}

	public void usingStunGun()
	{
		changeEnergy (-usingStunGunCost);
	}
	
	public bool canUseStunGun()
	{
		return energy >= usingStunGunCost;
	}

	private float getMinCost()
	{
		float minCost = 1f;
		if (LevelFinishedController.instance.getLevel() >= LevelFinishedController.instance.getFirstLevelWithDrone())
		{
			minCost = settingUpCost;
		}

		if (LevelFinishedController.instance.getLevel() >= LevelFinishedController.instance.getFirstLevelWithStunGun())
		{
			if (minCost > usingStunGunCost)
			{
				minCost = usingStunGunCost;
			}
		}

		return minCost;
	}

	public void changeEnergy(float value)
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
}
