using UnityEngine;
using System.Collections;

public class MoveCameraAction : Action  {

	private const float cameraSpeed = 15f;
	private const float cameraRotationSpeed = 4f;

	GameObject camera;
	string target;
	Vector3 targetPosition;
	Vector3 newCameraPosition;
	Quaternion newCameraRotation;

	public MoveCameraAction(string target)
	{
		this.target = target;
		this.camera = GameObject.Find ("MainCamera_Front");
	}

	public MoveCameraAction(Vector3 newCameraPosition, Quaternion newCameraRotation)
	{
		this.camera = GameObject.Find ("MainCamera_Front");
		this.newCameraPosition = newCameraPosition;
		this.newCameraRotation = newCameraRotation;
	}

	public void act()
	{
		if (this.newCameraPosition == Vector3.zero)
		{
			GameObject targetObject = GameObject.Find (target);
			if (targetObject == null)
			{
				if (target.Contains("Player"))
				{
					target = "Player";
				}
				targetObject = GameObject.FindGameObjectsWithTag(target)[0]; 
			}

			this.targetPosition = targetObject.transform.position;
			this.newCameraPosition = new Vector3(Random.Range (-15f, 15f),
			                                     Random.Range (10f, 20f),
			                                     0);
			Vector3 zoom = (newCameraPosition - targetPosition).normalized * 15;
			this.newCameraPosition = this.targetPosition + zoom;
			this.newCameraRotation = Quaternion.LookRotation(targetPosition - newCameraPosition);
		}

		float distance = Vector3.Distance(camera.transform.position, newCameraPosition);

		camera.transform.position = Vector3.Lerp (
			camera.transform.position, newCameraPosition, Time.deltaTime * cameraSpeed / distance);

		camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, newCameraRotation, Time.deltaTime * cameraRotationSpeed);
	}

	public bool finished()
	{
		return ((camera.transform.position == newCameraPosition) &&
			    (Quaternion.Angle(camera.transform.rotation, newCameraRotation) < 0.01f));
	}
}
