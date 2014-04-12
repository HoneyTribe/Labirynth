using UnityEngine;
using System.Collections;

public class JumpController : MonoBehaviour {

	private TextMesh textMesh;

	void Start()
	{
		textMesh = gameObject.GetComponentInChildren<TextMesh> ();
	}

	public void ClearText()
	{
		textMesh.text = "";
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if (currentCollider.name != "Monster")
		{
			textMesh.text = "TAKE ME!";
			currentCollider.gameObject.SendMessage("JumpItemAvailable", gameObject);
		}
	}

	void OnTriggerExit (Collider currentCollider)
	{
		if (currentCollider.name != "Monster")
		{
			textMesh.text = "";
			currentCollider.gameObject.SendMessage("JumpItemNotAvailable", gameObject);
		}
	}
}
