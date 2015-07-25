using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerFusionController : MonoBehaviour {

	private static float speed = 0.3f;
	private static float speed1 = 0.3f;
	private static float speed2 = 2.0f;

	private GameObject puzzlePiece;
	private bool moveTocenter;
	private Vector3 center;
	private Vector3 initialPosition;
	private Transform parentTransform;
	private float time;
	private float totalDelta = 0;
	private bool levelFinish = false;
	//private ParticleSystem myStream;

	void Start()
	{
		speed = speed1;

		GameObject puzzlePrefab = null;
		initialPosition = transform.localPosition;
		parentTransform = transform.parent;
		int id = int.Parse(gameObject.transform.parent.name.Substring (6));
		int numberOfPlayers = LevelFinishedController.instance.getAllControllers().Count;
		if (numberOfPlayers == 2) 
		{
			if (id < 5)
			{
				puzzlePrefab = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab_1and4");
			}
			else
			{
				puzzlePrefab = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab_2and3");
			}
		}

		if (numberOfPlayers == 3) 
		{
			if ((id == 2) || (id == 3))
			{
				puzzlePrefab = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab" + id);
			}
			else
			{
				puzzlePrefab = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab_1and4");
			}
		}

		if (numberOfPlayers == 4) 
		{
			puzzlePrefab = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab" + id);
		}

		if (Application.loadedLevel != 0)
		{
			puzzlePiece = (GameObject) Instantiate(puzzlePrefab, Vector3.zero, 
			                                       Quaternion.Euler(90, 0, puzzlePrefab.transform.eulerAngles.z));
			puzzlePiece.transform.parent = gameObject.transform;
			puzzlePiece.transform.localPosition = Vector3.zero;
			puzzlePiece.transform.localScale = new Vector3(puzzlePiece.transform.localScale.x / 3f,
			                                               puzzlePiece.transform.localScale.y / 3f,
			                                               puzzlePiece.transform.localScale.z / 3f);
			puzzlePiece.SetActive(false);
		}
	}

	void Update()
	{

		if(Application.loadedLevel != 0)
		{
			if(levelFinish == false && LevelEnd.instance.IsStartSequence() == true)
			{
				levelFinish = true;
				//myStream = GetComponentInChildren<ParticleSystem>();
				Activate();
				speed = speed2;
				//myStream.Play();
			}
		}

		if (moveTocenter)
		{
			totalDelta += Time.deltaTime;

			if (Vector3.Distance(transform.position, center) > 0.002)
			{
				//transform.position = Vector3.Lerp (transform.position, center, (Time.time - time) * speed);
				transform.position = Vector3.Lerp (transform.position, center, totalDelta * speed);
			}
			else
			{
				if(LevelEnd.instance.IsStartSequence() == false)
				{
					moveTocenter = false;
					transform.parent = parentTransform;
					transform.localPosition = initialPosition;
					totalDelta = 0;
				}
			}
		}
	}


	void Activate()
	{
		float minX = 20;
		float minZ = 20;
		float maxX = -20;
		float maxZ = -20;
		foreach (InputController controller in LevelFinishedController.instance.getAllControllers())
		{
			GameObject player = GameObject.Find ("Player" + controller.getPlayerId());
			if (player.transform.position.x < minX)
				minX = player.transform.position.x;
			if (player.transform.position.x > maxX)
				maxX = player.transform.position.x;
			if (player.transform.position.z < minZ)
				minZ = player.transform.position.z;
			if (player.transform.position.z > maxZ)
				maxZ = player.transform.position.z;
		}
		center = new Vector3 ((maxX + minX)/2, initialPosition.y, (maxZ + minZ)/2);
		time = Time.time;
		transform.parent = null;
		moveTocenter = true;
	}

	IEnumerator ShowPuzzle()
	{
		if (puzzlePiece != null)
		{
			puzzlePiece.SetActive(true);
			while (true)
			{
				Activate ();
				yield return new WaitForSeconds(5);
			}
		}
	}
}
