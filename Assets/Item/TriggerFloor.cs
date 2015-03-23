using UnityEngine;
using System.Collections;

public class TriggerFloor : MonoBehaviour
{

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player"))
		{
			NoVerticalWallsEnding.instance.EnableNoVerticalWallsEnding();
			AudioController.instance.Play("021_BlockMovesB");
			gameObject.transform.Translate (0, -1.5f, 0);
		}
	}
}
