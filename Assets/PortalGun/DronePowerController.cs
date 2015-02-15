using UnityEngine;
using System.Collections;

public class DronePowerController : MonoBehaviour {

	public static DronePowerController instance;

	private static int STEPS = 11;

	private const float settingUpCost = 0.30f; // constant cost of setting up a portal
	private const float usingStunGunCost = 0.20f; // constant cost of using stun gun
	private const float restoreVelocity = 0.066f; // It needs 1/restoreVelocity seconds to regenerate (15 seconds).

	private float energy = 1f;

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
		projectorMaterial = transform.GetChild (1).gameObject.transform.GetChild(0).gameObject.GetComponent<Projector> ().material;
		projectorMaterial.SetTexture("_ShadowTex", projectorTextures [energyIndex]);
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
		if ((int) (energy * 100/(STEPS-1)) != energyIndex)
		{
			energyIndex = (int) (energy * 100/(STEPS-1));
			projectorMaterial.SetTexture("_ShadowTex", projectorTextures [energyIndex]);
		}
	}

	private float getMinCost()
	{
		float minCost = 1f;
		if (LevelFinishedController.instance.isTeleportEnabled())
		{
			minCost = settingUpCost;
		}
		
		if (LevelFinishedController.instance.isStunGunEnabled())
		{
			if (minCost > usingStunGunCost)
			{
				minCost = usingStunGunCost;
			}
		}
		
		return minCost;
	}
}
