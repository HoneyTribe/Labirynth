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

				public Level (int numberOfKeys, int numberOfMonsters, int timeToFirstMonster,
		              int timeBetweenMonsters, float monsterSpeed)
				{
					this.numberOfKeys = numberOfKeys;
					this.numberOfMonsters = numberOfMonsters;
					this.timeToFirstMonster = timeToFirstMonster;
					this.timeBetweenMonsters = timeBetweenMonsters;
					this.monsterSpeed = monsterSpeed;
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
		}
}

