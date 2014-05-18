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
				private string ending;

				public Level (int numberOfKeys, List<MonsterTemplate> monsters, int timeToFirstMonster,
		              int timeBetweenMonsters, int mazeSizeX, int mazeSizeZ, string ending)
				{
					this.numberOfKeys = numberOfKeys;
					this.monsters = monsters;
					this.timeToFirstMonster = timeToFirstMonster;
					this.timeBetweenMonsters = timeBetweenMonsters;
					this.mazeSizeX = mazeSizeX;
					this.mazeSizeZ = mazeSizeZ;
					this.ending = ending;
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

				public string getEnding()
				{
					return ending;
				}
		}
}

