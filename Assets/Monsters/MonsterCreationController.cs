using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

		List<float> position = Instantiation.instance.getMonsterWalkablePositions ();
		int posIndex = Random.Range (0, position.Count);

		Vector3 pos = new Vector3 (door.transform.localPosition.x + 3 * door.transform.right.x,
		                           prefab.transform.position.y,
		                           position[posIndex]);
		GameObject monster = (GameObject) Instantiate (prefab, pos, Quaternion.Euler(0, 0, 0)); 
		monster.GetComponent<AbstractMonsterController> ().setSpeed (monsterTemplate.getSpeed());

		return monster;
	}

	IEnumerator ShowMonster(string monsterType)
	{
		GameObject monster = CreateMonster(monsterDoorLeft, new AssemblyCSharp.MonsterTemplate(monsterType, 0));
		monster.tag = "TempObject";
		monsterDoorLeft.gameObject.SendMessage("OpenDoor");
		yield return new WaitForSeconds(10f);
		if (monster != null)
		{
			Destroy (monster);
		}
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