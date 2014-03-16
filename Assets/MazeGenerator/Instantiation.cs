using UnityEngine;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	public class Instantiation : MonoBehaviour {

		public GameObject horisontalWallPrefab;
		public GameObject verticalWallPrefab;
		public GameObject smallWallPrefab;
		public GameObject keyPrefab;

		private static int sizeX = 9;
		private static int sizeZ = 9;
		public static int planeSizeX = 40;
		public static int planeSizeZ = 34;
		private static int offsetZ = 6;

		private static float spaceX = planeSizeX / (sizeX * 2f);
		private static float spaceZ = planeSizeZ / (sizeZ * 2f);

		private Labirynth labirynth;

		// Use this for initialization
		void Start () {
			
			labirynth = new Labirynth (sizeX, sizeZ);
			labirynth.generate ();
			drawKeys (labirynth.getKeys ());
			drawSmallWalls (labirynth);
			drawHorisontalWalls (labirynth);
			drawVerticalWalls (labirynth);
		}	

		void drawKeys(List<KeyPosition> keys)
		{
			keys.Sort(
				delegate(KeyPosition obj1, KeyPosition obj2)
				{
					return obj2.getDistance().CompareTo(obj1.getDistance());
				}
			);
			for (int i=0; i<ScoreController.numberOfKeys; i++) 
			{
				Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * keys[i].getPosition().x,
				                           keyPrefab.transform.position.y,
				                           offsetZ + planeSizeZ/2f - spaceZ * keys[i].getPosition().y);
				Quaternion rot = Quaternion.Euler(0, 0, 0);
				Instantiate (keyPrefab, pos, rot); 
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
						Quaternion rot = Quaternion.Euler(0, 0, 0);
						Instantiate (smallWallPrefab, pos, rot); 
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
						horisontalWallPrefab.transform.localScale = new Vector3(scaleFactorX, 2, 1);
						Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * x,
						                           horisontalWallPrefab.transform.position.y,
						                           offsetZ + planeSizeZ/2f - spaceZ * z);
						Instantiate (horisontalWallPrefab, pos, Quaternion.Euler(0, 0, 0)); 
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
						verticalWallPrefab.transform.localScale = new Vector3(1, 2, scaleFactorZ);
						Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * x,
						                           verticalWallPrefab.transform.position.y,
						                           offsetZ + planeSizeZ/2f - spaceZ * z);
						Instantiate (verticalWallPrefab, pos, Quaternion.Euler(0, 0, 0)); 
					}
				}
				
			}
		}

		public Vector3 giveMeNextPosition(Vector3 currentPosition, Vector3 playerPosition)
		{
			Vector2 currentMazePos = transformToMazeCoordinates (currentPosition);
			Vector2 playerMazePos = transformToMazeCoordinates (playerPosition);
			if (isInside(currentPosition))
			{
				if (!isInside(playerPosition) && currentMazePos.Equals(labirynth.getStart()))
				{
					return new Vector3 (currentPosition.x, currentPosition.y, currentPosition.z - spaceZ * 2);
				}

				LinkedList<Vector2> path = labirynth.findPathBetweenCells(currentMazePos, playerMazePos);
				return transformToWorldCoordinates(path.First.Value, currentPosition.y);
			}
			else
			{
				if (isInside(playerPosition))
				{
					return transformToWorldCoordinates(labirynth.getStart(), currentPosition.y);
				}
				else
				{
					Vector3 localMove = new Vector3(playerPosition.x - currentPosition.x, 0, playerPosition.z - currentPosition.z).normalized;
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

		private Vector2 transformToMazeCoordinates(Vector3 localPosition)
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
	}
}
