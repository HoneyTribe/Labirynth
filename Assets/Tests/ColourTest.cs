using UnityEngine;
using System.Collections;

public class ColourTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.SetColor("_Color",Color.red);
	}
	

}
