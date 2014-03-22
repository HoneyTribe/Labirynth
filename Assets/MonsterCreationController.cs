using UnityEngine;
using System.Collections;

public class MonsterCreationController : MonoBehaviour {

	private static int delay = 15;

	private GameObject monsterDoorLeft;
	private GameObject monsterDoorRight;

	public GameObject monsterPrefab;

	private LevelFinishedController levelFinishedController;

	void Start()
	{
		monsterDoorLeft = GameObject.Find ("monsterDoorLeft");
		monsterDoorRight = GameObject.Find ("monsterDoorRight");
		levelFinishedController = GameObject.Find ("LevelController").GetComponent<LevelFinishedController>();
		StartCoroutine(WakeUpMonster());
	}

	IEnumerator WakeUpMonster() 
	{
		for (int i=0; i < levelFinishedController.getNumberOfMonsters(); i++) 
		{
			yield return new WaitForSeconds(delay);
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