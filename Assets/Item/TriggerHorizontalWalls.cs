using UnityEngine;
using System.Collections;

public class TriggerHorizontalWalls : MonoBehaviour
{
	
	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player"))
		{
			NoHorizontalWallsEnding.instance.EnableNoHorizontalWallsEnding();
			AudioController.instance.Play("021_BlockMovesB");
			gameObject.transform.Translate (0, -1.1f, 0);
		}
	}
}
