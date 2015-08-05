using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuUpdate : MonoBehaviour
{
	public static MenuUpdate instance;
	private string version = "0.21.3";
	private string url = "http://www.honeytribestudios.com/games1/BFF/bffVersion.txt";
	private string versionRead;
	private float x;
	private float y;
	private float z;
	private GameObject text_enter;
	private GameObject useAnalytics;
	private int playersInside = 0;
	private Animator anim;
	private static int OnHash = Animator.StringToHash ("On");
	private static int OffHash = Animator.StringToHash ("Off");
	private bool animOn;
	private bool savedAnimOn;
	
	void Start ()
	{
		instance = this;
		x = transform.parent.position.x;
		y = transform.parent.position.y;
		z = transform.parent.position.z;
		text_enter = GameObject.Find ("Text_Enter");
		useAnalytics = GameObject.Find ("GA_SystemTracker");
		anim = GameObject.Find ("UpdatePopUp").GetComponent<Animator>();


		if(LevelFinishedController.instance.getHomeVersion() == 1 && Application.loadedLevel == 0)//get version from server
		{
			WWW www = new WWW(url);			
			StartCoroutine(WaitForRequest(www));
		}
		else
		{
			transform.parent.position = new Vector3(x, -10, z);
			useAnalytics.SetActive(false);
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
		if(versionRead != "" && LevelFinishedController.instance.getHomeVersion() == 1 ) //has internet connection and is home version
		{
			if(versionRead != version) // local version is old
			{
				transform.parent.position = new Vector3(x, y, z);
			}
			else // local version is current
			{
				transform.parent.position = new Vector3(x, -10, z);
			}
		}
		else // no internet or not home version
		{
			transform.parent.position = new Vector3(x, -10, z);
			useAnalytics.SetActive(false);
		}
	}

	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInside++;
			if (playersInside == 1)
			{
				animOn = true;
				text_enter.GetComponentInChildren<TextMesh>().text = "Press 'start'/'enter' to view the update";
				TriggerAnimOpen();
			}
		}
	}

	public void OnTriggerExit(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInside--;
			if (playersInside == 0)
			{
				animOn = false;
				text_enter.GetComponentInChildren<TextMesh>().text = "Enter the portal";
				TriggerAnimClose();
			}
		}
	}

	private void TriggerAnimOpen()
	{
		if (animOn == true && savedAnimOn == false)
		{
			savedAnimOn = true;
			anim.SetTrigger(OnHash);
		}
	}

	private void TriggerAnimClose()
	{
		if (animOn == false && savedAnimOn == true)
		{
			savedAnimOn = false;
			anim.SetTrigger(OffHash);
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
