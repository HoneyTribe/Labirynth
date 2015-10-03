using UnityEngine;
using System.Collections;

public class TriggerHorizontalWalls : MonoBehaviour
{
	private bool pushed = false;
	
	public void OnTriggerEnter(Collider currentCollider)
	{
		if (((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player")) && (!pushed))
		{
			pushed = true;
			NoHorizontalWallsEnding.instance.EnableNoHorizontalWallsEnding();
			AudioController.instance.Play("021_BlockMovesB");
			gameObject.transform.parent.transform.Translate (0, -0.5f, 0);
		}
	}
}
