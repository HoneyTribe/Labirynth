﻿using UnityEngine;
using System.Collections;
using Pathfinding;

public class StandardMonsterController : AbstractMonsterController {

	private float prevDistance;

	private Path[] lastPaths = new Path[0];

	public override void go () 
	{
		float distance = Vector3.Distance(transform.localPosition, newPosition);

		if ((recalculateTrigger) || (distance == 0) || (Mathf.Abs(distance - prevDistance) < EPSILON))
		{
			if (!isCalculating())
			{
				Vector3[] targets = getTarget();
				lastPaths = new Path[targets.Length];
				for (int i=0; i < targets.Length; i++)
				{
					ABPath p = ABPath.Construct (transform.localPosition, targets[i], OnTestPathComplete);
					lastPaths[i] = p;
					AstarPath.StartPath(p);
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
			if ((p.vectorPath[0].x == abPath.originalStartPoint.x) &&
				(p.vectorPath[0].z == abPath.originalStartPoint.z))
			{
				newPosition = p.vectorPath[1];
			}
			else
			{
				// monster behind the door
				newPosition = p.vectorPath[0];
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
}
