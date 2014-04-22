using UnityEngine;
using System.Collections;

public class CraneEnergyController : MonoBehaviour {

	public static CraneEnergyController instance;

	private static int progressBarSize = 100;
	private static float holdingCost = 0.2f; // You can hold an object 1/holdingCost seconds (5 seconds).
	private static float pickingUpCost = 0.05f; // constant cost of picking up - even if you failed
	private static float restoreVelocity = 0.033f; // It needs 1/restoreVelocity seconds to regenerate (30 seconds).

	private GUIStyle borderStyle;
	private GUIStyle outerStyle;
	private GUIStyle energyStyle;
	private GUIStyle lowEnergyStyle;
	private float energy = 1.0f;

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
		GUI.BeginGroup(new Rect ((Screen.width / 4) *3 - progressBarSize / 2, Screen.height - 20, progressBarSize, 10));
			GUI.Box (new Rect (0, 0, progressBarSize, 10), "", borderStyle);
			GUI.Box (new Rect (1, 1, progressBarSize - 2, 8), "", outerStyle);
			if (energy >= pickingUpCost)
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
				isHeld = false;
				gameObject.SendMessage("PickUp");
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

	public void holding(bool isHeld)
	{
		this.isHeld = isHeld;
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
