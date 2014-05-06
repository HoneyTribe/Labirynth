using UnityEngine;
using System.Collections;

public class MoveCameraAction : Action  {

	GameObject camera;
	Vector3 targetPosition;

	public MoveCameraAction(GameObject camera, Vector3 targetPosition)
	{
		this.camera = camera;
		this.targetPosition = targetPosition;
	}

	public void act()
	{

	}

	public bool finished()
	{
		return true;
	}
}
