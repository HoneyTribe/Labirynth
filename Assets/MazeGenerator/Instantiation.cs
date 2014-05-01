using UnityEngine;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	public class Instantiation : MonoBehaviour {

		public static Instantiation instance;

		private static float compensatePillarInnerRadius = 0.2f;

		public GameObject wallPrefab;
		public GameObject smallWallPrefab;
		public GameObject keyPrefab;
		public GameObject jumpPrefab;

		public static int planeSizeX = 40;
		public static int planeSizeZ = 34;
		private static int offsetZ = 6;

		private int sizeX;
		private int sizeZ;
		private float spaceX;
		private float spaceZ;

		private Labirynth labirynth;

		// Use this for initialization
		void Start () {
			instance = this;

			sizeX = LevelFinishedController.instance.getMazeSizeX();
			sizeZ = LevelFinishedController.instance.getMazeSizeZ();
			spaceX = planeSizeX / (sizeX * 2f);
			spaceZ = planeSizeZ / (sizeZ * 2f);

			labirynth = new Labirynth (sizeX, sizeZ);
			labirynth.generate ();
			drawMachines ();
			drawDevice ();
			drawKeys (labirynth.getKeys ());
			drawJumps ();
			drawSmallWalls (labirynth);
			drawHorisontalWalls (labirynth);
			drawVerticalWalls (labirynth);
		}	

		void drawMachines()
		{
			if (LevelFinishedController.instance.getLevel() < LevelFinishedController.instance.getFirstLevelWithLightMachine())
			{
				GameObject.Find ("Lighthouse").SetActive(false);
				GameObject.Find ("LightContainer").SetActive(false);
			}

			if (LevelFinishedController.instance.getLevel() < LevelFinishedController.instance.getFirstLevelWithCrane())
			{
				GameObject.Find ("Crane").SetActive(false);
				GameObject.Find ("CraneContainer").SetActive(false);
			}
		}

		void drawDevice()
		{
			if (LevelFinishedController.instance.getLevel() < LevelFinishedController.instance.getFirstLevelWithDevice())
			{
				GameObject.Find ("Device").GetComponent<MeshRenderer>().enabled = false;
			}
		}

		void drawKeys(List<KeyPosition> keys)
		{
			keys.Sort(
				delegate(KeyPosition obj1, KeyPosition obj2)
				{
					return obj2.getDistance().CompareTo(obj1.getDistance());
				}
			);
			for (int i=0; i<LevelFinishedController.instance.getNumberOfKeys(); i++) 
			{
				Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * keys[i].getPosition().x,
				                           keyPrefab.transform.position.y,
				                           offsetZ + planeSizeZ/2f - spaceZ * keys[i].getPosition().y);
				Quaternion rot = Quaternion.Euler(0, 0, 0);
				Instantiate (keyPrefab, pos, rot); 
			}
		}

		void drawJumps()
		{
			if (LevelFinishedController.instance.getLevel() >= LevelFinishedController.instance.getFirstLevelWithJumpItem())
			{
				Vector3 pos = getStart();
				pos.y = 1.5f;
				Quaternion rot = Quaternion.Euler(0, 0, 0);
				Instantiate (jumpPrefab, pos, rot); 
			}
		}

		void drawSmallWalls(Labirynth labirynth)
		{
			for (int z=2; z<=sizeZ * 2; z+=2) // don't draw edges
			{
				for (int x=2; x<=sizeX * 2 - 2; x+=2)  // don't draw edges
				{
					if (!labirynth.getWalls(x, z))
					{
						Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * x,
						                           smallWallPrefab.transform.position.y,
						                           offsetZ + planeSizeZ/2f - spaceZ * z);
						int angle =  Random.Range(0, 4) * 90;
						GameObject obj = (GameObject)Instantiate (smallWallPrefab, pos, Quaternion.Euler(0, angle, 0)); 

						if (z == sizeZ * 2) // last row
						{
							obj.layer = LayerMask.NameToLayer("1stRowMazeWalls");
						}
					}
				}
				
			}
		}

		void drawHorisontalWalls(Labirynth labirynth)
		{
			float scaleFactorX = 2*spaceX - 1f;
			for (int z=2; z<=sizeZ * 2; z+=2) // don't draw edges
			{
				for (int x=1; x<=sizeX * 2 - 1; x+=2)
				{
					if (!labirynth.getWalls(x, z))
					{
						wallPrefab.transform.localScale = new Vector3(scaleFactorX + compensatePillarInnerRadius, 
						                                              wallPrefab.transform.localScale.y,
						                                              wallPrefab.transform.localScale.z);
						Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * x,
						                           wallPrefab.transform.position.y,
						                           offsetZ + planeSizeZ/2f - spaceZ * z);
						GameObject obj = (GameObject) Instantiate (wallPrefab, pos, Quaternion.Euler(0, 0, 0)); 

						if (z == sizeZ * 2) // last row
						{
							obj.layer = LayerMask.NameToLayer("1stRowMazeWalls");
						}
					}
				}
				
			}
		}

		void drawVerticalWalls(Labirynth labirynth)
		{
			float scaleFactorZ = 2*spaceZ - 1f;
			for (int z=1; z<=sizeZ * 2 - 1; z+=2) 
			{
				for (int x=2; x<=sizeX * 2 -2 ; x+=2)  // don't draw edges
				{
					if (!labirynth.getWalls(x, z))		
					{
						wallPrefab.transform.localScale = new Vector3(scaleFactorZ + compensatePillarInnerRadius,
						                                              wallPrefab.transform.localScale.y,
						                                              wallPrefab.transform.localScale.z);
						Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * x,
						                           wallPrefab.transform.position.y,
						                           offsetZ + planeSizeZ/2f - spaceZ * z);
						GameObject obj = (GameObject) Instantiate (wallPrefab, pos, Quaternion.Euler(0, 90, 0));

						if (z == sizeZ * 2 - 1) // last row
						{
							obj.layer = LayerMask.NameToLayer("1stRowMazeWalls");
						}
					}
				}
				
			}
		}

		public Vector3 giveMeNextPosition(Vector3 currentPosition, Vector3 targetPosition)
		{
			Vector2 currentMazePos = transformToMazeCoordinates (currentPosition);
			Vector2 targetMazePos = transformToMazeCoordinates (targetPosition);
			if (isInside(currentPosition))
			{
				if (!isInside(targetPosition) && currentMazePos.Equals(labirynth.getStart()))
				{
					return new Vector3 (currentPosition.x, currentPosition.y, currentPosition.z - spaceZ * 2);
				}

				LinkedList<Vector2> path = labirynth.findPathBetweenCells(currentMazePos, targetMazePos);

				// stop the monster when reaches the device
				if (path.Count == 0)
				{
					return currentPosition;
				}
				else
				{
					return transformToWorldCoordinates(path.First.Value, currentPosition.y);
				}
			}
			else
			{
				if (isInside(targetPosition))
				{
					return transformToWorldCoordinates(labirynth.getStart(), currentPosition.y);
				}
				else
				{
					Vector3 localMove = new Vector3(targetPosition.x - currentPosition.x, 0, targetPosition.z - currentPosition.z).normalized;
					return currentPosition + localMove;
				}
			}
		}

		public int getDistance(Vector3 currentPosition, Vector3 playerPosition)
		{
			Vector2 currentMazePos = transformToMazeCoordinates (currentPosition);
			Vector2 playerMazePos = transformToMazeCoordinates (playerPosition);
			return labirynth.findPathBetweenCells(currentMazePos, playerMazePos).Count;
		}

		public Vector3 getStart()
		{
			return transformToWorldCoordinates(labirynth.getStart(), 0);
		}

		public Vector2 transformToMazeCoordinates(Vector3 localPosition)
		{
			int x = (int)((localPosition.x + planeSizeX/2f) / (2f * spaceX));
			int y = (int)((localPosition.z - offsetZ - planeSizeZ/2f) / (-2f * spaceZ));

			if (isInside(localPosition))
			{
				return new Vector2(x*2+1, y*2+1);
			}
			else
			{
				return labirynth.getStart();
			}
		}

		private Vector3 transformToWorldCoordinates(Vector2 mazePosition, float yPos)
		{
			float xPos = -planeSizeX / 2f + spaceX * mazePosition.x;
			float zPos = offsetZ + planeSizeZ/2f - spaceZ * mazePosition.y;
			return new Vector3 (xPos, yPos, zPos);
		}

		public bool isInside(Vector3 pos)
		{
			return ((pos.x < planeSizeX / 2) && (pos.x > -planeSizeX / 2) &&
			        (pos.z < offsetZ + planeSizeZ / 2) && (pos.z > offsetZ - planeSizeZ / 2));
		}

		public float getSpaceX()
		{
			return spaceX;
		}

		public float getSpaceZ()
		{
			return spaceZ;
		}

		public Vector3 getCentralPosition(Vector3 position)
		{
			if (isInside(position))
			{
				Vector2 mazePosition = transformToMazeCoordinates(position);
				Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * mazePosition.x,
				                           0,
				                           offsetZ + planeSizeZ/2f - spaceZ * mazePosition.y);
				return pos;
			}
			else
			{
				float posZ = position.z - spaceZ;
				if (posZ < -16) // max Z
				{
					posZ = -16;
				}
				return new Vector3(position.x, 0, -16);
			}
		}
	}
}
