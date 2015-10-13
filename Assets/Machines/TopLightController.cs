using UnityEngine;
using System.Collections;

public class TopLightController : MonoBehaviour {

	public static TopLightController instance;
	private static int STEPS = 21;

	private static float maxIntensity = 0.2f;
	private static float smallLightMaxIntensity = 1.3f;

	private static float attractionCost = 0.3f;
	private static float restoreVelocity = 0.03f; // It needs 1/restoreVelocity seconds to regenerate (30 seconds).
	private bool monsterTarget;

	public float openningInterval = 1.0f;
	public float closingInterval = 0.5f;
	public Material projectorMaterial;
	private float timeLeft = 0.0f;

	private float param;
	private float smallLightParam;
	private float energyParam;
	private float energy = 1.0f;

	private int zapCount = 0;

	public GameObject laserPrefab;
	public GameObject zapPrefab;

	private GameObject ball;
	private GameObject smallLight;

	private bool entered;
	private ScoreController scoreController;

	private int energyIndex = STEPS-1;
	private Texture[] projectorTexturesBlue = new Texture[STEPS];
	private Texture[] projectorTexturesRed  = new Texture[STEPS];

	private GameObject[] monsterList;

	// Variables for spawning zap prefab
	public float sizeOfZap = 3.0f;
	private float disToMonster;
	private Vector3 lineToMonster;
	public float zapOffset = 1.0f;
	private GameObject zap;
	private Vector3 zapTempPos;
	///public float multi;

	private Animator machineLight;
	private static int onHash = Animator.StringToHash ("On");
	private static int offHash = Animator.StringToHash ("Off");
	private static int blinkHash = Animator.StringToHash ("Blink");

	void Start()
	{
		instance = this;
		ball = GameObject.Find ("SpaceMachine_Light");
		smallLight = GameObject.Find ("TopLightSmall");
		monsterList = GameObject.FindGameObjectsWithTag ("Monster");

		int step = 100/(STEPS-1);
		projectorTexturesBlue[0] = (Texture2D) Resources.Load("EnergyBar/Light_EnergyBar/Gray/EnergyBar_light_gray", typeof(Texture2D));
		projectorTexturesRed[0] = (Texture2D) Resources.Load("EnergyBar/Light_EnergyBar/Gray/EnergyBar_light_gray", typeof(Texture2D));
		for (int i=1; i<STEPS; i++)
		{
			projectorTexturesBlue[i] = (Texture2D) Resources.Load("EnergyBar/Light_EnergyBar/Bleu/EnergyBar_light_bleu_" + i*step, typeof(Texture2D));
			projectorTexturesRed[i] = (Texture2D) Resources.Load("EnergyBar/Light_EnergyBar/Red/EnergyBar_light_Red_" + i*step, typeof(Texture2D));
		}
		projectorMaterial.SetTexture("_ShadowTex", projectorTexturesBlue [energyIndex]);
		projectorMaterial.SetFloat ("_Opacity", 0);

		machineLight = ball.GetComponent<Animator> ();
	}

	public bool isEntered()
	{
		return entered;
	}

	void Update()
	{
		changeEnergy (Time.deltaTime * restoreVelocity);

		if (timeLeft > 0)
		{
			GetComponent<Light>().intensity += param * Time.deltaTime;
			smallLight.GetComponent<Light>().intensity += smallLightParam * Time.deltaTime;

			float energyStep = energyParam * Time.deltaTime;

			float opacity = projectorMaterial.GetFloat ("_Opacity" );
			opacity += energyStep;
			projectorMaterial.SetFloat ("_Opacity", opacity );

			timeLeft -= Time.deltaTime;
		}
		else
		{
			if (param < 0)
			{
				GetComponent<Light>().intensity = 0;
			}
			if (smallLightParam < 0) 
			{
				smallLight.GetComponent<Light>().intensity = 0;
			}
			if (energyParam < 0)
			{
				projectorMaterial.SetFloat ("_Opacity", 0);
			}
		}

		foreach (GameObject monster in monsterList)
		{
			//myScript = GetComponent<AbstractMonsterController>();
			if(LevelFinishedController.instance.isDistractionEnabled() == true)
			{
				if ( isIlluminated(monster) && energy >= attractionCost )
				{
					monster.GetComponent<AbstractMonsterController>().canBeZapped = true;
					MonsterTargetOn();
				}
				else
				{
					monster.GetComponent<AbstractMonsterController>().canBeZapped = false;
					MonsterTargetOff();
				}
			}
		}
	}

