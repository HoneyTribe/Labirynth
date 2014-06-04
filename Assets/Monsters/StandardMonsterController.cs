 using UnityEngine;
using System.Collections.Generic;
using Pathfinding;

public class StandardMonsterController : AbstractMonsterController {

	private float prevDistance;

	private Path[] lastPaths = new Path[0];

	private List<Vector3> guardingPositions = new List<Vector3>();
	private int currentGuardingPosition = 0;

	public override void go () 
	{
		float distance = Vector3.Distance(transform.localPosition, newPosition);

		if ((recalculateTrigger) || (distance == 0) || (Mathf.Abs(distance - prevDistance) < EPSILON))
		{
			if (!isCalculating())
			{
				List<Vector3> targets = getTarget();
				// negation to understand
				if ((targets.Count != 1) || (targets[0] != DeviceController.instance.gameObject.transform.position))
				{
					targets = checkIfAnyTargetAvailable(targets);
				}

				if (targets.Count != 0)
				{
					lastPaths = new Path[targets.Count];
					for (int i=0; i < targets.Count; i++)
					{
						ABPath p = ABPath.Construct (transform.localPosition, targets[i], OnTestPathComplete);
						lastPaths[i] = p;
						AstarPath.StartPath(p);
					}
				}
				else
				{
					newPosition = guardingPositions[currentGuardingPosition % guardingPositions.Count];
					transform.rotation = Quaternion.LookRotation(newPosition - transform.localPosition);
					textMesh.transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
					currentGuardingPosition++;
				}
			}
		}
		else
		{
			transform.position = Vector3.Lerp (
				transform.localPosition, newPosition, Time.deltaTime * speed / distance);
			prevDistance = distance;
		}
	}

	private List<Vector3> checkIfAnyTargetAvailable(List<Vector3> targets)
	{
		List<Vector3> available = new List<Vector3> ();
		GraphNode currentNode = AstarPath.active.GetNearest (transform.position).node;
		foreach (Vector3 target in targets)
		{
			GraphNode node = AstarPath.active.GetNearest (target).node;
			if (currentNode.Area == node.Area)
			{
				available.Add(target);
			}
		}

		return available;
	}

	private void OnTestPathComplete(Path p)
	{
		if (p.error) 
		{
			Debug.LogError("One target could not be reached! " + p.errorLog);
		}

		if (!isCalculating())
		{
			CalculationComplete();
		}
	}

	private void CalculationComplete()
	{
		Path p = null;
		float shortestLength = float.PositiveInfinity;

		for (int i=0;i<lastPaths.Length;i++) {

			float length = lastPaths[i].GetTotalLength();
			
			if (p == null || length < shortestLength) {
				p = lastPaths[i];
				shortestLength = length;
			}
		}

		ABPath abPath = ((ABPath) p);
		if (p.vectorPath.Count > 1)
		{
			if (Mathf.Abs(abPath.originalStartPoint.x) > Instantiation.planeSizeX/2)
			{
				// monster behind the door
				newPosition = p.vectorPath[0];
			}
			else
			{
				newPosition = p.vectorPath[1];
			}
		}
		else
		{
			newPosition = ((ABPath) p).originalEndPoint;
		}

		newPosition.y = transform.localPosition.y;

		transform.rotation = Quaternion.LookRotation(newPosition - transform.localPosition);
		textMesh.transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
		prevDistance = 0f;
	}

	bool isCalculating()
	{
		bool calculating = false;
		foreach (Path p in lastPaths)
		{
			if (!p.IsDone())
			{
				calculating = true;
			}
		}

		return calculating;
	}

	public void AddGuardingPosition(Vector3 position)
	{
		guardingPositions.Add (position);
	}
}
