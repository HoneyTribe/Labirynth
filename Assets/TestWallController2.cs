using UnityEngine;
using System.Collections;

public class TestWallController2 : MonoBehaviour {

	public Texture2D texture;
	private Vector3 localScale = Vector3.zero;

	void Update ()
	{
		if (!localScale.Equals(gameObject.transform.localScale))
		{
			float ratio = gameObject.transform.localScale.y /  gameObject.transform.localScale.x;
			
			gameObject.renderer.material.mainTexture = texture;
			gameObject.renderer.material.mainTextureScale = new Vector2 (1, ratio);
			gameObject.renderer.material.mainTextureOffset = new Vector2 (1-ratio, 0);

			localScale = gameObject.transform.localScale;
		}

	}
}
