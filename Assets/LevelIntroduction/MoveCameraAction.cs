using UnityEngine;
using System.Collections;

public class MoveCameraAction : Action  {

	private const float cameraSpeed = 50f;
	private const float cameraRotationSpeed = 2f;

	GameObject camera;
	Vector3 targetPosition;
	Vector3 newCameraPosition;
	Quaternion newCameraRotation;

	public MoveCameraAction(GameObject camera, Vector3 targetPosition)
	{
		this.camera = camera;
		this.targetPosition = targetPosition;
		this.newCameraPosition = new Vector3(Random.Range (-10f, 10f),
		                                     Random.Range (5f, 15f),
		                                     0);
		this.newCameraRotation = Quaternion.LookRotation(targetPosition - newCameraPosition);
	}

	public MoveCameraAction(GameObject camera, Vector3 newCameraPosition, Quaternion newCameraRotation)
	{
		this.camera = camera;
		this.newCameraPosition = newCameraPosition;
		this.newCameraRotation = newCameraRotation;
	}

	public void act()
	{
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
