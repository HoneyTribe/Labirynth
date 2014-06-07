using UnityEngine;
using System;
using System.Collections.Generic;

public class CranePuzzle : ScriptableObject, Puzzle
{
	private const int sizeX = 5;
	private const int sizeZ = 6;

	private Rect position;
	private Entrance entrance;

	private int mazeSizeX;
	private int mazeSizeZ;

	private GameObject monsterPrefab;
	private GameObject blockPrefab;
	private GameObject keyPrefab;

	private int extX = 2;
	private int extZ = 2;

	private int templateSizeX = 7;
	private int templateSizeZ = 9;
	private int[,] template = new int[9, 7] {{2,2,2,2,2,2,2},
											 {2,0,0,0,0,0,2},
											 {2,2,2,2,2,0,2},
											 {2,2,2,2,2,0,2},
											 {2,2,2,2,2,0,2},
											 {2,2,2,2,2,0,2},
											 {2,2,2,2,2,0,2},
											 {0,0,0,0,2,0,2},
										     {0,0,0,0,2,2,2}};
	private int[,] extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 

	public CranePuzzle()
	{
		mazeSizeX = LevelFinishedController.instance.getMazeSizeX ();
		mazeSizeZ = LevelFinishedController.instance.getMazeSizeZ ();
		position = new Rect (2 * UnityEngine.Random.Range (0, mazeSizeX - sizeX + 1) + 1,
		                     2 * UnityEngine.Random.Range (0, mazeSizeZ - sizeZ) + 1,
		                     sizeX * 2 - 1, sizeZ * 2 - 1);

		createExtendedTemplate ();

		monsterPrefab = (GameObject) Resources.Load("Monster");
		blockPrefab = (GameObject) Resources.Load("Textured Wall");
		keyPrefab = (GameObject) Resources.Load("KeyContainer");
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
		/*float scaleFactorX = 2 * Instantiation.instance.getSpaceX() - 1f;
		float scaleFactorZ = 2 * Instantiation.instance.getSpaceZ() - 1f;
		Vector3 pos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * entrance.getEntrance().x,
		                           blockPrefab.transform.position.y,
		                           Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * entrance.getEntrance().y);			
		GameObject block = (GameObject) Instantiate (blockPrefab, pos, Quaternion.Euler(0, 0, 0));
		block.name = "Block";
		block.transform.localScale = new Vector3(scaleFactorX - Instantiation.compensatePillarInnerRadius, 
		                                         blockPrefab.transform.localScale.y,
		                                         scaleFactorZ - Instantiation.compensatePillarInnerRadius);
		block.AddComponent<BlockController> ();

		int monsterNum = 0;
		int start = 0;
		if (entrance.getEntrance().x == position.x)
		{
			start = 4;
		}
		for(int i=0; i < (sizeX - 2) * 2; i+=2)
		{
			Vector3 monsterPos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * (position.x + i + start),
			                           monsterPrefab.transform.position.y,
			                           Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * (position.y + monsterNum%(sizeZ+1)));			
			GameObject monster = MonsterCreationController.instance.InstantiateMonster (monsterPrefab, monsterPos);

			monster.GetComponent<AbstractMonsterController> ().setSpeed (5f);

			StandardMonsterController standardMonsterController = monster.GetComponent<StandardMonsterController> ();
			if (standardMonsterController != null)
			{
				Vector3 pos1 = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * (position.x + i + start),
				                            monsterPrefab.transform.position.y,
				                            Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * position.y);		
				Vector3 pos2 = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * (position.x + i + start),
				                            monsterPrefab.transform.position.y,
				                            Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * (position.y + sizeZ+1));		

				standardMonsterController.AddGuardingPosition(pos1);
				standardMonsterController.AddGuardingPosition(pos2);
			}

			monsterNum++;
		}

		int keyNum = LevelFinishedController.instance.getNumberOfKeys ();
		for(int j=0; j < sizeZ * 2; j+=2)
		{
			for(int i=0; i < (sizeX - 2) * 2; i+=2)
			{
				if (keyNum == 0)
				{
					continue;
				}
				keyNum--;
				Vector3 keyPos = new Vector3 (-Instantiation.planeSizeX/2f + Instantiation.instance.getSpaceX() * (position.x + i + start),
				                              keyPrefab.transform.position.y,
				                              Instantiation.offsetZ + Instantiation.planeSizeZ/2f - Instantiation.instance.getSpaceZ() * (position.y + j));			
				Instantiate (keyPrefab, keyPos, Quaternion.Euler(0, 0, 0));
			}
		}*/
	}
}