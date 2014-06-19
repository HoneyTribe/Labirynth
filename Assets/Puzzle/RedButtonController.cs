using UnityEngine;
using System.Collections;

public class RedButtonController : MonoBehaviour {

	private GameObject decoy;
	private GameObject zap;

	void Start()
	{
		decoy = gameObject.transform.Find ("ControlPad_Alert_decoy").gameObject;
		zap = gameObject.transform.Find ("ControlPad_Alert_zap").gameObject;
	}

	public void OnTriggerStay(Collider currentCollider)
	{
		if (currentCollider.tag  == "Player")
		{
			if (DeviceController.instance.isDeviceInLighthouse())
			{
				zap.SetActive(false);
				decoy.SetActive(true);
			}
			else
			{
				decoy.SetActive(false);
				zap.SetActive(true);
			}
		}
	}

	public void OnTriggerExit (Collider currentCollider)
	{
		if (currentCollider.tag  == "Player")
		{
			decoy.SetActive(false);
			zap.SetActive(false);
		}
	}
}
