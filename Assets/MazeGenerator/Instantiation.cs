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
		private static int planeSizeX = 40;
		private static int planeSizeZ = 34;
		private static int offsetZ = 6;

		private float spaceX = planeSizeX / (sizeX * 2f);
		private float spaceZ = planeSizeZ / (sizeZ * 2f);

		// Use this for initialization
		void Start () {
			
			Labirynth labirynth = new Labirynth (sizeX, sizeZ);
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
			for (int z=0; z<=sizeZ * 2; z+=2) 
			{
				for (int x=0; x<=sizeX * 2; x+=2)
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
			for (int z=0; z<=sizeZ * 2; z+=2) 
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
				for (int x=0; x<=sizeX * 2; x+=2)
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
	}
}
