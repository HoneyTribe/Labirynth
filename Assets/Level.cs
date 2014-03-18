using System;
namespace AssemblyCSharp
{
		public class Level
		{
				private int numberOfKeys;
				private int numberOfMonsters;

				public Level (int numberOfKeys, int numberOfMonsters)
				{
					this.numberOfKeys = numberOfKeys;
					this.numberOfMonsters = numberOfMonsters;
				}

				public int getNumberOfKeys()
				{
					return numberOfKeys;
				}
				
				public int getNumberOfMonsters()
				{
					return numberOfMonsters;
				}
		}
}

