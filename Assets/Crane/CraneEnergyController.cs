using UnityEngine;
using System.Collections;

public class CraneEnergyController : MonoBehaviour {

	public static CraneEnergyController instance;

	private static int STEPS = 11;

	private const float holdingCost = 0.2f; // You can hold an object 1/holdingCost seconds (5 seconds).
	private const float pickingUpCost = 0f; // constant cost of picking up - even if you failed
	private const float restoreVelocity = 0.066f; // It needs 1/restoreVelocity seconds to regenerate (15 seconds).
	private const float activationCost = 0.3f; 
	private const float smashingCost = 0.5f; // Wall smashing takes object 1/smashingCost seconds (2 seconds).

	private float energy = 1.0f;

	private bool isHeld;
	private bool beingSmashed;

	private int energyIndex = STEPS-1;
	private Texture[] projectorTextures = new Texture[STEPS];
	private Material projectorMaterial;

	void Start()
	{
		instance = this;
		int step = 100/(STEPS-1);
		for (int i=0; i<STEPS; i++)
		{
			projectorTextures[i] = (Texture2D) Resources.Load("EnergyBar/EnergyBar_target_" + i*step, typeof(Texture2D));
		}
		projectorMaterial = transform.GetChild (2).gameObject.transform.GetChild(0).gameObject.GetComponent<Projector> ().material;
		projectorMaterial.SetTexture("_ShadowTex", projectorTextures [energyIndex]);
		//color = new Color(0.85f,0.82f,0.3f);
		gameObject.transform.GetChild (2).renderer.material.SetColor("_Color",Color.green);
	}

	void Update()
	{
		if (isHeld)
		{
			changeEnergy (-Time.deltaTime * holdingCost);
			if (energy == 0f)
			{
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
		if ((int) (energy * 100/(STEPS-1)) != energyIndex)
		{
			energyIndex = (int) (energy * 100/(STEPS-1));
			projectorMaterial.SetTexture("_ShadowTex", projectorTextures [energyIndex]);
		}
	}

	private float getMinCost()
	{
		float minCost = 1f;
		if (LevelFinishedController.instance.isPickingUpEnabled())
		{
			minCost = pickingUpCost;
		}
		
		if (LevelFinishedController.instance.isSmashingEnabled())
		{
			if (minCost > 1f)
			{
				minCost = 1f;
			}
		}
		
		return minCost;
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
