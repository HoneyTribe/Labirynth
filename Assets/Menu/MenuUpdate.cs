using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuUpdate : MonoBehaviour
{
	private string version = "0.21";
	private string url = "http://www.honeytribestudios.com/games1/BFF/bffVersion.txt";
	private string versionRead;
	private float x;
	private float y;
	private float z;
	private GameObject text_enter;


	void Start ()
	{
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;


		//get version from server
		WWW www = new WWW(url);			
		StartCoroutine(WaitForRequest(www));
		text_enter = GameObject.Find ("Text_Enter");
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		versionRead = www.text;
		getUpdate();
	}

	private void getUpdate()
	{
		if(versionRead != "") //has internet connection
		{
			if(versionRead != version) // local version is old
			{
				transform.position = new Vector3(x, y, z);
			}
			else // local version is current
			{
				transform.position = new Vector3(x, -5, z);
			}
		}
		else
		{
			transform.position = new Vector3(x, -5, z);
		}
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			text_enter.GetComponentInChildren<TextMesh>().text = "Press 'start' or 'enter' to view the new update in your browser.";
		}
	}
	public void OnTriggerExit(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			text_enter.GetComponentInChildren<TextMesh>().text = "";
		}
	}

	public string getVersionRead()
	{
		return versionRead;
	}

	public string getVersion()
	{
		return version;
	}


}
