using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

	private const float speed = 10f;

	private Vector3 target;
	private bool moving;

	void Update () {

		if (moving)
		{
			float distance = Vector3.Distance(transform.position, target);
			if (distance > 0)
			{
				transform.position = Vector3.Lerp (
					transform.position, target, Time.deltaTime * speed / distance);
			}
			else
			{
				moving = false;
				AstarPath.active.Scan ();
			}
		}
	}

	public void Move(Vector3 direction)
	{
		if (!moving)
		{
			moving = true;
			float x = 0, z = 0;
			if (Mathf.Round(direction.x) != 0)
			{
				x = Mathf.Sign(direction.x) * 2 * Instantiation.instance.getSpaceX();
			}
			if (Mathf.Round(direction.z) != 0)
			{
				z = Mathf.Sign(direction.z) * 2 * Instantiation.instance.getSpaceZ();
			}
				
			target = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
		}
	}
}
