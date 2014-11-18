using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class LevelDefinition
		{
				private int firstLevelWithLight = 0;

				List<Level> levels1 = new List<Level> ();
				List<Level> levels2 = new List<Level> ();
				List<Level> levels3 = new List<Level> ();
				List<Level> levels4 = new List<Level> ();

				public LevelDefinition ()
				{
					// machines, keys, monsters, time of 1st monster appear, time of subsequent monsters,
					// maze rows, maze columns, ending, puzzle
					// "EnableNoVerticalWallsEnding"
					// 1 player levels

					//1
					levels1.Add(new Level(new MachineCreator(false, false, false, false, false, false),
						15,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 20.4f)
					},1,15,7,7, null, null));

		 	  		// 2 player levels

					//1 light
					levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			        	2, new List<MonsterTemplate>{},0,0,6,6, null, null));

					//2 decoy
					levels2.Add(new Level(new MachineCreator(false, false, false, false, false, false),
						3,new List<MonsterTemplate>{},0,0,7,7, null, "DecoyPuzzle"));

					//3 monster + block
					levels2.Add(new Level(new MachineCreator(false, false, false, false, false, false),
					    5,new List<MonsterTemplate>{},0,0,7,7, null, "First"));

					//4 monster door
					levels2.Add(new Level(new MachineCreator(false, false, false, false, false, false),
						2,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.4f)
					},4,4,7,7, null, null));

					//5 ghost
					levels2.Add(new Level(new MachineCreator(false, false, false, false, false, false),
						3,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Flying", 2.2f)
					},4,4,7,7, null, null));

					//6 crane
					levels2.Add(new Level(new MachineCreator(false, false, true, false, false, false),
						14,new List<MonsterTemplate>{
					},0,0,7,7, null, "SimpleCranePuzzle"));

					//7
					levels2.Add(new Level(new MachineCreator(false, false, true, false, false, false),
						3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 2.6f)
					},4,4,8,8, "EnableNoWallsEnding", "DecoyPuzzle"));

					//8 no walls
					levels2.Add(new Level(new MachineCreator(false, false, true, false, false, false),
					    49,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 3.6f),
						new MonsterTemplate("Standard", 3.2f)
						},4,4,7,7, "EnableTrapEnding", "NoWalls"));

					//9 teleport
					levels2.Add(new Level(new MachineCreator(false, false, false, false, true, false),
						9,new List<MonsterTemplate>{
					},5,5,7,7, null, "CranePuzzle"));

					//10
					levels2.Add(new Level(new MachineCreator(false, false, false, false, true, false),
						5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.8f),
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.4f)
					},5,5,8,8, "EnableTrapEnding", null));

			//11 jump box
			levels2.Add(new Level(new MachineCreator(false, true, false, false, false, false),
				8,new List<MonsterTemplate>{

			},15,15,8,8, null, "FirstJumpBox"));

					// 12
					levels2.Add(new Level(new MachineCreator(false, true, false, false, false, false),
					    5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.8f),
						new MonsterTemplate("Flying", 3.2f),
						new MonsterTemplate("Standard", 3.5f),
						new MonsterTemplate("Flying", 2.8f)
					},5,8,8,8, null, null));

					//13 All machines
					levels2.Add(new Level(new MachineCreator(false, true, true, false, true, false),
					    6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.8f),
						new MonsterTemplate("Flying", 2.8f),
						new MonsterTemplate("Standard", 3.4f)
					},5,8,9,9, "EnableTrapEnding", null));

					//14
					levels2.Add(new Level(new MachineCreator(false, true, true, false, true, false),
			            52,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.2f)
					},30,30,8,8, "EnableNoVerticalWallsEnding", "NoWalls2"));


			//_______________________

					
					//15
					levels2.Add(new Level(new MachineCreator(false, true, true, false, true, false),
					    10,new List<MonsterTemplate>{
					new MonsterTemplate("Standard", 3.0f),
					new MonsterTemplate("Standard", 3.2f)
					},20,20,8,8, null, "Crane2"));

			//16
			levels2.Add(new Level(new MachineCreator(false, false, false, true, true, true),
						10,new List<MonsterTemplate>{
					},5,5,9,9, null, "DronePuzzle"));

					//16
					levels2.Add(new Level(new MachineCreator(false, false, true, true, true, true),
						15,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.2f)
					},5,5,10,10, null, null));
					


					// 3 player levels	

					//1
					levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
						3,new List<MonsterTemplate>{},15,15,6,6, null, null));
					//2
					levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
						5,new List<MonsterTemplate>{},0,0,7,7, null, "First"));
					//3
					levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
						3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},5,10,7,7, null, null));
					//4
					levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
						4,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Flying", 2.4f)
					},5,10,8,8, "EnableNoWallsEnding", null));
					//5
					levels3.Add(new Level(new MachineCreator(false, false, true, false, false, false),
						5,new List<MonsterTemplate>{
					},5,10,7,7, null, "SimpleCranePuzzle"));
					//6
					levels3.Add(new Level(new MachineCreator(false, false, true, false, false, false),
						4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},5,5,8,8, null, null));
					//7
					levels3.Add(new Level(new MachineCreator(false, false, true, false, false, false),
						6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Flying", 2.6f)
					},5,5,8,8, "EnableTrapEnding", null));
					//8
					levels3.Add(new Level(new MachineCreator(false, false, false, false, true, false),
						9,new List<MonsterTemplate>{
					},5,5,7,7, null, "CranePuzzle"));
					//9
					levels3.Add(new Level(new MachineCreator(false, false, true, false, true, false),
						8,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.4f),
						new MonsterTemplate("Standard", 3.4f),
						new MonsterTemplate("Standard", 3.4f)
					},5,5,8,8, null, null));
					//10
					levels3.Add(new Level(new MachineCreator(false, false, true, false, true, false),
						10,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 3.2f),
						new MonsterTemplate("Flying", 3.2f),
						new MonsterTemplate("Standard", 3.6f)
					},5,5,9,9, "EnableTrapEnding", null));
					//11
					levels3.Add(new Level(new MachineCreator(false, false, true, true, false, false),
						15,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.8f)
					},5,5,8,8, "EnableTrapEnding", null));
					//12
					levels3.Add(new Level(new MachineCreator(false, false, false, false, true, true),
						10,new List<MonsterTemplate>{
					},5,5,9,9, null, "DronePuzzle"));
					//13
					levels3.Add(new Level(new MachineCreator(false, false, true, true, true, true),
						8,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.2f)
					},5,5,10,10, null, null));
					//14
					levels3.Add(new Level(new MachineCreator(false, true, false, false, false, false),
						6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.0f)
					},5,8,7,7, null, null));
					//15
					levels3.Add(new Level(new MachineCreator(false, true, true, true, true, true),
						8,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f)
					},5,8,10,10, "EnableNoWallsEnding", null));

					// 4 player levels

					//1
					levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
						3,new List<MonsterTemplate>{},15,15,6,6, null, null));
					//2
					levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
						5,new List<MonsterTemplate>{},0,0,7,7, null, "First"));
					//3
					levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
						3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},5,10,7,7, null, null));
					//4
					levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
						4,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.4f),
						new MonsterTemplate("Flying", 2.4f)
					},5,10,8,8, "EnableNoWallsEnding", null));
					//5
					levels4.Add(new Level(new MachineCreator(false, false, true, false, false, false),
						5,new List<MonsterTemplate>{
					},5,10,7,7, null, "SimpleCranePuzzle"));
					//6
					levels4.Add(new Level(new MachineCreator(false, false, true, false, false, false),
						4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.6f),
						new MonsterTemplate("Standard", 2.6f)
					},5,5,8,8, null, null));
					//7
					levels4.Add(new Level(new MachineCreator(false, false, true, false, false, false),
						6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Flying", 2.6f)
					},5,4,8,8, "EnableTrapEnding", null));
					//8
					levels4.Add(new Level(new MachineCreator(false, false, false, false, true, false),
						9,new List<MonsterTemplate>{
					},5,5,7,7, null, "CranePuzzle"));
					//9
					levels4.Add(new Level(new MachineCreator(false, false, true, false, true, false),
						8,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.6f),
						new MonsterTemplate("Standard", 3.6f)
					},5,4,8,8, null, null));
					//10
					levels4.Add(new Level(new MachineCreator(false, false, true, false, true, false),
						10,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 3.2f),
						new MonsterTemplate("Flying", 3.2f),
						new MonsterTemplate("Standard", 3.8f)
					},5,4,9,9, "EnableTrapEnding", null));
					//11
					levels4.Add(new Level(new MachineCreator(false, false, true, true, false, false),
						20,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.8f),
						new MonsterTemplate("Standard", 2.8f)
					},5,5,8,8, "EnableTrapEnding", null));
					//12
					levels4.Add(new Level(new MachineCreator(false, false, false, false, true, true),
						7,new List<MonsterTemplate>{
					},5,5,9,9, null, "DronePuzzle"));
					//13
					levels4.Add(new Level(new MachineCreator(false, false, true, true, true, true),
						8,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.6f),
						new MonsterTemplate("Standard", 3.2f),
						new MonsterTemplate("Flying", 2.2f)
					},5,5,10,10, null, null));
					//14
					levels4.Add(new Level(new MachineCreator(false, true, false, false, false, false),
						7,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.0f)
					},5,8,7,7, null, null));
					//15
					levels4.Add(new Level(new MachineCreator(false, true, true, true, true, true),
						9,new List<MonsterTemplate>{
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

				public int getFirstLevelWithLight()
				{
					return firstLevelWithLight;
				}
		}
}

