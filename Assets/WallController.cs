using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

	private static AssemblyCSharp.TextureAppender textureAppender;
	private static int TOP_ID;
	private static int LEFT_ID;
	private static int RIGHT_ID;

	public Texture2D[] frontAndBack;
	public Texture2D top;
	public Texture2D left;
	public Texture2D right;

	private Texture2D textureAtlas;
	
	private Rect[] atlasUvs;
	private Vector3 localScale = Vector3.zero;

	void Start()
	{
		if (textureAppender == null)
		{
			int size = frontAndBack.Length + 3;
			TOP_ID = size - 3;
			LEFT_ID = size - 2;
			RIGHT_ID = size - 1;

			Texture2D[] textures = new Texture2D[size];
			for (int i=0; i<frontAndBack.Length; i++)
			{
				textures[i] = frontAndBack[i];
			}

			textures[TOP_ID] = top;
			textures[LEFT_ID] = left;
			textures[RIGHT_ID] = right;
			textureAppender = new AssemblyCSharp.TextureAppender (textures);
		}
		textureAtlas = textureAppender.getTextureAtlas ();

		MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();

		//front
		Vector3 p0 = new Vector3(-0.5f,-0.5f,-0.5f);
		Vector3 p1 = new Vector3(-0.5f,0.5f,-0.5f);
		Vector3 p2 = new Vector3(0.5f,0.5f,-0.5f);
		Vector3 p3 = new Vector3(0.5f,-0.5f,-0.5f);
		//top
		Vector3 p4 = new Vector3(-0.5f,0.5f,-0.5f);
		Vector3 p5 = new Vector3(-0.5f,0.5f,0.5f);
		Vector3 p6 = new Vector3(0.5f,0.5f,0.5f);
		Vector3 p7 = new Vector3(0.5f,0.5f,-0.5f);
		//back
		Vector3 p8 = new Vector3(0.5f,-0.5f,0.5f);
		Vector3 p9 = new Vector3(0.5f,0.5f,0.5f);
		Vector3 p10 = new Vector3(-0.5f,0.5f,0.5f);
		Vector3 p11 = new Vector3(-0.5f,-0.5f,0.5f);
		//left
		Vector3 p12 = new Vector3(-0.5f,-0.5f,0.5f);
		Vector3 p13 = new Vector3(-0.5f,0.5f,0.5f);
		Vector3 p14 = new Vector3(-0.5f,0.5f,-0.5f);
		Vector3 p15 = new Vector3(-0.5f,-0.5f,-0.5f);
		//right
		Vector3 p16 = new Vector3(0.5f,-0.5f,-0.5f);
		Vector3 p17 = new Vector3(0.5f,0.5f,-0.5f);
		Vector3 p18 = new Vector3(0.5f,0.5f,0.5f);
		Vector3 p19 = new Vector3(0.5f,-0.5f,0.5f);
		
		Mesh mesh = meshFilter.mesh;
		mesh.Clear();
		
		mesh.vertices = new Vector3[]{
			p0,p1,p2,
			p0,p2,p3,
			p4,p5,p6,
			p4,p6,p7,
			p8,p9,p10,
			p8,p10,p11,
			p12,p13,p14,
			p11,p14,p15,
			p16,p17,p18,
			p16,p18,p19
		};
		mesh.triangles = new int[]{
			0,1,2,
			3,4,5,
			6,7,8,
			9,10,11,
			12,13,14,
			15,16,17,
			18,19,20,
			21,22,23,
			24,25,26,
			27,28,29
		};

		float ratioXY = gameObject.transform.localScale.x /  gameObject.transform.localScale.y;
		float ratioXZ = gameObject.transform.localScale.x /  gameObject.transform.localScale.z;
		float ratioZY = gameObject.transform.localScale.z /  gameObject.transform.localScale.y;
		Rect[] uv = textureAppender.getUV ();
		//front
		int frontId = Random.Range (0, frontAndBack.Length);
		Vector2 uv0 = new Vector2(uv[frontId].xMin, uv[frontId].yMin);
		Vector2 uv1 = new Vector2(uv[frontId].xMin, uv[frontId].yMax);
		Vector2 uv2 = new Vector2(uv[frontId].xMax * ratioXY, uv[frontId].yMax);
		Vector2 uv3 = new Vector2(uv[frontId].xMax * ratioXY, uv[frontId].yMin);
		//top
		Vector2 uv4 = new Vector2(uv[TOP_ID].xMin, uv[TOP_ID].yMin);
		Vector2 uv5 = new Vector2(uv[TOP_ID].xMin, uv[TOP_ID].yMax);
		Vector2 uv6 = new Vector2(uv[TOP_ID].xMax * ratioXZ, uv[TOP_ID].yMax);
		Vector2 uv7 = new Vector2(uv[TOP_ID].xMax * ratioXZ, uv[TOP_ID].yMin);
		//back
		int backId = Random.Range (0, frontAndBack.Length);
		Vector2 uv8 = new Vector2(uv[backId].xMin, uv[backId].yMin);
		Vector2 uv9 = new Vector2(uv[backId].xMin, uv[backId].yMax);
		Vector2 uv10 = new Vector2(uv[backId].xMax * ratioXY, uv[backId].yMax);
		Vector2 uv11 = new Vector2(uv[backId].xMax * ratioXY, uv[backId].yMin);
		//left
		Vector2 uv12 = new Vector2(uv[LEFT_ID].xMin, uv[LEFT_ID].yMin);
		Vector2 uv13 = new Vector2(uv[LEFT_ID].xMin, uv[LEFT_ID].yMax);
		Vector2 uv14 = new Vector2(uv[LEFT_ID].xMax * ratioZY, uv[LEFT_ID].yMax);
		Vector2 uv15 = new Vector2(uv[LEFT_ID].xMax * ratioZY, uv[LEFT_ID].yMin);
		//right
		Vector2 uv16 = new Vector2(uv[RIGHT_ID].xMin, uv[RIGHT_ID].yMin);
		Vector2 uv17 = new Vector2(uv[RIGHT_ID].xMin, uv[RIGHT_ID].yMax);
		Vector2 uv18 = new Vector2(uv[RIGHT_ID].xMax * ratioZY, uv[RIGHT_ID].yMax);
		Vector2 uv19 = new Vector2(uv[RIGHT_ID].xMax * ratioZY, uv[RIGHT_ID].yMin);
		
		mesh.uv = new Vector2[]{
			uv0,uv1,uv2,
			uv0,uv2,uv3,
			uv4,uv5,uv6,
			uv4,uv6,uv7,
			uv8,uv9,uv10,
			uv8,uv10,uv11,
			uv12,uv13,uv14,
			uv12,uv14,uv15,
			uv16,uv17,uv18,
			uv16,uv18,uv19
		};
		
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
		mesh.Optimize();

		gameObject.renderer.material.mainTexture = textureAtlas;

	}
}
