using UnityEngine;
using System.Collections.Generic;

public class Instantiation : MonoBehaviour {

	private const float MARGIN = 0.1f;
	private const float MONSTER_DOOR = 4.15f;

	public static Instantiation instance;

	public static float compensatePillarInnerRadius = 0.2f;

	public GameObject nodePrefab;
	public GameObject wallPrefab;
	public GameObject smallWallPrefab;
	public GameObject keyPrefab;
	public GameObject jumpPrefab;

	public static int planeSizeX = 40;
	public static int planeSizeZ = 34;
	public static int offsetZ = 6;

	private int sizeX;
	private int sizeZ;
	private float spaceX;
	private float spaceZ;

	private Labirynth labirynth;

	// Use this for initialization
	void Start()
	{
		instance = this;

		LevelFinishedController.instance.setDecoyFixed (false);
		sizeX = LevelFinishedController.instance.getMazeSizeX();
		sizeZ = LevelFinishedController.instance.getMazeSizeZ();
		spaceX = planeSizeX / (sizeX * 2f);
		spaceZ = planeSizeZ / (sizeZ * 2f);

		string[,] grid = null;
		Puzzle puzzle = null;
		if (LevelFinishedController.instance.getPuzzleName() != null)
		{
			System.Type type = System.Type.GetType (LevelFinishedController.instance.getPuzzleName());
			puzzle = (Puzzle) ScriptableObject.CreateInstance(type);
			grid = puzzle.getGrid();
			puzzle.create();
		}

		labirynth = new Labirynth (sizeX, sizeZ, grid);
		labirynth.generate ();
		drawMachines ();
		drawDevice ();
		if (LevelFinishedController.instance.getPuzzleName() == null)
		{
			drawKeys (labirynth.getKeys ());
		}
		drawJumps ();
		drawSmallWalls (labirynth, 0);
		drawHorisontalWalls (labirynth, 0);
		drawVerticalWalls (labirynth, 0);
		createNodes ();

		if (LevelFinishedController.instance.getPuzzleName() != null)
		{
			puzzle.finish();
		}
	}	

