using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class LevelDefinition
		{
				private static int firstLevelWithDevice = 1;
				private static int firstLevelWithJumpItem = 2;

				private static int firstLevelWithLightMachine = 0;
				private static int firstLevelWithCrane = 3;
				private static int firstLevelWithSmasher = 7;
				private static int firstLevelWithDrone = 5;
				private static int firstLevelWithStunGun = 6;

				List<Level> levels1 = new List<Level> ();
				List<Level> levels2 = new List<Level> ();
				List<Level> levels3 = new List<Level> ();
				List<Level> levels4 = new List<Level> ();

				public LevelDefinition ()
				{
					// keys, monsters, time of 1st monster appear, time of subsequent mosnters,
					// maze rows, maze columns

					// 1 player levels

					//1
					levels1.Add(new Level(3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 20.4f)
					},1,15,7,7, null));

		 	  		// 2 player levels

					//1
					levels2.Add(new Level(1,new List<MonsterTemplate>{},15,15,6,6, null));
					//2
					levels2.Add(new Level(1,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.4f)
					},5,15,7,7, null));
					//3
					levels2.Add(new Level(2,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.4f)
					},15,6,6,6, null));
					//4
					levels2.Add(new Level(2,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},10,15,7,7, "EnableNoWallsEnding"));
					//5
					levels2.Add(new Level(2,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.0f)
					},5,6,7,7, null));
					//6
					levels2.Add(new Level(3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Flying", 2.4f)
					},5,6,8,8, "EnableNoWallsEnding"));
					//7
					levels2.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.4f)
					},5,6,9,9, null));
					//8
					levels2.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Standard", 3.2f)
					},5,6,9,9, "EnableTrapEnding"));
					//9
					levels2.Add(new Level(5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f)
					},5,10,10,10, null));
					//10
					levels2.Add(new Level(5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.4f)
					},5,10,10,10, null));	

					// 3 player levels	

					//1
					levels3.Add(new Level(2,new List<MonsterTemplate>{},15,15,6,6, null));
					//2
					levels3.Add(new Level(2,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.4f)
					},5,15,7,7, null));
					//3
					levels3.Add(new Level(3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.4f)
					},15,6,6,6, null));
					//4
					levels3.Add(new Level(3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},10,15,7,7, "EnableNoWallsEnding"));
					//5
					levels3.Add(new Level(3,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.0f)
					},5,6,7,7, null));
					//6
					levels3.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Flying", 2.4f)
					},5,6,8,8, "EnableNoWallsEnding"));
					//7
					levels3.Add(new Level(5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.4f)
					},5,6,9,9, null));
					//8
					levels3.Add(new Level(5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Standard", 3.2f)
					},5,6,9,9, "EnableNoWallsEnding"));
					//9
					levels3.Add(new Level(6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f)
					},5,10,10,10, null));
					//10
					levels3.Add(new Level(6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.4f)
					},5,10,10,10, null));	

					// 4 player levels

					//1
					levels4.Add(new Level(3,new List<MonsterTemplate>{},15,15,6,6, null));
					//2
					levels4.Add(new Level(3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.4f)
					},5,15,7,7, null));
					//3
					levels4.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.4f)
					},15,6,6,6, null));
					//4
					levels4.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},10,15,7,7, "EnableNoWallsEnding"));
					//5
					levels4.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.0f)
					},5,6,7,7, null));
					//6
					levels4.Add(new Level(5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Flying", 2.4f)
					},5,6,8,8, "EnableNoWallsEnding"));
					//7
					levels4.Add(new Level(6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.4f)
					},5,6,9,9, null));
					//8
					levels4.Add(new Level(6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Standard", 3.2f)
					},5,6,9,9, "EnableNoWallsEnding"));
					//9
					levels4.Add(new Level(7,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f)
					},5,10,10,10, null));
					//10
					levels4.Add(new Level(7,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.4f)
					},5,10,10,10, null));
				}

				public List<Level> getLevels(int numOfPlayers)
				{
					if (numOfPlayers < 2)
					{
						return levels1;
					}
					else if (numOfPlayers == 2)
					{
						return levels2;
					}
					else if (numOfPlayers == 3)
					{
						return levels3;
					}
					else
					{
						return levels4;
					}
				}

				public int getFirstLevelWithDevice()
				{
					return firstLevelWithDevice;
				}

				public int getFirstLevelWithJumpItem()
				{
					return firstLevelWithJumpItem;
				}

				public int getFirstLevelWithLightMachine()
				{
					return firstLevelWithLightMachine;
				}

				public int getFirstLevelWithCrane()
				{
					return firstLevelWithCrane;
				}

		
				public int getFirstLevelWithSmasher()
				{
					return firstLevelWithSmasher;
				}

				public int getFirstLevelWithDrone()
				{
					return firstLevelWithDrone;
				}

				public int getFirstLevelWithStunGun()
				{
					return firstLevelWithStunGun;
				}
		}
}

