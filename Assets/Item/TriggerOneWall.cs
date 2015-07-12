using UnityEngine;
using System.Collections;

public class TriggerOneWall : MonoBehaviour
{
	private static float interval = 3.5f;

	private string reference;
	private bool endingEnabled = false;
	private float time;
	private GameObject wall;

	public void setReference(string reference)
	{
		this.reference = reference;
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player"))
		{
			AudioController.instance.Play("021_BlockMovesB");
			gameObject.transform.Translate (0, -1.1f, 0);
			wall = GameObject.Find("Textured Wall(Clone)" + reference);
			endingEnabled = true;
		}
	}

	void Update()
	{
		if (endingEnabled)
		{
			if (time > interval) // it should happen after destroy
			{
				endingEnabled = false;
				AstarPath.active.Scan();
				return;
			}
			
			float step = -Time.deltaTime * 2.5f / interval;
			time += Time.deltaTime;
			wall.transform.Translate (0, step, 0);

			if (time > interval)			
			{	
				Destroy(wall);
			}
		}
	}
}
