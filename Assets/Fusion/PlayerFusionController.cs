using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerFusionController : MonoBehaviour {

	private GameObject puzzlePiece;

	void Start()
	{
		GameObject puzzlePrefab = null;
		int id = int.Parse(gameObject.transform.parent.name.Substring (6));
		int numberOfPlayers = LevelFinishedController.instance.getControllers().Count;
		if (numberOfPlayers == 2) 
		{
			if (id == 1)
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
			if ((id == 1) || (id == 2))
			{
				puzzlePrefab = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab" + id);
			}
			else
			{
				puzzlePrefab = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab_2and3");
			}
		}

		if (numberOfPlayers == 4) 
		{
			puzzlePrefab = (GameObject) Resources.Load("PuzzlePieces/Puzzle_Prefab" + id);
		}

		if (numberOfPlayers > 1) 
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

	void ShowPuzzle()
	{
		puzzlePiece.SetActive(true);
	}
}
