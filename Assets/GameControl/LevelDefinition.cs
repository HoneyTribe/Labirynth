using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class LevelDefinition
		{
				private static int firstLevelWithDevice = 1;
				private static int firstLevelWithJumpItem = 3;

				private static int firstLevelWithLightMachine = 0;
				private static int firstLevelWithCrane = 4;
				private static int firstLevelWithDrone = 2;
				private static int firstLevelWithStunGun = 5;

				List<Level> levels1 = new List<Level> ();
				List<Level> levels2 = new List<Level> ();
				List<Level> levels3 = new List<Level> ();
				List<Level> levels4 = new List<Level> ();

				public LevelDefinition ()
				{
					// keys, monsters, time of 1st monster appear, time of subsequent mosnters,
					// maze rows, maze columns

				// 1 player levels
					levels1.Add(new Level(1,new List<MonsterTemplate>{},15,15,6,6));

		 	    // 2 player levels
					levels2.Add(new Level(1,new List<MonsterTemplate>{},15,15,6,6));
					levels2.Add(new Level(1,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.4f)
					},5,15,7,7));
					levels2.Add(new Level(2,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},5,6,8,8));
					levels2.Add(new Level(2,new List<MonsterTemplate>{},10,15,6,6));
					levels2.Add(new Level(2,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.0f)
					},5,6,7,7));
					levels2.Add(new Level(3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Flying", 2.4f)
					},5,6,8,8));
					levels2.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.4f),
						new MonsterTemplate("Standard", 3.4f),
						new MonsterTemplate("Flying", 2.0f)
					},5,6,9,9));
					levels2.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.6f)
					},5,6,9,9));
					levels2.Add(new Level(5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.8f),
						new MonsterTemplate("Flying", 2.2f),
						new MonsterTemplate("Standard", 3.8f),
						new MonsterTemplate("Flying", 3.8f)
					},5,10,10,10));
					levels2.Add(new Level(5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 2.4f)
					},5,10,10,10));	
				/*
					levels.Add(new Level(1,new List<MonsterTemplate>{},15,15,6,6));
					levels.Add(new Level(1,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 2.4f)
						},5,15,7,7));
					levels.Add(new Level(2,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 2.6f),
							new MonsterTemplate("Standard", 2.6f)
						},5,6,8,8));
					levels.Add(new Level(2,new List<MonsterTemplate>{},10,15,6,6));
					levels.Add(new Level(2,new List<MonsterTemplate>{
							new MonsterTemplate("Flying", 2.0f)
						},5,6,7,7));
					levels.Add(new Level(3,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.0f),
							new MonsterTemplate("Flying", 2.4f)
						},5,6,8,8));
					levels.Add(new Level(4,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.4f),
							new MonsterTemplate("Standard", 3.4f),
							new MonsterTemplate("Flying", 2.0f)
						},5,6,9,9));
					levels.Add(new Level(4,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f)
						},5,6,9,9));
					levels.Add(new Level(5,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.8f),
							new MonsterTemplate("Flying", 2.2f),
							new MonsterTemplate("Standard", 3.8f),
							new MonsterTemplate("Flying", 3.8f)
						},5,10,10,10));
					levels.Add(new Level(5,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Flying", 2.4f),
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Flying", 2.4f)
						},5,10,10,10));
				*/

					// 3 player levels	

					levels3.Add(new Level(2,new List<MonsterTemplate>{},15,15,6,6));
					levels3.Add(new Level(2,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 2.4f)
						},5,15,7,7));
					levels3.Add(new Level(3,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 2.6f),
							new MonsterTemplate("Standard", 2.6f)
						},5,6,8,8));
					levels3.Add(new Level(3,new List<MonsterTemplate>{},10,15,6,6));
					levels3.Add(new Level(3,new List<MonsterTemplate>{
							new MonsterTemplate("Flying", 2.0f)
						},5,6,7,7));
					levels3.Add(new Level(4,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.0f),
							new MonsterTemplate("Flying", 2.4f)
						},5,6,8,8));
					levels3.Add(new Level(5,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.4f),
							new MonsterTemplate("Standard", 3.4f),
							new MonsterTemplate("Flying", 2.0f)
						},5,6,9,9));
					levels3.Add(new Level(5,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f)
						},5,6,9,9));
					levels3.Add(new Level(6,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.8f),
							new MonsterTemplate("Flying", 2.2f),
							new MonsterTemplate("Standard", 3.8f),
							new MonsterTemplate("Flying", 3.8f)
						},5,10,10,10));
					levels3.Add(new Level(6,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Flying", 2.4f),
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Flying", 2.4f)
						},5,10,10,10));

					// 4 player levels	
					levels4.Add(new Level(3,new List<MonsterTemplate>{},15,15,6,6));
					levels4.Add(new Level(3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.4f)
					},5,15,7,7));
					levels4.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},5,6,8,8));
					levels4.Add(new Level(4,new List<MonsterTemplate>{},10,15,6,6));
					levels4.Add(new Level(4,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.0f)
					},5,6,7,7));
					levels4.Add(new Level(5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Flying", 2.4f)
					},5,6,8,8));
					levels4.Add(new Level(6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.4f),
						new MonsterTemplate("Standard", 3.4f),
						new MonsterTemplate("Flying", 2.0f)
					},5,6,9,9));
					levels4.Add(new Level(6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.6f)
					},5,6,9,9));
					levels4.Add(new Level(7,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.8f),
						new MonsterTemplate("Flying", 2.2f),
						new MonsterTemplate("Standard", 3.8f),
						new MonsterTemplate("Flying", 3.8f)
					},5,10,10,10));
					levels4.Add(new Level(7,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 2.4f)
					},5,10,10,10));
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
