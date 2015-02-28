using UnityEngine;
using System.Collections;

public class CraneEnergyController : MonoBehaviour {

	public static CraneEnergyController instance;

	private static int STEPS = 21;

	private const float holdingCost = 0.2f; // You can hold an object 1/holdingCost seconds (5 seconds).
	private const float pickingUpCost = 0f; // constant cost of picking up - even if you failed
	private const float restoreVelocity = 0.066f; // It needs 1/restoreVelocity seconds to regenerate (15 seconds).
	private const float activationCost = 0.3f; 
	private const float smashingCost = 0.5f; // Wall smashing takes object 1/smashingCost seconds (2 seconds).

	private float energy = 1.0f;

	private bool isHeld;
	private bool beingSmashed;

	private int energyIndex = STEPS-1;
	private Texture[] projectorTexturesBlue = new Texture[STEPS];
	private Texture[] projectorTexturesRed  = new Texture[STEPS];
	private Material projectorMaterial;

	void Start()
	{
		instance = this;
		int step = 100/(STEPS-1);
		projectorTexturesBlue[0] = (Texture2D) Resources.Load("EnergyBar/Gray/Energy_Bar_target_gray", typeof(Texture2D));
		projectorTexturesRed[0] = (Texture2D) Resources.Load("EnergyBar/Gray/Energy_Bar_target_gray", typeof(Texture2D));
		for (int i=1; i<STEPS; i++)
		{
			projectorTexturesBlue[i] = (Texture2D) Resources.Load("EnergyBar/Bleu/Energy_Bar_target_bleu_" + i*step, typeof(Texture2D));
			projectorTexturesRed[i] = (Texture2D) Resources.Load("EnergyBar/Red/Energy_Bar_target_red_" + i*step, typeof(Texture2D));
		}
		projectorMaterial = transform.GetChild (2).gameObject.transform.GetChild(0).gameObject.GetComponent<Projector> ().material;
		projectorMaterial.SetTexture("_ShadowTex", projectorTexturesBlue [energyIndex]);
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
		if ((int) (energy * (STEPS-1)) != energyIndex)
		{
			energyIndex = (int) (energy * (STEPS-1));
			if (energy > getMinCost())
			{
				projectorMaterial.SetTexture("_ShadowTex", projectorTexturesBlue [energyIndex]);
			}
			else
			{
				projectorMaterial.SetTexture("_ShadowTex", projectorTexturesRed [energyIndex]);
			}
		}
	}

	private float getMinCost()
	{
		float minCost = 0f;
		if (LevelFinishedController.instance.isPickingUpEnabled())
		{
			minCost = pickingUpCost;
		}
		
		if (LevelFinishedController.instance.isSmashingEnabled())
		{
			if (smashingCost > minCost)
			{
				minCost = smashingCost;
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
