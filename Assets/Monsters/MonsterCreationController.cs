using UnityEngine;
using System.Collections;

public class MonsterCreationController : MonoBehaviour {

	private GameObject monsterDoorLeft;
	private GameObject monsterDoorRight;

	public GameObject monsterPrefab;
	public GameObject flyingMonsterPrefab;

	void Start()
	{
		monsterDoorLeft = GameObject.Find ("monsterDoorLeft");
		monsterDoorRight = GameObject.Find ("monsterDoorRight");
		StartCoroutine(WakeUpMonster());
	}

	IEnumerator WakeUpMonster() 
	{
		while (LevelFinishedController.instance.isStopped())
		{
			yield return new WaitForSeconds(0.5f);
		}

		yield return new WaitForSeconds(LevelFinishedController.instance.getTimeToFirstMonster());
		foreach (AssemblyCSharp.MonsterTemplate monster in LevelFinishedController.instance.getMonsters())
		{
			int entrance = Random.Range(0, 2);
			if (entrance == 0)
			{
				monsterDoorLeft.gameObject.SendMessage("OpenDoor");
				yield return new WaitForSeconds(4f);
				CreateMonster(monsterDoorLeft, monster);
			}
			else
			{
				monsterDoorRight.gameObject.SendMessage("OpenDoor");
				yield return new WaitForSeconds(4f);
				CreateMonster(monsterDoorRight, monster);
			}
			yield return new WaitForSeconds(LevelFinishedController.instance.getTimeBetweenMonsters());
		}
	}

	private GameObject CreateMonster(GameObject door, AssemblyCSharp.MonsterTemplate monsterTemplate)
	{
		GameObject prefab = getPrefab (monsterTemplate.getType());

		Vector3 pos = new Vector3 (door.transform.localPosition.x - 3 * door.transform.forward.x,
		                           prefab.transform.position.y,
		                           prefab.transform.position.z);
		GameObject monster = (GameObject) Instantiate (prefab, pos, Quaternion.Euler(0, 0, 0)); 
		monster.GetComponent<AbstractMonsterController> ().setSpeed (monsterTemplate.getSpeed());
		monster.tag = "Monster";

		return monster;
	}

	IEnumerator ShowMonster(string monsterType)
	{
		GameObject monster = CreateMonster(monsterDoorLeft, new AssemblyCSharp.MonsterTemplate(monsterType, 0));
		monsterDoorLeft.gameObject.SendMessage("OpenDoor");
		yield return new WaitForSeconds(10f);
		Destroy (monster);
	}

	private GameObject getPrefab(string type)
	{
		switch (type)
		{
		case "Standard":
			return monsterPrefab;
		case "Flying":
			return flyingMonsterPrefab;
		default:
			throw new System.ArgumentException("Invalid monster identifier");
		}
	}
}