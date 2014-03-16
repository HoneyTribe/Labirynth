using UnityEngine;
using System.Collections;

public class MonsterCreationController : MonoBehaviour {

	private GameObject monsterDoorLeft;
	private GameObject monsterDoorRight;
	private int delay = 30;

	public GameObject monsterPrefab;

	void Start()
	{
		monsterDoorLeft = GameObject.Find ("monsterDoorLeft");
		monsterDoorRight = GameObject.Find ("monsterDoorRight");
		StartCoroutine(WakeUpMonster());
	}

	IEnumerator WakeUpMonster() {
		while (true) 
		{
			yield return new WaitForSeconds(delay);
			int entrance = Random.Range(0, 2);
			if (entrance == 0)
			{
				monsterDoorLeft.gameObject.SendMessage("OpenDoor");
				CreateMonster(-1);
			}
			else
			{
				monsterDoorRight.gameObject.SendMessage("OpenDoor");
				CreateMonster(1);
			}
		}
	}

	void CreateMonster(int sign)
	{
		Vector3 pos = new Vector3 (sign * 23,
		                           monsterPrefab.transform.position.y,
		                           monsterPrefab.transform.position.z);
		GameObject monster = (GameObject) Instantiate (monsterPrefab, pos, Quaternion.Euler(0, 0, 0)); 
		monster.tag = "Monster";
	}
}
