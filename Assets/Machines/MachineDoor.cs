using UnityEngine;
using System.Collections;

public class MachineDoor : MonoBehaviour
{

	private int health = 100;
	private int damage = -10;
	private float x;
	private float y;
	private float z;
	private Vector3 myTempPos;
	private bool dead = false;

	void Start()
	{
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Monster"))
		{
			health += damage;

			if (health <=0 && dead == false)
			{
				//Destroy(gameObject);
				dead = true;
				myTempPos = transform.position;
				myTempPos.y += -10;
				transform.position = myTempPos;
			}
		}
	}
}
