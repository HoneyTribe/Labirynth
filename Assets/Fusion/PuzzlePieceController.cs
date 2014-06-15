using UnityEngine;
using System.Collections;

public class PuzzlePieceController : MonoBehaviour {

	private GameObject myCamera;

	void Start()
	{
		myCamera = GameObject.Find ("MainCamera_Front");
	}

	void Update()
	{
		transform.LookAt(transform.position + myCamera.transform.rotation * Vector3.back,
		                 myCamera.transform.rotation * Vector3.up);
	}

}
