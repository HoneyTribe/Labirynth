using UnityEngine;

namespace AssemblyCSharp
{
	public class Instantiation : MonoBehaviour {

		public GameObject horisontalWallPrefab;
		public GameObject verticalWallPrefab;
		public GameObject smallWallPrefab;

		private int sizeX = 9;
		private int sizeZ = 9;
		private int planeSizeX = 40;
		private int planeSizeZ = 34;
		private int offsetZ = 6;

		// Use this for initialization
		void Start () {

			Labirynth labirynth = new Labirynth (sizeX, sizeZ);
			labirynth.generate ();
			float spaceX = planeSizeX / (sizeX * 2f);
			float spaceZ = planeSizeZ / (sizeZ * 2f);

			// Render All Small Walls
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

			// Horisontal Walls
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

			// Vertical Walls
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
