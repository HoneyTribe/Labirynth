using UnityEngine;

namespace AssemblyCSharp
{
	public class Instantiation : MonoBehaviour {

		public GameObject wallPrefab;
		public GameObject smallWallPrefab;
		public Light topLight;

		private int dir = 1;
		private float rotationSpeed = 0.5f;
		private int size = 9;
		private int planeSizeX = 40;
		private int planeSizeZ = 40;

		// Use this for initialization
		void Start () {

			Labirynth labirynth = new Labirynth (size);
			labirynth.generate ();
			float spaceX = planeSizeX / (size * 2 + 1);
			float spaceZ = planeSizeZ / (size * 2 + 1);

			// Render All Small Walls
			for (int z=0; z<=size * 2; z+=2) 
			{
				for (int x=0; x<=size * 2; x+=2)
				{
					if (!labirynth.getWalls(x, z))
					{
						Vector3 pos = new Vector3 (-planeSizeX/2 + spaceX + spaceX * x,
						                           smallWallPrefab.transform.position.y,
						                           planeSizeZ/2 - spaceZ - spaceZ * z);
						Quaternion rot = Quaternion.Euler(0, 0, 0);
						Instantiate (smallWallPrefab, pos, rot); 
					}
				}
				
			}

			// Horisontal Walls
			for (int z=0; z<=size * 2; z+=2) 
			{
				for (int x=1; x<=size * 2 - 1; x+=2)
				{
					if (!labirynth.getWalls(x, z))
					{
						Vector3 pos = new Vector3 (-planeSizeX/2 + spaceX + spaceX * x,
						                           wallPrefab.transform.position.y,
						                           planeSizeZ/2 - spaceZ - spaceZ * z);
						Quaternion rot = Quaternion.Euler(0, 0, 0);
						Instantiate (wallPrefab, pos, rot); 
					}
				}

			}

			// Vertical Walls
			for (int z=1; z<=size * 2 - 1; z+=2) 
			{
				for (int x=0; x<=size * 2; x+=2)
				{
					if (!labirynth.getWalls(x, z))
					{
						Vector3 pos = new Vector3 (-planeSizeX/2 + spaceX + spaceX * x,
						                           wallPrefab.transform.position.y,
						                           planeSizeZ/2 - spaceZ - spaceZ * z);
						Quaternion rot = Quaternion.Euler(0, 90, 0);
						Instantiate (wallPrefab, pos, rot); 
					}
				}
				
			}
		}
		
		// Update is called once per frame
		void Update () {
			if (topLight.transform.rotation.y > 0.2) 
			{
				dir=-1;
			}
			if (topLight.transform.rotation.y < -0.2) 
			{
				dir=1;
			}
			topLight.transform.Rotate(0, rotationSpeed*dir, 0);
		}
	}
}
