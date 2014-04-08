using UnityEngine;
using System.Collections;

public class JumpController : MonoBehaviour {

	void OnCollisionEnter (Collision collision)
	{
		if (collision.collider.name != "Monster")
		{
			gameObject.transform.parent = collision.gameObject.transform;
		}
	}
}
