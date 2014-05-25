using UnityEngine;
using System;

public class KeyPosition
{
		Vector2 position;
		int distance;


		public KeyPosition (Vector2 position, int distance)
		{
			this.position = position;
			this.distance = distance;
		}

		public Vector2 getPosition()
		{
			return position;
		}

		public int getDistance()
		{
			return distance;
		}
}


