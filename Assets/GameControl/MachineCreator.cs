using System;

public class MachineCreator
{
	private bool distractionEnabled;
	private bool itemActivationEnabled;
	private bool pickingUpEnabled;
	private bool smashingEnabled;
	private bool teleportEnabled;
	private bool stunGunEnabled;

	public MachineCreator (bool distractionEnabled, bool itemActivationEnabled,
	                       bool pickingUpEnabled, bool smashingEnabled,
	                       bool teleportEnabled, bool stunGunEnabled)
	{
		this.distractionEnabled = distractionEnabled;
		this.itemActivationEnabled = itemActivationEnabled;
		this.pickingUpEnabled = pickingUpEnabled;
		this.smashingEnabled = smashingEnabled;
		this.teleportEnabled = teleportEnabled;
		this.stunGunEnabled = stunGunEnabled;
	}

	public bool isDistractionEnabled()
	{
		return distractionEnabled;
	}

	public bool isItemActivationEnabled()
	{
		return itemActivationEnabled;
	}

	public bool isPickingUpEnabled()
	{
		return pickingUpEnabled;
	}

	public bool isSmashingEnabled()
	{
		return smashingEnabled;
	}

	public bool isTeleportEnabled()
	{
		return teleportEnabled;
	}

	public bool isStunGunEnabled()
	{
		return stunGunEnabled;
	}

}


