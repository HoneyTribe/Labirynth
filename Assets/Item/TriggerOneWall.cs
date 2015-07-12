using UnityEngine;
using System.Collections;

public class TriggerOneWall : MonoBehaviour
{

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player"))
		{
			AudioController.instance.Play("021_BlockMovesB");
			gameObject.transform.Translate (0, -1.1f, 0);
		}
	}
}
