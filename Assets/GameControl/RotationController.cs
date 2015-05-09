using UnityEngine;
using System.Collections.Generic;

public class RotationController : MonoBehaviour {

	public static RotationController instance;

	private List<GameObject> players;
	private float index = 400f;
	private float time;
	private bool up;

	void Start()
	{
		instance = this;
	}

	void Update () 
	{
		if (players != null)
		{
			foreach(GameObject player in players)
			{
				player.transform.RotateAround(Vector3.zero, Vector3.up, index * Time.deltaTime);
				if (up)
				{
					player.transform.Translate(Vector3.up * 100 * Time.deltaTime);
				}
			}
			if ((Time.time - time > 1) && (!up))
			{
				index = index * 2f;
				time = Time.time;
			}
			if (index > 1000)
			{
				up = true;
			}
			if (players[0].transform.position.y > 50)
			{
				players = null;
				Application.LoadLevel (1); 
			}
		}
	}

	public void startRotation(List<GameObject> players)
	{
		this.players = players;
		this.time = Time.time;
	}
}
