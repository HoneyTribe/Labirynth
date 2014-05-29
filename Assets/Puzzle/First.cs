using UnityEngine;
using System;
using System.Collections.Generic;

public class First : ScriptableObject, Puzzle
{
	private const int sizeX = 7;
	private const int sizeZ = 3;

	private Rect position;
	private Entrance entrance;

	private int mazeSizeX;
	private int mazeSizeZ;

	private GameObject monsterPrefab;
	private GameObject blockPrefab;

	public First()
	{
		mazeSizeX = LevelFinishedController.instance.getMazeSizeX ();
		mazeSizeZ = LevelFinishedController.instance.getMazeSizeZ ();
		position = new Rect (2 * UnityEngine.Random.Range (0, mazeSizeX - sizeX + 1) + 1,
		                     2 * UnityEngine.Random.Range (0, mazeSizeZ - sizeZ) + 1,
		                     sizeX * 2 - 1, sizeZ * 2 - 1);

		List<Entrance> options = new List<Entrance> ();
		List<List<int>> monsters = new List<List<int>> ();
		if (position.x - 1 != 0) 
		{
			options.Add (new Entrance(new Vector2(position.x - 1, position.y),
			                          new Vector2(position.x, position.y),
			                          new Vector2(position.x + 3, position.y),
			                          new Vector2(position.x + 3, position.y + 1),
			                          new Vector2(position.x + 2, position.y)));
		}
		if (position.x + position.width != mazeSizeX * 2) 
		{
			options.Add (new Entrance(new Vector2(position.x + position.width, position.y),
			                          new Vector2(position.x + position.width - 1, position.y),
			                          new Vector2(position.x + position.width - 4, position.y),
			                          new Vector2(position.x + position.width - 4, position.y + 1),
			                          new Vector2(position.x + position.width - 3, position.y)));
		}
		if (position.y - 1 != 0) 
		{
			options.Add (new Entrance(new Vector2(position.x, position.y - 1),
			                          new Vector2(position.x, position.y),
			                          new Vector2(position.x, position.y + 3),
			                          new Vector2(position.x + 1, position.y + 3),
			                          new Vector2(position.x, position.y + 2)));
		}
		if (position.y + position.height != mazeSizeZ * 2) 
		{
			options.Add (new Entrance(new Vector2(position.x, position.y + position.height),
			                          new Vector2(position.x, position.y + position.height - 1),
			                          new Vector2(position.x, position.y + position.height - 4),
			                          new Vector2(position.x + 1, position.y + position.height - 4),
			                          new Vector2(position.x, position.y + position.height - 3)));
		}

		int side = UnityEngine.Random.Range (0, options.Count);
		entrance = options[side];

		monsterPrefab = (GameObject) Resources.Load("Monster");
		blockPrefab = (GameObject) Resources.Load("Textured Wall");
	}

	public int[,] getGrid()
	{
		int [,] grid = new int[mazeSizeX * 2 + 1, mazeSizeZ * 2 + 1];
		for (int i=(int)position.x; i < position.x + position.width; i++)
		{
			for (int j=(int)position.y; j < position.y + position.height; j++)
			{
				grid[i,j] = Labirynth.GRID;
			}
		}
		grid [(int) entrance.getWallEntrance().x, (int) entrance.getWallEntrance().y] = Labirynth.MAZE; // OR GRID
		grid [(int) entrance.getBlockingWall().x, (int) entrance.getBlockingWall().y] = Labirynth.WALL;
		grid [(int) entrance.getBlockingPillar().x, (int) entrance.getBlockingPillar().y] = Labirynth.WALL;

		return grid;
	}

	public void create()
	{
		float scaleFactorX = 2 * Instantiation.instance.getSpaceX() - 1f;
		float scaleFactorZ = 2 * Instantiation.instance.getSpaceZ() - 1f;
		Vector3 pos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * entrance.getEntrance().x,
		                           blockPrefab.transform.position.y,
		                           Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * entrance.getEntrance().y);			
		GameObject block = (GameObject) Instantiate (blockPrefab, pos, Quaternion.Euler(0, 0, 0));
		block.name = "Block";
		block.transform.localScale = new Vector3(scaleFactorX - Instantiation.compensatePillarInnerRadius, 
		                                         blockPrefab.transform.localScale.y,
		                                         scaleFactorZ - Instantiation.compensatePillarInnerRadius);
		block.AddComponent<Rigidbody>();
		block.rigidbody.useGravity = true;
		block.rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;

		int monsterNum = 0;
		for(int i=0; i < sizeX * 2; i+=2)
		{
			if ((entrance.getEntrance().x == position.x + i) ||
				(entrance.getBlockingSpace().x == position.x + i))
			{
				continue;
			}
			Vector3 monsterPos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * (position.x + i),
			                           monsterPrefab.transform.position.y,
			                           Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * (position.y + monsterNum%(sizeZ+1)));			
			GameObject monster = (GameObject) Instantiate (monsterPrefab, monsterPos, Quaternion.Euler(0, 0, 0));

			monster.GetComponent<AbstractMonsterController> ().setSpeed (5f);

			StandardMonsterController standardMonsterController = monster.GetComponent<StandardMonsterController> ();
			if (standardMonsterController != null)
			{
				Vector3 pos1 = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * (position.x + i),
				                            monsterPrefab.transform.position.y,
				                            Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * position.y);		
				Vector3 pos2 = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * (position.x + i),
				                            monsterPrefab.transform.position.y,
				                            Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * (position.y + sizeZ+1));		

				standardMonsterController.AddGuardingPosition(pos1);
				standardMonsterController.AddGuardingPosition(pos2);
			}

			monsterNum++;
		}
	}
}