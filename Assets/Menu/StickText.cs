using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StickText : MonoBehaviour
{
	private int playersInside = 0;
	private Animator anim;
	private static int OnHash = Animator.StringToHash ("On");
	private static int OffHash = Animator.StringToHash ("Off");
	private bool animOn;
	private bool savedAnimOn;
	private TextMesh levelScreen;
	private float delayForText = 0.4f;
	
	
	void Start ()
	{
		anim = GameObject.Find ("StickPopUp").GetComponent<Animator>();
		levelScreen = GameObject.Find ("Level").GetComponent<TextMesh>();
	}
	
	public void OnTriggerEnter(Collider currentCollider)
	{
		if ((currentCollider.tag  == "Player"))
		{
			playersInside++;
			if (playersInside == 1)
			{
				animOn = true;
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
			StartCoroutine( ShowLevelText() );
		}
	}
	
	private void TriggerAnimClose()
	{
		if (animOn == false && savedAnimOn == true)
		{
			savedAnimOn = false;
			anim.SetTrigger(OffHash);
			levelScreen.text = "";
		}
	}

	IEnumerator ShowLevelText()
	{
		yield return new WaitForSeconds(delayForText);
		if (animOn == true)
		{
			levelScreen.text = "Zone " + (LevelFinishedController.instance.getLevel() + 1) + "/" + LevelFinishedController.instance.getTotalLevels();
		}
	}

}
