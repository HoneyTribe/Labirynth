using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractMonsterController : MonoBehaviour, StoppableObject {

	protected static Vector3 MASK = new Vector3 (1, 0, 1);
	protected static float EPSILON = 0.01f;

	private static int activatHash = Animator.StringToHash ("Activate");
	private static int stopHash = Animator.StringToHash ("Stop");
	private static int IdleHash = Animator.StringToHash ("Idle");
	private static int NotIdleHash = Animator.StringToHash ("NotIdle");
	private bool idleSaved = true;
	private bool idle = true;

	protected float speed;

	private GameObject topLight;
	protected GameObject device;
	private List<PlayerController> playerControllers = new List<PlayerController>();

	protected TextMesh textMesh;

	private static float paralysingInterval = 5f;
	private float timeLeft;
	private float paralysingTime;
	protected bool recalculateTrigger;

	protected Vector3 newPosition;
	private Vector3 paralysedPosition;

	private bool monsterStopped;

	public bool canBeZapped = false;
	public bool savedCanBeZapped = false;

	private GameObject distractParticlesPrefab;
	private GameObject particles;

	public Shader normalShader;
	public Shader toonShader;
	public Shader ghostShader;
	public Renderer rend;
	public string myName;

	private Animator anim;

	public abstract void go ();

	void Start () {

		textMesh = gameObject.GetComponentInChildren<TextMesh> ();
		anim = gameObject.GetComponentInChildren<Animator> ();

		GameObject gameController = GameObject.Find ("GameController");
		device = GameObject.Find ("DeviceContainer");
		foreach (InputController inputController in LevelFinishedController.instance.getControllers())
		{
			playerControllers.Add(GameObject.Find ("Player" + inputController.getPlayerId()).GetComponent<PlayerController>());
		}
		recalculateTrigger = true;
		distractParticlesPrefab = (GameObject) Resources.Load("Angry_ennemie/Angry_Ennemie_Prefab_3");

		normalShader = Shader.Find("Diffuse");
		toonShader = Shader.Find("Toon/Basic Outline");
		ghostShader = Shader.Find("Transparent/Bumped Specular"); 

		if(this.name == "LazyMonster(Clone)" || this.name == "Monster(Clone)")
		{
			rend = transform.Find("Mummy_1_Anim_01/Mummy").GetComponent<Renderer>();
			//rend.material = mummy;
			//rend.material.SetFloat("OutlineWidth", 5.5f);
			//rend.material.SetFloat("OutlineColor", );
		}
		else if(this.name == "FlyingMonster(Clone)")
		{
			rend = transform.Find("Ghost").GetComponent<Renderer>();
			normalShader = ghostShader;
			//rend.material.SetFloat("_Outline", 10.0f);
			//rend.material.SetFloat("OutlineColor", );
		}
	}



	void Update () {

		if (LevelFinishedController.instance.isStopped())
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			return;
		}

		textMesh.text = "";
		if (timeLeft > 0)
		{
			if (timeLeft == DeviceController.interval)
			{
				recalculateTrigger  = true;
				if (anim!=null) anim.SetTrigger(activatHash);
				rend.material.shader = toonShader;
				StartCoroutine(ChangeShader());
				//spawnDecoyTrail.changeHasSpawned();

			}
			timeLeft -= Time.deltaTime;
			textMesh.text = ((int) (timeLeft + 1)).ToString();
			if (timeLeft <= 0)
			{
				rigidbody.velocity = Vector3.zero;
				recalculateTrigger = true;
				if (anim!=null) anim.SetTrigger(stopHash);
				rend.material.shader = normalShader;
				Destroy(particles);
			}
		}

		if (paralysingTime > 0)
		{
			paralysingTime -= Time.deltaTime;
			transform.position = new Vector3(paralysedPosition.x + Mathf.Sin(50 * paralysingTime) * 0.1f,
			                                 paralysedPosition.y,
			                                 paralysedPosition.z);
			return;
		}

		if (!monsterStopped)
		{
			go ();
		}

		recalculateTrigger = false;

		// check if standard monster stopped moving. Trigger idle anim.
		if(this.name == "Monster(Clone)")
		{
			if (this.rigidbody.IsSleeping() == true)
			{
				idle = true;
				Idle();
			}
			else
			{
				idle = false;
				NotIdle();
			}
		}

	}

	IEnumerator ChangeShader()
	{
		yield return new WaitForSeconds(0.3f);
		rend.material.shader = normalShader;
	}

	private void Idle()
	{
		if(idle == true && idleSaved == false)
		{
			idleSaved = true;
			anim.SetTrigger(IdleHash);
		}

	}

	private void NotIdle()
	{
		if(idle == false && idleSaved == true)
		{
			idleSaved = false;
			anim.SetTrigger(NotIdleHash);
		}

	}

	public void setStopped(bool monsterStopped)
	{
		this.monsterStopped = monsterStopped;
		if (!monsterStopped)
		{
			recalculateTrigger = true;
		}
	}

	public void setAttracted()
	{
		timeLeft = DeviceController.interval;


		if (particles == null)
		{
			particles = (GameObject) Instantiate(distractParticlesPrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
			particles.transform.parent = gameObject.transform;
			particles.transform.localPosition = Vector3.zero;
		}

	}

	public void Paralyse()
	{
		paralysedPosition = transform.position;
		paralysingTime = paralysingInterval;

	}

	public void setSpeed(float speed)
	{
		this.speed = speed * LevelFinishedController.instance.gameSpeed;
	}

	protected List<Vector3> getTarget()
	{
		List<Vector3> players = new List<Vector3> ();
		foreach (PlayerController playerController in playerControllers)
		{
			if ((!playerController.hasEnteredAnyMachine()) && (!playerController.isParalysed()))
			{
				players.Add (playerController.gameObject.transform.position);
			}
		}

		// if all players in machines
		if (players.Count == 0)
		{
			foreach (PlayerController playerController in playerControllers)
			{
				if (!playerController.isParalysed())
				{
					players.Add (playerController.gameObject.transform.position);
				}
			}
		}

		Vector3 monsterPos = transform.position;

		if (timeLeft > 0)
		{
			return new List<Vector3>(){device.transform.position};
		}

		List<Vector3> closestPlayers = new List<Vector3> ();

		// get all inside
		foreach (Vector3 player in players)
		{
			if (Instantiation.instance.isInside(player))
		    {
				closestPlayers.Add (player);
			}
		}

		if (closestPlayers.Count == 0)
		{
			closestPlayers = players;
		}

		return closestPlayers;
	}

	public void Recalculate()
	{
		recalculateTrigger = true;
	}

	public float getTimeLeft()
	{
		return timeLeft;
	}
}
