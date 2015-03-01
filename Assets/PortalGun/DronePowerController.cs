using UnityEngine;
using System.Collections;

public class DronePowerController : MonoBehaviour {

	public static DronePowerController instance;

	public Material projectorMaterial;

	private static int STEPS = 21;

	private const float settingUpCost = 0.30f; // constant cost of setting up a portal
	private const float usingStunGunCost = 0.20f; // constant cost of using stun gun
	private const float restoreVelocity = 0.066f; // It needs 1/restoreVelocity seconds to regenerate (15 seconds).

	private float energy = 1f;

	private int energyIndex = STEPS-1;
	private Texture[] projectorTexturesBlue = new Texture[STEPS];
	private Texture[] projectorTexturesRed  = new Texture[STEPS];

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
		projectorMaterial.SetTexture("_ShadowTex", projectorTexturesBlue [energyIndex]);
	}

	void Update()
	{
		changeEnergy (Time.deltaTime * restoreVelocity);
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
		if (LevelFinishedController.instance.isTeleportEnabled())
		{
			minCost = settingUpCost;
		}
		
		if (LevelFinishedController.instance.isStunGunEnabled())
		{
			if (usingStunGunCost > minCost)
			{
				minCost = usingStunGunCost;
			}
		}
		
		return minCost;
	}
}
