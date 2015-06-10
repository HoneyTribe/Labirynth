using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DecoyLinePlayer: MonoBehaviour 
{
	
	//public static DistractLine instance;
	
	private GameObject player1;
	private GameObject player2;
	private GameObject player3;
	private GameObject player4;

	Color green;
	Color blue;
	Color pink;
	Color yellow;
	Color white;

	//private ParticleSystem effect;
	
	void Start()
	{
		//instance = this;
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		player3 = GameObject.Find ("Player3");
		player4 = GameObject.Find ("Player4");

		green = new Color(0.4f,0.8f,0.3f);
		blue = new Color(0.15f,0.6f,1);
		pink = new Color(0.83f,0.32f,0.5f);
		yellow = new Color(0.85f,0.82f,0.3f);
		//effect = transform.particleSystem;
	}
	
	void Update()
	{
		if(transform.parent.position.y > 1 && transform.parent.position.y < 9f)
		{
			//effect.enableEmission = true;

			if(renderer.material.color == green)
			{
				float dist = Vector3.Distance(transform.parent.position, player1.transform.position);
				Vector3 pos = player1.transform.position + (transform.parent.position - player1.transform.position) / 2;
			
				//transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, dist);
				transform.localScale = new Vector3(1, 1, dist);
				transform.position = new Vector3(pos.x, pos.y, pos.z);
				transform.LookAt(transform.parent);
			}
			else if(renderer.material.color == blue)
			{
				float dist = Vector3.Distance(transform.parent.position, player2.transform.position);
				Vector3 pos = player2.transform.position + (transform.parent.position - player2.transform.position) / 2;
				
				//transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, dist);
				transform.localScale = new Vector3(1, 1, dist);
				transform.position = new Vector3(pos.x, pos.y, pos.z);
				transform.LookAt(transform.parent);
			}
			else if(renderer.material.color == pink)
			{
				float dist = Vector3.Distance(transform.parent.position, player3.transform.position);
				Vector3 pos = player3.transform.position + (transform.parent.position - player3.transform.position) / 2;
				
				//transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, dist);
				transform.localScale = new Vector3(1, 1, dist);
				transform.position = new Vector3(pos.x, pos.y, pos.z);
				transform.LookAt(transform.parent);
			}
			else if(renderer.material.color == yellow)
			{
				float dist = Vector3.Distance(transform.parent.position, player4.transform.position);
				Vector3 pos = player4.transform.position + (transform.parent.position - player4.transform.position) / 2;
				
				//transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, dist);
				transform.localScale = new Vector3(1, 1, dist);
				transform.position = new Vector3(pos.x, pos.y, pos.z);
				transform.LookAt(transform.parent);
			}
		}
		else
		{
			//transform.position = new Vector3(0, -10, 0);
			//effect.enableEmission = false;
			transform.localScale = new Vector3(0,0,0);
		}

	}
}
