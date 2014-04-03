using System;
namespace AssemblyCSharp
{
		public class MonsterTemplate
		{
				private string type;
				private float speed;

				public MonsterTemplate (string type, float speed)
				{
					this.type = type;
					this.speed = speed;
				}

				public string getType()
				{
					return type;
				}

				public float getSpeed()
				{
					return speed;
				}	
		}
}

