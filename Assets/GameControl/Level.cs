using System;
using System.Collections.Generic;
namespace AssemblyCSharp
{
		public class Level
		{
				private int numberOfKeys;
				private List<MonsterTemplate> monsters;
				private int timeToFirstMonster;
				private int timeBetweenMonsters;
				private int mazeSizeX;
				private int mazeSizeZ;

				public Level (int numberOfKeys, List<MonsterTemplate> monsters, int timeToFirstMonster,
		              int timeBetweenMonsters, int mazeSizeX, int mazeSizeZ)
				{
					this.numberOfKeys = numberOfKeys;
					this.monsters = monsters;
					this.timeToFirstMonster = timeToFirstMonster;
					this.timeBetweenMonsters = timeBetweenMonsters;
					this.mazeSizeX = mazeSizeX;
					this.mazeSizeZ = mazeSizeZ;
				}

				public int getNumberOfKeys()
				{
					return numberOfKeys;
				}
				
				public List<MonsterTemplate> getMonsters()
				{
					return monsters;
				}

				public int getTimeToFirstMonster()
				{
					return timeToFirstMonster;
				}

				public int getTimeBetweenMonsters()
				{
					return timeBetweenMonsters;
				}

				public int getMazeSizeX()
				{
					return mazeSizeX;
				}

		        public int getMazeSizeZ()
				{
					return mazeSizeZ;
				}
		}
}