	//triggered from MonsterCreationController
	public void updateMonsterList()
	{
		monsterList = GameObject.FindGameObjectsWithTag ("Monster");
	}

	private void MonsterTargetOn()
	{
		foreach (GameObject monster in monsterList)
		{
			if (monster.GetComponent<AbstractMonsterController>().canBeZapped == true
			    && monster.GetComponent<AbstractMonsterController>().savedCanBeZapped == false)
			{
				for(int i =0; i<monster.transform.childCount; i++)
				{
					if(monster.transform.GetChild(i).name=="TargetMonster_2")
					{
						int StartTargetHash = Animator.StringToHash ("StartTarget");
						monster.transform.GetChild(i).GetComponent<Animator>().SetTrigger(StartTargetHash);
						monster.GetComponent<AbstractMonsterController>().savedCanBeZapped = true;
					}
				}


			}
		}
	}

	private void MonsterTargetOff()
	{
		foreach (GameObject monster in monsterList)
		{
			if (monster.GetComponent<AbstractMonsterController>().canBeZapped == false
			    && monster.GetComponent<AbstractMonsterController>().savedCanBeZapped == true)
			{
				for(int i =0; i<monster.transform.childCount; i++)
				{
					if(monster.transform.GetChild(i).name=="TargetMonster_2")
					{
						int FinishTargetHash = Animator.StringToHash ("FinishTarget");
						monster.transform.GetChild(i).GetComponent<Animator>().SetTrigger(FinishTargetHash);
						monster.GetComponent<AbstractMonsterController>().savedCanBeZapped = false;
					}
				}


			}
		}
	}
	
