using UnityEngine;
using System.Collections;

public class TestWallController : MonoBehaviour {

	public Texture2D texture;
	private Vector3 localScale = Vector3.zero;

	void Update ()
	{
		if (!localScale.Equals(gameObject.transform.localScale))
		{
			float ratio = gameObject.transform.localScale.x /  gameObject.transform.localScale.y;
			
			gameObject.renderer.material.mainTexture = texture;
			gameObject.renderer.material.mainTextureScale = new Vector2 (ratio, 1);

			localScale = gameObject.transform.localScale;
		}

	}
}
