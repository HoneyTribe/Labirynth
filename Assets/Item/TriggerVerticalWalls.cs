using UnityEngine;
using System.Collections;

public class TriggerVerticalWalls : MonoBehaviour
{
	private bool pushed = false;

	public void OnTriggerEnter(Collider currentCollider)
	{
		if (((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player")) && (!pushed))
		{
			pushed = true;
			NoVerticalWallsEnding.instance.EnableNoVerticalWallsEnding();
			AudioController.instance.Play("021_BlockMovesB");
			//gameObject.transform.parent.transform.Translate (0, -0.5f, 0);
			gameObject.transform.Translate (0, 0, -0.6f);
		}
	}
}
