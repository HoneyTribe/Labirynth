using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuUpdate : MonoBehaviour
{
	public static MenuUpdate instance;
	private string version = "0.21";
	private string url = "http://www.honeytribestudios.com/games1/BFF/bffVersion.txt";
	private string versionRead;
	private float x;
	private float y;
	private float z;
	private GameObject text_enter;
	private int playersInside = 0;


	void Start ()
	{
		instance = this;
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;
		text_enter = GameObject.Find ("Text_Enter");


		if(LevelFinishedController.instance.getHomeVersion() == 1 && Application.loadedLevel == 0)//get version from server
		{
			WWW www = new WWW(url);			
			StartCoroutine(WaitForRequest(www));
		}
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		versionRead = www.text;
		getUpdate();
	}

	private void getUpdate()
	{
		if(versionRead != "" && LevelFinishedController.instance.getHomeVersion() == 1 ) //has internet connection
		{
			if(versionRead != version) // local version is old
			{
				transform.position = new Vector3(x, y, z);
			}
			else // local version is current
			{
				transform.position = new Vector3(x, -10, z);
			}
		}
		else
		{
			transform.position = new Vector3(x, -10, z);
		}
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInside++;
			text_enter.GetComponentInChildren<TextMesh>().text = "Press 'start'/'enter' to view the update";
		}
	}
	public void OnTriggerExit(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInside--;
			if (playersInside == 0)
			{
				text_enter.GetComponentInChildren<TextMesh>().text = "2-4 characters must enter the portal";
			}
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

	public int getplayersInside()
	{
		return playersInside;
	}


}
