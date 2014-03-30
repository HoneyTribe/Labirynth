using UnityEngine;
using System.Collections;

public class MonsterCreationController : MonoBehaviour {

	private GameObject monsterDoorLeft;
	private GameObject monsterDoorRight;

	public GameObject monsterPrefab;

	void Start()
	{
		monsterDoorLeft = GameObject.Find ("monsterDoorLeft");
		monsterDoorRight = GameObject.Find ("monsterDoorRight");
		StartCoroutine(WakeUpMonster());
	}

	IEnumerator WakeUpMonster() 
	{
		yield return new WaitForSeconds(LevelFinishedController.instance.getTimeToFirstMonster());
		for (int i=0; i < LevelFinishedController.instance.getNumberOfMonsters(); i++) 
		{
			int entrance = Random.Range(0, 2);
			if (entrance == 0)
			{
				monsterDoorLeft.gameObject.SendMessage("OpenDoor");
				yield return new WaitForSeconds(3f);
				CreateMonster(monsterDoorLeft);
			}
			else
			{
				monsterDoorRight.gameObject.SendMessage("OpenDoor");
				yield return new WaitForSeconds(3f);
				CreateMonster(monsterDoorRight);
			}
			yield return new WaitForSeconds(LevelFinishedController.instance.getTimeBetweenMonsters());
		}
	}

	void CreateMonster(GameObject door)
	{
		Vector3 pos = new Vector3 (door.transform.localPosition.x - 3 * door.transform.forward.x,
		                           monsterPrefab.transform.position.y,
		                           monsterPrefab.transform.position.z);
		GameObject monster = (GameObject) Instantiate (monsterPrefab, pos, Quaternion.Euler(0, 0, 0)); 
		monster.tag = "Monster";
	}
}