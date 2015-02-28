using UnityEngine;
using System.Collections;

public class TopLightController : MonoBehaviour {

	public static TopLightController instance;

	private static float maxIntensity = 0.8f;

	private static int progressBarSize = 100;
	private static float attractionCost = 0.3f;
	private static float restoreVelocity = 0.03125f; // It needs 1/restoreVelocity seconds to regenerate (32 seconds).

	public float openningInterval = 1.0f;
	public float closingInterval = 0.5f;
	private float timeLeft = 0.0f;

	private float param;
	private GUIStyle borderStyle;
	private GUIStyle outerStyle;
	private GUIStyle energyStyle;
	private GUIStyle lowEnergyStyle;
	private float energy = 1.0f;

	public GameObject laserPrefab;

	private GameObject ball;

	private bool entered;
	private ScoreController scoreController;

	void Start()
	{
		instance = this;
		ball = GameObject.Find ("SpaceMachine_Light");

		borderStyle = new GUIStyle ();
		Texture2D borderTexture = new Texture2D (1, 1);
		borderTexture.SetPixel (0, 0, Color.white);
		borderTexture.Apply ();
		borderStyle.normal.background = borderTexture;

		outerStyle = new GUIStyle ();
		Texture2D outerTexture = new Texture2D (1, 1);
		outerTexture.SetPixel (0, 0, Color.black);
		outerTexture.Apply ();
		outerStyle.normal.background = outerTexture;

		energyStyle = new GUIStyle ();
		Texture2D energyTexture = new Texture2D (1, 1);
		energyTexture.SetPixel (0, 0, Color.blue);
		energyTexture.Apply ();
		energyStyle.normal.background = energyTexture;

		lowEnergyStyle = new GUIStyle ();
		Texture2D lowEnergyTexture = new Texture2D (1, 1);
		lowEnergyTexture.SetPixel (0, 0, Color.red);
		lowEnergyTexture.Apply ();
		lowEnergyStyle.normal.background = lowEnergyTexture;
	}

	public bool isEntered()
	{
		return entered;
	}

	void OnGUI()
	{
		if(entered == true)
		{
			GUI.BeginGroup(new Rect (Screen.width / 2 - progressBarSize / 2, Screen.height - 20, progressBarSize, 10));
			GUI.depth = 2;
			GUI.Box (new Rect (0, 0, progressBarSize, 10), "", borderStyle);
			GUI.Box (new Rect (1, 1, progressBarSize - 2, 8), "", outerStyle);
			if (energy >= attractionCost)
			{
				GUI.Box (new Rect (1, 1, energy * (progressBarSize - 2), 8), "", energyStyle);
			}
			else
			{
				GUI.Box (new Rect (1, 1, energy * (progressBarSize - 2), 8), "", lowEnergyStyle);
			}
			GUI.EndGroup();
		}
		
	}

	void Update()
	{
		changeEnergy (Time.deltaTime * restoreVelocity);

		if (timeLeft > 0)
		{
			float lightStep = param * Time.deltaTime;

			light.intensity += lightStep;
			timeLeft -= Time.deltaTime;
		}
		else
		{
			if (param < 0)
			{
				light.intensity = 0;
			}
		}
	}
	
	public void TurnOn ()
	{
		entered = true;
		param = maxIntensity / openningInterval;
		timeLeft = openningInterval;
		TopLightEnergy.instance.ChangePos();

		if(LevelFinishedController.instance.getLevel() == 0 || LevelFinishedController.instance.getLevel() == 1 ||
		   LevelFinishedController.instance.getLevel() == 5 || LevelFinishedController.instance.getLevel() == 8 ||
		   LevelFinishedController.instance.getLevel() == 11)
		{
			FloorInstructions.instance.ChangeInstructions();
		}
	}

	public void TurnOff ()
	{
		entered = false;
		param = - maxIntensity / closingInterval;
		timeLeft = closingInterval;
		TopLightEnergy.instance.ChangePos();

		if(LevelFinishedController.instance.getLevel() == 0 || LevelFinishedController.instance.getLevel() == 1 ||
		   LevelFinishedController.instance.getLevel() == 5 || LevelFinishedController.instance.getLevel() == 8)
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
						StartCoroutine(showLaser(monster.transform.localPosition));
						monsterAttracted = true;
					}
				}

				if (monsterAttracted)
				{
					changeEnergy(-attractionCost);
					DeviceController.instance.ShowHologram();
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
		if ((light.intensity > 0) && (angle < light.spotAngle/2f))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	IEnumerator showLaser(Vector3 monsterPosition)
	{
		GameObject laser = (GameObject) Instantiate (laserPrefab, ball.transform.position, Quaternion.Euler(0, 0, 0)); 
		LaserController laserController = laser.GetComponent<LaserController>();
		laserController.shoot (ball.transform.position, monsterPosition);
		yield return new WaitForSeconds(0.2f);

		GameObject laser2 = (GameObject) Instantiate (laserPrefab, monsterPosition, Quaternion.Euler(0, 0, 0)); 
		LaserController laserController2 = laser2.GetComponent<LaserController>();
		laserController2.shoot (monsterPosition, DeviceController.instance.transform.position);
		yield return new WaitForSeconds(0.2f);

		Destroy (laser);
		Destroy (laser2);
	}
}
