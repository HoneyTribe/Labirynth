using UnityEngine;
using System.Collections;

public class TriggerHorizontalWalls : MonoBehaviour
{
	private bool pushed = false;
	private Texture greyTexture;
	private Material myMaterial;
	private Renderer rend;

	void Start()
	{
		greyTexture = Resources.Load("/Alexis_Trigger/Materials/Trigger_Grey") as Texture;
		rend = GetComponent<Renderer>();
		myMaterial = rend.material;
	}
	
	public void OnTriggerEnter(Collider currentCollider)
	{
		if (((currentCollider.tag == "Monster") || (currentCollider.tag  == "Player")) && (!pushed))
		{
			pushed = true;
			NoHorizontalWallsEnding.instance.EnableNoHorizontalWallsEnding();
			AudioController.instance.Play("021_BlockMovesB");
			gameObject.transform.Translate (0, 0, -0.6f);
			myMaterial.SetTexture("_EmissionMap", greyTexture); 
		}
	}
}