	public void TurnOn ()
	{
		entered = true;
		param = maxIntensity / openningInterval;
		smallLightParam = smallLightMaxIntensity / openningInterval;
		energyParam = 1 / openningInterval;
		timeLeft = openningInterval;
		machineLight.SetTrigger(onHash);

		if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstLightLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstBlockLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstZapLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstTriggerLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDecoyLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.secondDecoyLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstCraneLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDroneLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstJumpBoxLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDroneBombLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstCraneLazerLevel)
		{
			FloorInstructions.instance.ChangeInstructions();
		}
	}

	public void TurnOff ()
	{
		entered = false;
		param = - maxIntensity / closingInterval;
		smallLightParam = - smallLightMaxIntensity / closingInterval;
		energyParam = - 1 / closingInterval;
		timeLeft = closingInterval;
		machineLight.SetTrigger(offHash);

		if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstLightLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstBlockLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstZapLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstTriggerLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDecoyLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.secondDecoyLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstCraneLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDroneLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstJumpBoxLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDroneBombLevel
		   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstCraneLazerLevel)
		{
			FloorInstructions.instance.ChangeInstructions();
		}
	}

	private void changeEnergy(float value)
	{
		energy += value;
		if (energy > 1.0f)
		{
			energy = 1.0f;
		}
		if (energy < 0.0f)
		{
			energy = 0.0f;
		}
		if ((int) (energy * (STEPS-1)) != energyIndex)
		{
			energyIndex = (int) (energy * (STEPS-1));
			if (energy > getMinCost())
			{
				projectorMaterial.SetTexture("_ShadowTex", projectorTexturesBlue [energyIndex]);
			}
			else
			{
				projectorMaterial.SetTexture("_ShadowTex", projectorTexturesRed [energyIndex]);
			}
		}
	}

	private float getMinCost()
	{
		float minCost = 0f;
		if (LevelFinishedController.instance.isDistractionEnabled())
		{
			minCost = attractionCost;
		}
		return minCost;
	}

	public void AttractMonster()
	{
		if (LevelFinishedController.instance.isDistractionEnabled())
		{
			if (energy>=attractionCost)
			{
				bool monsterAttracted = false;
				GameObject[] monsters = GameObject.FindGameObjectsWithTag ("Monster");
				foreach (GameObject monster in monsters)
				{
					if (isIlluminated(monster))
					{
						monster.GetComponent<AbstractMonsterController>().setAttracted();
						StartCoroutine(SpawnZap(monster.transform.localPosition));
						//SpawnZap(monster.transform.localPosition);
						monsterAttracted = true;
					}
				}

				if (monsterAttracted)
				{
					changeEnergy(-attractionCost);
					DeviceController.instance.ShowHologram();
					AudioController.instance.Play("013_LightZap");

					zapCount++;
					if(LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstDecoyLevel
					   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.firstZapLevel
					   || LevelFinishedController.instance.getLevel() == FloorInstructions.instance.secondDecoyLevel)
					{
						FloorInstructions.instance.ChangeInstructions();
					}
				}
			}
		}
	}

	public void ActivateItems()
	{
		if (LevelFinishedController.instance.isItemActivationEnabled())
		{
			if (energy>=attractionCost)
			{
				bool itemActivated = false;
				GameObject[] items = GameObject.FindGameObjectsWithTag ("Item");
				foreach (GameObject item in items)
				{
					if (isIlluminated(item))
					{
						JumpController jumpController = item.GetComponent<JumpController>();
						if (jumpController.hasAnyObjects())
						{
							jumpController.Activate();
							StartCoroutine(showLaser(item.transform.localPosition));
							itemActivated = true;
						}
					}
				}
			
				if (itemActivated)
				{
					changeEnergy(-attractionCost);
				}
			}
		}
	}

	private bool isIlluminated(GameObject obj)
	{
		Quaternion quat = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up);
		Vector3 lightDirection = new Vector3(0, 0, 1);		
		lightDirection = quat * lightDirection;
		
		Vector3 monsterDirection = new Vector3(obj.transform.localPosition.x - transform.position.x,
		                                       0,
		                                       obj.transform.localPosition.z - transform.position.z).normalized;
		float angle = Vector3.Angle(lightDirection, monsterDirection);
		if ((GetComponent<Light>().intensity > 0) && (angle < GetComponent<Light>().spotAngle/2f))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	IEnumerator SpawnZap(Vector3 monsterPosition)
	//private Vector3 SpawnZap(Vector3 monsterPosition)
	{

		//GameObject zap = (GameObject) Instantiate (zapPrefab, ball.transform.position, Quaternion.Euler(0, 0, 0)); 
		//ZapShoot zapShoot = zap.GetComponent<ZapShoot>();
		//zapShoot.shoot (ball.transform.position, monsterPosition);

		// Get your "straight line"
		lineToMonster = monsterPosition - ball.transform.position ;

		//distance of line
		disToMonster = lineToMonster.magnitude;
		
		// Instantiate the gameobject every x meters on that line
		for( float dist = sizeOfZap ; dist < (disToMonster - zapOffset) ; dist += sizeOfZap )
		{
			zap = (GameObject) Instantiate( zapPrefab ) ;
			zapTempPos = ball.transform.position + lineToMonster.normalized * dist;
			//zapTempPos.x += (Mathf.Sin(disToMonster - dist) * multi);
			zap.transform.position = zapTempPos;
			zap.transform.LookAt(monsterPosition);
		}

		yield return new WaitForSeconds(0.15f);

	}

	IEnumerator showLaser(Vector3 monsterPosition)
	{
		GameObject laser = (GameObject) Instantiate (laserPrefab, ball.transform.position, Quaternion.Euler(0, 0, 0)); 
		LaserController laserController = laser.GetComponent<LaserController>();
		laserController.shoot (ball.transform.position, monsterPosition);

		yield return new WaitForSeconds(0.3f);
		Destroy (laser);
		//GameObject laser2 = (GameObject) Instantiate (laserPrefab, monsterPosition, Quaternion.Euler(0, 0, 0)); 
		//LaserController laserController2 = laser2.GetComponent<LaserController>();
		//laserController2.shoot (monsterPosition, DeviceController.instance.transform.position);
		//yield return new WaitForSeconds(0.2f);
		
		//Destroy (laser);
		//Destroy (laser2);
	}

	public int getZapCount()
	{
		return zapCount;
	}
}