	void createNodes()
	{
		((Pathfinding.PointGraph) AstarPath.active.graphs [0]).limits = new Vector3(2 * spaceX + MARGIN, 0, 3 * spaceZ + MARGIN);

		GameObject nodes = GameObject.Find ("Nodes");
		int stepX = 2;
		int stepZ = 2;
		for (int z=1; z<sizeZ * 2 + 3; z+=stepZ) 
		{
			if (z == sizeZ * 2 + 1)
			{
				stepX = 1;
				stepZ = 1;
			}

			for (int x=1; x<sizeX * 2; x+=stepX) 
			{
				float zPosition = offsetZ + planeSizeZ/2f - spaceZ * z;
				if (z == sizeZ * 2 + 2)
				{
					zPosition = -planeSizeZ/2f;
				}

				Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * x,
				                           0,
				                           zPosition);

				// make sure node is not too close to any object
				RaycastHit hit;
				if ((!Physics.SphereCast(pos, 1.2f, Vector3.up, out hit)) ||
					(!hit.collider.tag.Contains("Machine")))
				{
					GameObject node = (GameObject) Instantiate (nodePrefab, pos, Quaternion.Euler(0, 0, 0));
					node.transform.parent = nodes.transform;
				}
			}
		} 
		AstarPath.active.Scan ();
	}

	void drawMachines()
	{
		if ((LevelFinishedController.instance.getLevel() < LevelFinishedController.instance.getFirstLevelWithLight()) &&
			(!LevelFinishedController.instance.isDistractionEnabled()) &&
			(!LevelFinishedController.instance.isItemActivationEnabled()))
		{
			GameObject.Find ("Lighthouse").SetActive(false);
			GameObject.Find ("LightContainer").SetActive(false);
		}

		if ((!LevelFinishedController.instance.isPickingUpEnabled()) &&
		    (!LevelFinishedController.instance.isSmashingEnabled()))
		{
			GameObject.Find ("Crane").SetActive(false);
			GameObject.Find ("CraneContainer").SetActive(false);
		}

		if ((!LevelFinishedController.instance.isTeleportEnabled()) &&
		    (!LevelFinishedController.instance.isStunGunEnabled()))
		{
			GameObject.Find ("PortalGun").SetActive(false);
			GameObject.Find ("Drone").SetActive(false);
		}
	}

	void drawDevice()
	{
		if (!LevelFinishedController.instance.isDistractionEnabled())
		{
			Component[] components = GameObject.Find ("DeviceContainer").GetComponentsInChildren<MeshRenderer>();
			foreach (Component component in components)
			{
				component.renderer.enabled = false;
			}
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

		List<KeyPosition> keysFull = new List<KeyPosition>(keys);
		for (int i=keys.Count - 1; i<LevelFinishedController.instance.getNumberOfKeys(); i++) 
		{
			Vector2 tempPos = new Vector2(2 * Random.Range(0, sizeX) + 1, 2 * Random.Range(0, sizeZ) + 1);
			bool found = false;
			foreach (KeyPosition keyPos in keys)
			{
				if (keyPos.getPosition().Equals(tempPos))
				{
					found = true;
					break;
				}
			}

			if (!found)
			{
				keysFull.Add(new KeyPosition(tempPos, 0));
			}
			else
			{
				i--;
			}
		}

		for (int i=0; i<LevelFinishedController.instance.getNumberOfKeys(); i++) 
		{
			Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * keysFull[i].getPosition().x,
			                           keyPrefab.transform.position.y,
			                           offsetZ + planeSizeZ/2f - spaceZ * keysFull[i].getPosition().y);
			Quaternion rot = Quaternion.Euler(0, 0, 0);
			Instantiate (keyPrefab, pos, rot); 
		}
	}

	void drawJumps()
	{
		if (LevelFinishedController.instance.isItemActivationEnabled())
		{
			Vector3 pos = getStart();
			pos.y = 1.5f;
			Quaternion rot = Quaternion.Euler(0, 0, 0);
			Instantiate (jumpPrefab, pos, rot); 
		}
	}

	List<GameObject> drawSmallWalls(Labirynth labirynth, float yOffset)
	{
		List<GameObject> walls = new List<GameObject> ();
		for (int z=2; z<=sizeZ * 2; z+=2) // don't draw edges
		{
			for (int x=2; x<=sizeX * 2 - 2; x+=2)  // don't draw edges
			{
				if (labirynth.getWalls(x, z).Equals(TileType.WALL))
				{
					Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * x,
					                           smallWallPrefab.transform.position.y + yOffset,
					                           offsetZ + planeSizeZ/2f - spaceZ * z);
					int angle = Random.Range(0, 4) * 90;
					GameObject obj = (GameObject)Instantiate (smallWallPrefab, pos, Quaternion.Euler(0, angle, 0)); 

					if (z == sizeZ * 2) // last row
					{
						obj.layer = LayerMask.NameToLayer("1stRowMazeWalls");
					}
					walls.Add(obj); 
				}
			}
			
		}
		return walls;
	}

	List<GameObject> drawHorisontalWalls(Labirynth labirynth, float yOffset)
	{
		List<GameObject> walls = new List<GameObject> ();
		float scaleFactorX = 2*spaceX - 1f;
		for (int z=2; z<=sizeZ * 2; z+=2) // don't draw edges
		{
			for (int x=1; x<=sizeX * 2 - 1; x+=2)
			{
				if (labirynth.getWalls(x, z).Equals(TileType.WALL))
				{
					float zPosition = offsetZ + planeSizeZ/2f - spaceZ * z;
					Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * x,
					                           wallPrefab.transform.position.y + yOffset,
					                           zPosition);
					GameObject obj = (GameObject) Instantiate (wallPrefab, pos, Quaternion.Euler(0, 0, 0));
					obj.transform.localScale = new Vector3(scaleFactorX + compensatePillarInnerRadius, 
                                              			   wallPrefab.transform.localScale.y,
                                              			   wallPrefab.transform.localScale.z);
					if (z == sizeZ * 2) // last row
					{
						obj.layer = LayerMask.NameToLayer("1stRowMazeWalls");
					}
					walls.Add(obj); 
				}
			}				
		}
		return walls;
	}

	List<GameObject> drawVerticalWalls(Labirynth labirynth, float yOffset)
	{
		List<GameObject> walls = new List<GameObject> ();
		float scaleFactorZ = 2*spaceZ - 1f;
		for (int z=1; z<=sizeZ * 2 - 1; z+=2) 
		{
			for (int x=2; x<=sizeX * 2 -2 ; x+=2)  // don't draw edges
			{
				if (labirynth.getWalls(x, z).Equals (TileType.WALL))		
				{
					Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * x,
					                           wallPrefab.transform.position.y + yOffset,
					                           offsetZ + planeSizeZ/2f - spaceZ * z);
					GameObject obj = (GameObject) Instantiate (wallPrefab, pos, Quaternion.Euler(0, 90, 0));
					obj.transform.localScale = new Vector3(scaleFactorZ + compensatePillarInnerRadius,
			                                               wallPrefab.transform.localScale.y,
			                                               wallPrefab.transform.localScale.z);
					if (z == sizeZ * 2 - 1) // last row
					{
						obj.layer = LayerMask.NameToLayer("1stRowMazeWalls");
					}
					walls.Add(obj); 
				}
			}			
		}
		return walls;
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

	public List<float> getMonsterWalkablePositions()
	{
		List<float> positions = new List<float>();
		
		for (int z=1; z<sizeZ * 2; z+=2) 
		{
			float zPosition = offsetZ + planeSizeZ/2f - spaceZ * z;
			// total monster size = 2.6
			if ((zPosition + 1.2 < MONSTER_DOOR + 4.5) && (zPosition - 1.2 > MONSTER_DOOR - 4.5))
			{
				positions.Add(zPosition);
			}
		}
		
		return positions;
	}

	public List<GameObject> createBlockingWalls()
	{
		List<GameObject> walls = new List<GameObject> ();

		float scaleFactorX = 2*spaceX - 1f;
		int z = sizeZ * 2;
		for (int x=1; x<=sizeX * 2 - 1; x+=2)
		{
			if (labirynth.getWalls(x, z).Equals (TileType.MAZE))
			{
				float zPosition = offsetZ + planeSizeZ/2f - spaceZ * z;
				Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * x,
				                           wallPrefab.transform.position.y - 2.5f,
				                           zPosition);
				GameObject obj = (GameObject) Instantiate (wallPrefab, pos, Quaternion.Euler(0, 0, 0));
				obj.transform.localScale = new Vector3(scaleFactorX + compensatePillarInnerRadius, 
		                                               wallPrefab.transform.localScale.y,
		                                               wallPrefab.transform.localScale.z);
				obj.layer = LayerMask.NameToLayer("1stRowMazeWalls");
				walls.Add(obj); 
			}
		}

		for (int x=2; x<=sizeX * 2 - 2; x+=2)  // don't draw edges
		{
			if (labirynth.getWalls(x, z).Equals (TileType.MAZE))
			{
				Vector3 pos = new Vector3 (-planeSizeX/2f + spaceX * x,
				                           smallWallPrefab.transform.position.y - 2.5f,
				                           offsetZ + planeSizeZ/2f - spaceZ * z);
				int angle =  Random.Range(0, 4) * 90;
				GameObject obj = (GameObject)Instantiate (smallWallPrefab, pos, Quaternion.Euler(0, angle, 0)); 
				obj.layer = LayerMask.NameToLayer("1stRowMazeWalls");
				walls.Add(obj); 
			}
		}

		return walls;
	}

	public List<GameObject> createNewWalls()
	{
		labirynth = new Labirynth (sizeX, sizeZ, null);
		labirynth.generate ();

		List<GameObject> walls = new List<GameObject> ();
		walls.AddRange (drawHorisontalWalls (labirynth, -2.5f));
		walls.AddRange (drawVerticalWalls (labirynth, -2.5f));
		walls.AddRange (drawSmallWalls (labirynth, -2.5f));
								
		return walls;
	}
}

