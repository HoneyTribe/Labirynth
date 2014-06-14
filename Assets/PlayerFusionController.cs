using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerFusionController : MonoBehaviour {

	private static float puzzleScale = 4f;

	private GameObject puzzlePiece;

	void Start()
	{
		int id = int.Parse(gameObject.name.Substring (6));
		int numberOfPlayers = LevelFinishedController.instance.getControllers().Count;
		if (numberOfPlayers == 2) 
		{
			if (id == 1)
			{
				puzzlePiece = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab_1and4");
			}
			else
			{
				puzzlePiece = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab_2and3");
			}
		}

		if (numberOfPlayers == 3) 
		{
			if ((id == 1) || (id == 2))
			{
				puzzlePiece = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab" + id);
			}
			else
			{
				puzzlePiece = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab_2and3");
			}
		}

		if (numberOfPlayers == 4) 
		{
			puzzlePiece = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab" + id);
		}

		if (numberOfPlayers > 1) 
		{
			puzzlePiece = (GameObject) Instantiate(puzzlePiece, Vector3.zero, Quaternion.Euler(0, 0, 0));
			puzzlePiece.transform.parent = gameObject.transform;
<<<<<<< HEAD
			puzzlePiece.transform.localPosition = new Vector3(0, 2, 0);
			puzzlePiece.transform.localScale = new Vector3(puzzlePiece.transform.localScale.x / 3f,
			                                               puzzlePiece.transform.localScale.y / 3f,
			                                               puzzlePiece.transform.localScale.z / 3f);
=======
			puzzlePiece.transform.localPosition = new Vector3(0, 5, 0);
			puzzlePiece.transform.localScale = new Vector3(puzzlePiece.transform.localScale.x / puzzleScale,
			                                               puzzlePiece.transform.localScale.y / puzzleScale,
			                                               puzzlePiece.transform.localScale.z / puzzleScale);
>>>>>>> FETCH_HEAD
			puzzlePiece.SetActive(false);
		}
	}

	void ShowPuzzle()
	{
		puzzlePiece.SetActive(true);
	}
}
