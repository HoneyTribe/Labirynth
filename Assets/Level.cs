using System;
namespace AssemblyCSharp
{
		public class Level
		{
				private int numberOfKeys;
				private int numberOfMonsters;
				private int timeToFirstMonster;
				private int timeBetweenMonsters;
				private float monsterSpeed;
				private int mazeSizeX;
				private int mazeSizeZ;

				public Level (int numberOfKeys, int numberOfMonsters, int timeToFirstMonster,
		              int timeBetweenMonsters, float monsterSpeed, int mazeSizeX, int mazeSizeZ)
				{
					this.numberOfKeys = numberOfKeys;
					this.numberOfMonsters = numberOfMonsters;
					this.timeToFirstMonster = timeToFirstMonster;
					this.timeBetweenMonsters = timeBetweenMonsters;
					this.monsterSpeed = monsterSpeed;
					this.mazeSizeX = mazeSizeX;
					this.mazeSizeZ = mazeSizeZ;
				}

				public int getNumberOfKeys()
				{
					return numberOfKeys;
				}
				
				public int getNumberOfMonsters()
				{
					return numberOfMonsters;
				}

				public int getTimeToFirstMonster()
				{
					return timeToFirstMonster;
				}

				public int getTimeBetweenMonsters()
				{
					return timeBetweenMonsters;
				}

				public float getMonsterSpeed()
				{
					return monsterSpeed;
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

