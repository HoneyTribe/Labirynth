using UnityEngine;
using System;
using System.Collections.Generic;

public class First : Puzzle
{
	private const int sizeX = 3;
	private const int sizeZ = 3;

	private Rect position;
	private Entrance entrance;

	private int mazeSizeX;
	private int mazeSizeZ;

	public First()
	{
		mazeSizeX = LevelFinishedController.instance.getMazeSizeX ();
		mazeSizeZ = LevelFinishedController.instance.getMazeSizeZ ();
		position = new Rect (2 * UnityEngine.Random.Range (0, mazeSizeX - sizeX + 1) + 1,
		                     2 * UnityEngine.Random.Range (0, mazeSizeZ - sizeZ) + 1,
		                     sizeX * 2 - 1, sizeZ * 2 - 1);

		List<Entrance> options = new List<Entrance> ();
		if (position.x - 1 != 0) 
		{
			options.Add (new Entrance(new Vector2(position.x - 1, position.y),
			                          new Vector2(position.x, position.y),
			                          new Vector2(position.x + 3, position.y),
			                          new Vector2(position.x + 3, position.y + 1)));

		}
		if (position.x + position.width != mazeSizeX * 2) 
		{
			options.Add (new Entrance(new Vector2(position.x + position.width, position.y),
			                          new Vector2(position.x + position.width - 1, position.y),
			                          new Vector2(position.x + position.width - 4, position.y),
			                          new Vector2(position.x + position.width - 4, position.y + 1)));
		}
		if (position.y - 1 != 0) 
		{
			options.Add (new Entrance(new Vector2(position.x, position.y - 1),
			                          new Vector2(position.x, position.y),
			                          new Vector2(position.x, position.y + 3),
			                          new Vector2(position.x + 1, position.y + 3)));
		}
		if (position.y + position.height != mazeSizeZ * 2) 
		{
			options.Add (new Entrance(new Vector2(position.x, position.y + position.height),
			                          new Vector2(position.x, position.y + position.height - 1),
			                          new Vector2(position.x, position.y + position.height - 4),
			                          new Vector2(position.x + 1, position.y + position.height - 4)));
		}

		int side = UnityEngine.Random.Range (0, options.Count);
		entrance = options[side];

	}

	public bool[,] getGrid()
	{
		bool [,] grid = new bool[mazeSizeX * 2 + 1, mazeSizeZ * 2 + 1];
		for (int i=(int)position.x; i < position.x + position.width; i++)
		{
			for (int j=(int)position.y; j < position.y + position.height; j++)
			{
				grid[i,j] = true;
			}
		}
		grid [(int) entrance.getWallEntrance().x, (int) entrance.getWallEntrance().y] = true;
		grid [(int) entrance.getBlockingWall().x, (int) entrance.getBlockingWall().y] = false;
		grid [(int) entrance.getBlockingPillar().x, (int) entrance.getBlockingPillar().y] = false;

		return grid;
	}

	public Entrance getEntrance()
	{
		return entrance;
	}
}