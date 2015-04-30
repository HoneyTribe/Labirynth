using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class PuzzleTemplate : ScriptableObject, Puzzle
{
	protected int sizeX;
	protected int sizeZ;

	private Rect position;
	private Entrance entrance;

	private float scaleFactorX;
	private float scaleFactorZ;
	private int mazeSizeX;
	private int mazeSizeZ;

	private GameObject monsterPrefab;
	private GameObject lazyMonsterPrefab;
	private GameObject blockPrefab;
	private GameObject keyPrefab;
	private GameObject triggerPrefab;
	private GameObject triggerHorizontalPrefab;
	private GameObject triggerNewMazePrefab;

	protected int extX;
	protected int extZ;
	protected int internalSize; 

	protected int templateSizeX;
	protected int templateSizeZ;
	protected int[,] template;

	protected int[,] extededTemplate; 

	public PuzzleTemplate()
	{
		scaleFactorX = 2 * Instantiation.instance.getSpaceX() - 1f;
		scaleFactorZ = 2 * Instantiation.instance.getSpaceZ() - 1f;
		mazeSizeX = LevelFinishedController.instance.getMazeSizeX ();
		mazeSizeZ = LevelFinishedController.instance.getMazeSizeZ ();

		monsterPrefab = (GameObject) Resources.Load("Monster");
		lazyMonsterPrefab = (GameObject) Resources.Load("LazyMonster");
		blockPrefab = (GameObject) Resources.Load("Textured Wall");
		keyPrefab = (GameObject) Resources.Load("KeyContainer");
		triggerPrefab = (GameObject) Resources.Load("Trigger");
		triggerHorizontalPrefab = (GameObject) Resources.Load("TriggerHorizontal");
		triggerNewMazePrefab = (GameObject) Resources.Load("TriggerNewMaze");
	}

	public void init()
	{
		position = new Rect (2 * UnityEngine.Random.Range (0, mazeSizeX - sizeX + 1) + 1,
		                     2 * UnityEngine.Random.Range (0, mazeSizeZ - sizeZ) + 1,
		                     sizeX * 2 - 1, sizeZ * 2 - 1);
		
		createExtendedTemplate ();
	}

	public int[,] getGrid()
	{
		int [,] grid = new int[mazeSizeX * 2 + 1, mazeSizeZ * 2 + 1];
		for (int i=(int)position.x; i < position.x + position.width; i++)
		{
			for (int j=(int)position.y; j < position.y + position.height; j++)
			{
				grid[i,j] = extededTemplate[j-(int)position.y, i-(int)position.x];
			}
		}

		return grid;
	}

	private void createExtendedTemplate()
	{
		int extSizeX = sizeX * 2 - 1 - templateSizeX;
		int extSizeZ = sizeZ * 2 - 1 - templateSizeZ;

		int orgi = 0; // template index
		for (int i=0; i < sizeZ * 2 - 1; i++)
		{
			// duplicate row ? copy from extended
			if ((i >= extZ + 2) && (i < extZ + 2 + extSizeZ))
			{
				for (int j=0; j < sizeX * 2 - 1; j++)
				{
					extededTemplate[i,j] = extededTemplate[extZ, j];
				}
				i++;
				for (int j=0; j < sizeX * 2 - 1; j++)
				{
					extededTemplate[i,j] = extededTemplate[extZ + 1, j];
				}
			}
			else
			{
				int orgj = 0; // template index
				for (int j=0; j < sizeX * 2 - 1; j++)
				{
					// duplicate column? insert from template
					if ((j >= extX + 2) && (j < extX + 2 + extSizeX))
					{
						extededTemplate[i,j] = template[orgi,extX];
						j++;
						extededTemplate[i,j] = template[orgi,extX + 1];
					}
					else
					{
						extededTemplate[i,j] = template[orgi, orgj];
						orgj++;
					}
				}
				orgi++;
			}
		}
	}

	public void create()
	{
		int[,] grid = getGrid ();
		int monsterNum = 0;
		int keyNum = LevelFinishedController.instance.getNumberOfKeys ();

		for (int j=0; j < mazeSizeX * 2; j++)
		{
			for (int i=0; i < mazeSizeZ * 2; i++)
			{
				if (grid[i,j] == (int) TileType.BLOCK)
				{
					createBlock (i, j);
				}
				if (grid[i,j] == (int) TileType.MONSTER)
				{
					createMonster (i, j, monsterNum);
					monsterNum ++;
				}
				if (grid[i,j] == (int) TileType.LAZYMONSTER)
				{
					createLazyMonster (i, j, monsterNum);
					monsterNum ++;
				}
				if (grid[i,j] == (int) TileType.KEY)
				{
					if (keyNum != 0)
					{
						createKey (i, j, keyNum);
						keyNum --;
					}
				}
				if (grid[i,j] == (int) TileType.TRIGGER)
				{
					createTrigger (i, j);
				}
				if (grid[i,j] == (int) TileType.TRIGGERHORIZONTAL)
				{
					createTriggerHorizontal (i, j);
				}
				if (grid[i,j] == (int) TileType.TRIGGERNEWMAZE)
				{
					createTriggerNewMaze (i, j);
				}
				if (grid[i,j] == (int) TileType.DECOY)
				{
					createDecoy (i, j);
				}
			}
		}
	}

		private void createBlock(int x, int z)
		{
			Vector3 pos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * x,
			                           blockPrefab.transform.position.y,
			                           Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * z);			
			GameObject block = (GameObject) Instantiate (blockPrefab, pos, Quaternion.Euler(0, 0, 0));
			block.name = "Block";
			block.transform.localScale = new Vector3(scaleFactorX - Instantiation.compensatePillarInnerRadius, 
			                                         blockPrefab.transform.localScale.y,
			                                         scaleFactorZ - Instantiation.compensatePillarInnerRadius);
			block.AddComponent<BlockController> ();
		}
		/*
		private void createMonster(int x, int z, int monsterNum)
		{
		Vector3 monsterPos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * x,
		                                  monsterPrefab.transform.position.y,
		                                  Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * (z + 2 * (monsterNum%internalSize)));			
		GameObject monster = MonsterCreationController.instance.InstantiateMonster (monsterPrefab, monsterPos);
		
		monster.GetComponent<AbstractMonsterController> ().setSpeed (4.5f+(monsterNum+1* 1f));
			
		StandardMonsterController standardMonsterController = monster.GetComponent<StandardMonsterController> ();
		*/

		private void createMonster(int x, int z, int monsterNum)
		{
			Vector3 monsterPos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * x,
			                                  monsterPrefab.transform.position.y,
			                                  Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * z);			
			GameObject monster = MonsterCreationController.instance.InstantiateMonster (monsterPrefab, monsterPos);
			
			monster.GetComponent<AbstractMonsterController> ().setSpeed (4.5f+(monsterNum+1* 1f));
			
			StandardMonsterController standardMonsterController = monster.GetComponent<StandardMonsterController> ();

		if (standardMonsterController != null)
		{
			Vector3 pos1 = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * x,
			                            monsterPrefab.transform.position.y,
			                            Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * z);		
			Vector3 pos2 = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * x,
			                            monsterPrefab.transform.position.y,
			                            Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * (z + 2 * (internalSize - 1)));		
			
			standardMonsterController.AddGuardingPosition(pos1);
			standardMonsterController.AddGuardingPosition(pos2);
		}
		
		}

		private void createLazyMonster(int x, int z, int monsterNum)
		{
			Vector3 monsterPos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * x,
			                                  monsterPrefab.transform.position.y,
			                                  Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * z);			
			GameObject monster = MonsterCreationController.instance.InstantiateMonster (lazyMonsterPrefab, monsterPos);
			monster.GetComponent<AbstractMonsterController> ().setSpeed (4.5f+(monsterNum+1* 1f));
		}

		private void createKey(int x, int z, int keyNum)
		{
			Vector3 keyPos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * x,
			                              keyPrefab.transform.position.y,
			                              Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * z);			
			Instantiate (keyPrefab, keyPos, Quaternion.Euler(0, 0, 0));
		}

		private void createTrigger(int x, int z)
		{
			Vector3 triggerPos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * x,
			                              triggerPrefab.transform.position.y,
			                              Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * z);			
			Instantiate (triggerPrefab, triggerPos, Quaternion.Euler(0, 0, 0));
		}

		private void createTriggerHorizontal(int x, int z)
		{
			Vector3 triggerHorizontalPos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * x,
			                                  triggerHorizontalPrefab.transform.position.y,
			                                  Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * z);			
			Instantiate (triggerHorizontalPrefab, triggerHorizontalPos, Quaternion.Euler(0, 0, 0));
		}
		private void createTriggerNewMaze(int x, int z)
		{
			Vector3 triggerNewMazePos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * x,
			                                            triggerNewMazePrefab.transform.position.y,
			                                            Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * z);			
			Instantiate (triggerNewMazePrefab, triggerNewMazePos, Quaternion.Euler(0, 0, 0));
		}
		private void createDecoy(int x, int z)
		{
			Vector3 decoyMazePos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * x,
			                                    1f,
			                                    Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * z);			
			DeviceController.instance.setMovement(decoyMazePos);
			LevelFinishedController.instance.setDecoyFixed (true);
		}

	public void finish()
	{
	}
}