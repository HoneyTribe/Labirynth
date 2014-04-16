﻿using UnityEngine;
using System.Collections;

public class StandardMonsterController : AbstractMonsterController {

	public override void go (ref Vector3 newPosition) 
	{

		float distance = Vector3.Distance(transform.localPosition, newPosition) - EPSILON;

		if ((recalculateTrigger) || (distance <= 0))
		{
			Vector3 targetPosition = getTarget();
			newPosition = maze.giveMeNextPosition(transform.localPosition, targetPosition);

			if ((maze.isInside(targetPosition)) &&
			    ((maze.transformToMazeCoordinates(targetPosition).Equals(maze.transformToMazeCoordinates(newPosition))) ||
			     (maze.transformToMazeCoordinates(targetPosition).Equals(maze.transformToMazeCoordinates(transform.localPosition)))))
			{
				newPosition = targetPosition;
				newPosition.y = transform.localPosition.y;
			}
			transform.rotation = Quaternion.LookRotation(newPosition - transform.localPosition);
		}
		else
		{
			transform.position = Vector3.Lerp (
				transform.localPosition, newPosition, Time.deltaTime * speed / distance);
		}
	}

}
