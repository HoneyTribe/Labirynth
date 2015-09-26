using UnityEngine;
using System.Collections;

public class ColourTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.red);
	}
	

}
