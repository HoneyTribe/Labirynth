using UnityEngine;
using System;
namespace AssemblyCSharp
{
		public class Move
		{
				private Vector2 wall;
				private Vector2 newPos;
				
				public Move(Vector2 wall, Vector2 newPos)
				{
					this.wall = wall;
					this.newPos = newPos;
				}
				
				public Vector2 getWall()
				{
					return wall;
				}
				
				public Vector2 getNewPos()
				{
					return newPos;
				}
		}
}

