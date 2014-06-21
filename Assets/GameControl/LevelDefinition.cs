using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class LevelDefinition
		{
				private static int firstLevelWithDevice = 1;
				private static int firstLevelWithJumpItem = 13;

				private static int firstLevelWithLightMachine = 0;
				private static int firstLevelWithCrane = 4;
				private static int firstLevelWithSmasher = 10;
				private static int firstLevelWithDrone = 7;
				private static int firstLevelWithStunGun = 11;

				List<Level> levels1 = new List<Level> ();
				List<Level> levels2 = new List<Level> ();
				List<Level> levels3 = new List<Level> ();
				List<Level> levels4 = new List<Level> ();

				public LevelDefinition ()
				{
					// keys, monsters, time of 1st monster appear, time of subsequent monsters,
					// maze rows, maze columns, ending, puzzle

					// 1 player levels

					//1
					levels1.Add(new Level(15,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 20.4f)
					},1,15,7,7, null, null));

		 	  		// 2 player levels

					//1
					levels2.Add(new Level(2,new List<MonsterTemplate>{},15,15,6,6, null, null));
					//2
					levels2.Add(new Level(5,new List<MonsterTemplate>{},0,0,7,7, null, "First"));
					//3
					levels2.Add(new Level(2,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},5,10,7,7, null, null));
					//4
					levels2.Add(new Level(3,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Flying", 2.4f)
					},5,10,8,8, "EnableNoWallsEnding", null));
					//5
					levels2.Add(new Level(5,new List<MonsterTemplate>{
					},5,10,7,7, null, "SimpleCranePuzzle"));
					//6
					levels2.Add(new Level(3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},5,5,7,7, null, null));
					//7
					levels2.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f)
					},5,5,8,8, "EnableTrapEnding", null));
					//8
					levels2.Add(new Level(9,new List<MonsterTemplate>{
					},5,5,7,7, null, "CranePuzzle"));
					//9
					levels2.Add(new Level(5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.6f)
					},5,5,8,8, null, null));
					//10
					levels2.Add(new Level(10,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Standard", 3.8f)
					},5,5,9,9, "EnableTrapEnding", null));
					//11
					levels2.Add(new Level(12,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Standard", 4.0f)
					},5,4,8,8, "EnableTrapEnding", null));
					//12
					levels2.Add(new Level(10,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Flying", 3.0f)
					},5,5,9,9, null, null));
					//13
					levels2.Add(new Level(15,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.2f)
					},5,5,10,10, null, null));
					//14
					levels2.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.4f)
					},15,15,6,6, null, null));
					//15
					levels2.Add(new Level(8,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f)
					},5,8,10,10, "EnableNoWallsEnding", null));


					// 3 player levels	

					//1
					levels3.Add(new Level(3,new List<MonsterTemplate>{},15,15,6,6, null, null));
					//2
					levels3.Add(new Level(5,new List<MonsterTemplate>{},0,0,7,7, null, "First"));
					//3
					levels3.Add(new Level(3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},5,10,7,7, null, null));
					//4
					levels3.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Flying", 2.4f)
					},5,10,8,8, "EnableNoWallsEnding", null));
					//5
					levels3.Add(new Level(5,new List<MonsterTemplate>{
					},5,10,7,7, null, "SimpleCranePuzzle"));
					//6
					levels3.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},5,5,8,8, null, null));
					//7
					levels3.Add(new Level(6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Flying", 2.6f)
					},5,5,8,8, "EnableTrapEnding", null));
					//8
					levels3.Add(new Level(9,new List<MonsterTemplate>{
					},5,5,7,7, null, "CranePuzzle"));
					//9
					levels3.Add(new Level(8,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.4f),
						new MonsterTemplate("Standard", 3.4f),
						new MonsterTemplate("Standard", 3.4f)
					},5,5,8,8, null, null));
					//10
					levels3.Add(new Level(10,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 3.2f),
						new MonsterTemplate("Flying", 3.2f),
						new MonsterTemplate("Standard", 3.6f)
					},5,5,9,9, "EnableTrapEnding", null));
					//11
					levels3.Add(new Level(15,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.8f)
					},5,5,8,8, "EnableTrapEnding", null));
					//12
					levels3.Add(new Level(10,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 3.2f),
						new MonsterTemplate("Flying", 3.2f),
						new MonsterTemplate("Flying", 3.2f)
					},5,5,9,9, null, null));
					//13
					levels3.Add(new Level(8,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.2f)
					},5,5,10,10, null, null));
					//14
					levels3.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.4f)
					},15,15,6,6, null, null));
					//15
					levels3.Add(new Level(8,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f)
					},5,8,10,10, "EnableNoWallsEnding", null));

					// 4 player levels

					//1
					levels4.Add(new Level(3,new List<MonsterTemplate>{},15,15,6,6, null, null));
					//2
					levels4.Add(new Level(5,new List<MonsterTemplate>{},0,0,7,7, null, "First"));
					//3
					levels4.Add(new Level(3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},5,10,7,7, null, null));
					//4
					levels4.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Flying", 2.4f)
					},5,10,8,8, "EnableNoWallsEnding", null));
					//5
					levels4.Add(new Level(5,new List<MonsterTemplate>{
					},5,10,7,7, null, "SimpleCranePuzzle"));
					//6
					levels4.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},5,5,8,8, null, null));
					//7
					levels4.Add(new Level(6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Flying", 2.6f)
					},5,4,8,8, "EnableTrapEnding", null));
					//8
					levels4.Add(new Level(9,new List<MonsterTemplate>{
					},5,5,7,7, null, "CranePuzzle"));
					//9
					levels4.Add(new Level(8,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.6f)
					},5,4,8,8, null, null));
					//10
					levels4.Add(new Level(10,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 3.2f),
						new MonsterTemplate("Flying", 3.2f),
						new MonsterTemplate("Standard", 3.8f)
					},5,4,9,9, "EnableTrapEnding", null));
					//11
					levels4.Add(new Level(20,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.8f)
					},5,5,8,8, "EnableTrapEnding", null));
					//12
					levels4.Add(new Level(7,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Flying", 2.6f)
					},5,5,9,9, null, null));
					//13
					levels4.Add(new Level(8,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.2f)
					},5,5,10,10, null, null));
					//14
					levels4.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.4f)
					},15,15,6,6, null, null));
					//15
					levels4.Add(new Level(9,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f)
					},5,8,10,10, "EnableNoWallsEnding", null));
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

