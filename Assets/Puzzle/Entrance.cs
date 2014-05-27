using UnityEngine;
using System;

public class Entrance
{
	private Vector2 wallEntrance;
	private Vector2 entrance;
	private Vector2 blockingWall;
	private Vector2 blockingPillar;
	private Vector2 blockingSpace;

	public Entrance (Vector2 wallEntrance, Vector2 entrance, Vector2 blockingWall, Vector2 blockingPillar, Vector2 blockingSpace)
	{
		this.wallEntrance = wallEntrance;
		this.entrance = entrance;
		this.blockingWall = blockingWall;
		this.blockingPillar = blockingPillar;
		this.blockingSpace = blockingSpace;
	}

	public Vector2 getWallEntrance()
	{
		return this.wallEntrance;
	}

	public Vector2 getEntrance()
	{
		return this.entrance;
	}

	public Vector2 getBlockingWall()
	{
		return this.blockingWall;
	}

	public Vector2 getBlockingPillar()
	{
		return this.blockingPillar;
	}

	public Vector2 getBlockingSpace()
	{
		return this.blockingSpace;
	}
}


