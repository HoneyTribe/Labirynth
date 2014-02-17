using UnityEngine;
using System.Collections;

public class Instantiation : MonoBehaviour {

	public GameObject wallPrefab;
	public Light topLight;

	private int dir = 1;
	private float rotationSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		for (int i=0; i<10; i++) 
		{
			float randX = Random.Range (-20, 20);
			float randZ = Random.Range (-10, 10);
			float rotY = Random.Range (0, 2);
			Vector3 pos = new Vector3 (randX, wallPrefab.transform.position.y, randZ); 
			Quaternion rot = Quaternion.Euler(0, rotY*90, 0);
			Instantiate (wallPrefab, pos, rot); 
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (topLight.transform.rotation.y > 0.4) 
		{
			dir=-1;
		}
		if (topLight.transform.rotation.y < -0.4) 
		{
			dir=1;
		}
		topLight.transform.Rotate(0, rotationSpeed*dir, 0);
	}
}
