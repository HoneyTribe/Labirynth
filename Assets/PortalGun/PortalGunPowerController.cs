using UnityEngine;
using System.Collections;

public class PortalGunPowerController : MonoBehaviour {

	public static PortalGunPowerController instance;

	private const int progressBarSize = 100;
	private const float holdingCost = 0.33f; // You can hold an button 1/holdingCost seconds (3 seconds).

	private GUIStyle borderStyle;
	private GUIStyle outerStyle;
	private GUIStyle energyStyle;
	private GUIStyle lowEnergyStyle;
	private float energy = 0f;

	private bool isHeld;

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
		GUI.BeginGroup(new Rect ((Screen.width / 4) - progressBarSize / 2, Screen.height - 20, progressBarSize, 10));
			GUI.Box (new Rect (0, 0, progressBarSize, 10), "", borderStyle);
			GUI.Box (new Rect (1, 1, progressBarSize - 2, 8), "", outerStyle);
			GUI.Box (new Rect (1, 1, energy * (progressBarSize - 2), 8), "", energyStyle);
		GUI.EndGroup();
	}

	void Update()
	{
		if (isHeld)
		{
			changeEnergy (Time.deltaTime * holdingCost);
			if (energy == 1f)
			{
				gameObject.SendMessage("Shoot");
			}
		}
	}

	public void holding(bool isHeld)
	{
		if (!isHeld)
		{
			energy = 0f;
		}
		this.isHeld = isHeld;
	}

	public bool isHolding()
	{
		return this.isHeld;
	}

	public float getEnergy()
	{
		return this.energy;
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
}
