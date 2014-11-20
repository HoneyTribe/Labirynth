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
					levels2.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			        	2, new List<MonsterTemplate>{},0,0,6,6, null, null));

					//2 decoy
					levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
						3,new List<MonsterTemplate>{},0,0,7,7, null, "DecoyPuzzle"));

					//3 monster + block
					levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
					    5,new List<MonsterTemplate>{},0,0,7,7, null, "First"));

					//4 monster door
					levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
						3,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 2.5f)
					},4,4,7,7, null, null));

					//5 ghost
					levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
						3,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Flying", 2.5f)
					},4,4,7,7, null, null));

					//6 crane
					levels2.Add(new Level(new MachineCreator(true, false, true, false, false, false),
						14,new List<MonsterTemplate>{
					},0,0,7,7, null, "SimpleCranePuzzle"));

					//7
					levels2.Add(new Level(new MachineCreator(true, false, true, false, false, false),
						12,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f)
					},5,5,8,8, "EnableNoWallsEnding", "Decoy2"));

					//8 no walls
					levels2.Add(new Level(new MachineCreator(true, false, true, false, false, false),
					    49,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 5.0f),
						new MonsterTemplate("Flying", 4.5f),
						new MonsterTemplate("Standard", 4.0f)
						},2,5,7,7, "EnableTrapEnding", "NoWalls"));

					//9 teleport drone
					levels2.Add(new Level(new MachineCreator(true, false, false, false, true, false),
						9,new List<MonsterTemplate>{
					},5,5,7,7, null, "CranePuzzle"));

					//10
					levels2.Add(new Level(new MachineCreator(true, false, false, false, true, false),
						5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Standard", 3.5f),
						new MonsterTemplate("Flying", 3.0f)
					},5,5,8,8, "EnableTrapEnding", null));

					//11 jump box
					levels2.Add(new Level(new MachineCreator(true, true, false, false, false, false),
						8,new List<MonsterTemplate>{

					},15,15,8,8, null, "FirstJumpBox"));

					// 12
					levels2.Add(new Level(new MachineCreator(true, true, false, false, false, false),
					    6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 3.5f),
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Flying", 2.5f)
					},5,8,8,8, null, null));

					//13 All machines
					levels2.Add(new Level(new MachineCreator(true, true, true, false, true, false),
					    7,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.5f),
						new MonsterTemplate("Flying", 4.0f),
						new MonsterTemplate("Standard", 3.5f),
						new MonsterTemplate("Flying", 3.0f)
					},5,8,9,9, "EnableTrapEnding", null));

					//14 
					levels2.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			            52,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.2f)
					},20,20,8,8, "EnableNoVerticalWallsEnding", "NoWalls2"));
					
					//15
					levels2.Add(new Level(new MachineCreator(true, true, true, false, true, false),
					    19,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 5.5f),
						new MonsterTemplate("Standard", 5.0f),
						new MonsterTemplate("Standard", 4.5f),
						new MonsterTemplate("Standard", 4.0f)
					},4,5,8,8, null, "Crane2"));

					//16 lazer
					levels2.Add(new Level(new MachineCreator(true, false, false, true, false, false),
						32,new List<MonsterTemplate>{
					},5,5,9,9, null, "Lazer"));

					//17 lazer 2
					levels2.Add(new Level(new MachineCreator(true, false, false, true, false, false),
					    20,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.5f),
						new MonsterTemplate("Standard", 4.0f)
					},9,9,8,8, null, "Lazer2"));	

					//18 drone bomb
					levels2.Add(new Level(new MachineCreator(false, false, false, false, false, true),
						17,new List<MonsterTemplate>{
					new MonsterTemplate("Standard", 3.0f),
					new MonsterTemplate("Standard", 3.0f)
					},12,12,8,8, "EnableNoVerticalWallsEnding", "DroneBomb"));

					//19
					levels2.Add(new Level(new MachineCreator(false, false, false, false, false, true),
						8,new List<MonsterTemplate>{
					new MonsterTemplate("Standard", 5.0f),
					new MonsterTemplate("Standard", 4.5f),
					new MonsterTemplate("Standard", 4.0f)
					},7,7,8,8, null, null));

					//20 everything
					levels2.Add(new Level(new MachineCreator(true, true, true, true, true, true),
						20,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 4.5f),
						new MonsterTemplate("Standard", 5.0f),
						new MonsterTemplate("Flying", 3.5f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 3.0f)
					},5,8,10,10, "EnableTrapEnding", null));
					


					// 3 player levels	

					//1 light
					levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
					                      3, new List<MonsterTemplate>{},0,0,6,6, null, null));
					
					//2 decoy
					levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
					                      3,new List<MonsterTemplate>{},0,0,7,7, null, "DecoyPuzzle"));
					
					//3 monster + block
					levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
					                      5,new List<MonsterTemplate>{},0,0,7,7, null, "First"));
					
					//4 monster door
					levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
					                      4,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 2.5f),
						new MonsterTemplate("Standard", 2.0f)
					},4,4,7,7, null, null));
					
					//5 ghost
					levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
					                      4,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Flying", 2.5f),
						new MonsterTemplate("Flying", 2.0f)
					},4,4,7,7, null, null));
					
					//6 crane
					levels3.Add(new Level(new MachineCreator(false, false, true, false, false, false),
					                      14,new List<MonsterTemplate>{
					},0,0,7,7, null, "SimpleCranePuzzle"));
					
					//7
					levels3.Add(new Level(new MachineCreator(false, false, true, false, false, false),
					    12,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.5f),
						new MonsterTemplate("Standard", 3.0f)
					},5,5,8,8, "EnableNoWallsEnding", "Decoy2"));
					
					//8 no walls
					levels3.Add(new Level(new MachineCreator(false, false, true, false, false, false),
					                      49,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 5.0f),
						new MonsterTemplate("Flying", 4.5f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 3.5f)
					},2,4,7,7, "EnableTrapEnding", "NoWalls"));
					
					//9 teleport drone
					levels3.Add(new Level(new MachineCreator(false, false, false, false, true, false),
					                      9,new List<MonsterTemplate>{
					},5,5,7,7, null, "CranePuzzle"));
					
					//10
					levels3.Add(new Level(new MachineCreator(false, false, false, false, true, false),
					                      6,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Standard", 3.5f),
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Flying", 2.5f)
					},5,5,8,8, "EnableTrapEnding", null));
					
					//11 jump box
					levels3.Add(new Level(new MachineCreator(false, true, false, false, false, false),
					                      8,new List<MonsterTemplate>{
						
					},15,15,8,8, null, "FirstJumpBox"));
					
					// 12
					levels3.Add(new Level(new MachineCreator(false, true, false, false, false, false),
					                      7,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 3.5f),
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Flying", 2.5f),
						new MonsterTemplate("Standard", 2.0f)
					},5,8,8,8, null, null));
					
					//13 All machines
					levels3.Add(new Level(new MachineCreator(false, true, true, false, true, false),
					                      8,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.5f),
						new MonsterTemplate("Flying", 4.0f),
						new MonsterTemplate("Standard", 3.5f),
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Standard", 2.5f)
					},5,8,9,9, "EnableTrapEnding", null));
					
					//14 
					levels3.Add(new Level(new MachineCreator(false, true, true, false, true, false),
					                      52,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.2f)
					},20,20,8,8, "EnableNoVerticalWallsEnding", "NoWalls2"));
					
					//15
					levels3.Add(new Level(new MachineCreator(false, true, true, false, true, false),
					                      19,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 5.5f),
						new MonsterTemplate("Standard", 5.0f),
						new MonsterTemplate("Standard", 4.5f),
						new MonsterTemplate("Standard", 4.0f)
					},4,5,8,8, null, "Crane2"));
					
					//16 lazer
					levels3.Add(new Level(new MachineCreator(false, false, false, true, false, false),
					                      32,new List<MonsterTemplate>{
					},5,5,9,9, null, "Lazer"));
					
					//17 lazer 2
					levels3.Add(new Level(new MachineCreator(false, false, false, true, false, false),
					                      20,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.5f),
						new MonsterTemplate("Standard", 4.0f)
					},9,9,8,8, null, "Lazer2"));	
					
					//18 drone bomb
					levels3.Add(new Level(new MachineCreator(true, false, false, false, false, true),
					                      17,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.0f)
					},12,12,8,8, "EnableNoVerticalWallsEnding", "DroneBomb"));
					
					//19
					levels3.Add(new Level(new MachineCreator(true, false, false, false, false, true),
					                      9,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 5.0f),
						new MonsterTemplate("Standard", 4.5f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Standard", 3.5f)
					},7,7,8,8, null, null));
					
					//20 everything
					levels3.Add(new Level(new MachineCreator(false, true, true, true, true, true),
					                      22,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 4.5f),
						new MonsterTemplate("Standard", 5.0f),
						new MonsterTemplate("Flying", 3.5f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Standard", 2.5f),
					},5,8,10,10, "EnableTrapEnding", null));

					// 4 player levels

					//1 light
					levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
					                      4, new List<MonsterTemplate>{},0,0,6,6, null, null));
					
					//2 decoy
					levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
					                      3,new List<MonsterTemplate>{},0,0,7,7, null, "DecoyPuzzle"));
					
					//3 monster + block
					levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
					                      5,new List<MonsterTemplate>{},0,0,7,7, null, "First"));
					
					//4 monster door
					levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
					                      5,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 2.5f),
						new MonsterTemplate("Standard", 2.3f),
						new MonsterTemplate("Standard", 2.0f)
					},4,4,7,7, null, null));
					
					//5 ghost
					levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
					                      5,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Flying", 2.5f),
						new MonsterTemplate("Flying", 2.0f)
					},4,4,7,7, null, null));
					
					//6 crane
					levels4.Add(new Level(new MachineCreator(false, false, true, false, false, false),
					                      14,new List<MonsterTemplate>{
					},0,0,7,7, null, "SimpleCranePuzzle"));
					
					//7
					levels4.Add(new Level(new MachineCreator(false, false, true, false, false, false),
					                      12,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.5f),
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 2.5f)
					},5,5,8,8, "EnableNoWallsEnding", "Decoy2"));
					
					//8 no walls
					levels4.Add(new Level(new MachineCreator(false, false, true, false, false, false),
					                      49,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 5.0f),
						new MonsterTemplate("Flying", 4.5f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 3.5f),
						new MonsterTemplate("Flying", 3.0f)
					},2,4,7,7, "EnableTrapEnding", "NoWalls"));
					
					//9 teleport drone
					levels4.Add(new Level(new MachineCreator(false, false, false, false, true, false),
					                      9,new List<MonsterTemplate>{
					},5,5,7,7, null, "CranePuzzle"));
					
					//10
					levels4.Add(new Level(new MachineCreator(false, false, false, false, true, false),
					                      7,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Standard", 3.5f),
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Flying", 2.5f),
						new MonsterTemplate("Standard", 3.8f)
					},5,5,8,8, "EnableTrapEnding", null));
					
					//11 jump box
					levels4.Add(new Level(new MachineCreator(false, true, false, false, false, false),
					                      8,new List<MonsterTemplate>{
						
					},15,15,8,8, null, "FirstJumpBox"));
					
					// 12
					levels4.Add(new Level(new MachineCreator(false, true, false, false, false, false),
					                      10,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 3.5f),
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Flying", 2.5f),
						new MonsterTemplate("Standard", 2.0f)
					},5,8,8,8, null, null));
					
					//13 All machines
					levels4.Add(new Level(new MachineCreator(false, true, true, false, true, false),
					                      12,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.5f),
						new MonsterTemplate("Flying", 4.0f),
						new MonsterTemplate("Standard", 3.5f),
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Standard", 2.5f)
					},5,8,9,9, "EnableTrapEnding", null));
					
					//14 
					levels4.Add(new Level(new MachineCreator(false, true, true, false, true, false),
					                      52,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.2f)
					},20,20,8,8, "EnableNoVerticalWallsEnding", "NoWalls2"));
					
					//15
					levels4.Add(new Level(new MachineCreator(false, true, true, false, true, false),
					                      19,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 5.5f),
						new MonsterTemplate("Standard", 5.0f),
						new MonsterTemplate("Standard", 4.5f),
						new MonsterTemplate("Standard", 4.0f)
					},4,5,8,8, null, "Crane2"));
					
					//16 lazer
					levels4.Add(new Level(new MachineCreator(false, false, false, true, false, false),
					                      32,new List<MonsterTemplate>{
					},5,5,9,9, null, "Lazer"));
					
					//17 lazer 2
					levels4.Add(new Level(new MachineCreator(false, false, false, true, false, false),
					                      20,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 4.5f),
						new MonsterTemplate("Standard", 4.0f)
					},9,9,8,8, null, "Lazer2"));	
					
					//18 drone bomb
					levels4.Add(new Level(new MachineCreator(true, false, false, false, false, true),
					                      17,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 3.0f),
						new MonsterTemplate("Standard", 3.0f)
					},12,12,8,8, "EnableNoVerticalWallsEnding", "DroneBomb"));
					
					//19
					levels4.Add(new Level(new MachineCreator(true, false, false, false, false, true),
					                      9,new List<MonsterTemplate>{
						new MonsterTemplate("Standard", 5.0f),
						new MonsterTemplate("Standard", 4.5f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Standard", 3.5f)
					},7,7,8,8, null, null));
					
					//20 everything
					levels4.Add(new Level(new MachineCreator(false, true, true, true, true, true),
					                      22,new List<MonsterTemplate>{
						new MonsterTemplate("Flying", 4.5f),
						new MonsterTemplate("Standard", 5.0f),
						new MonsterTemplate("Flying", 3.5f),
						new MonsterTemplate("Standard", 4.0f),
						new MonsterTemplate("Flying", 3.0f),
						new MonsterTemplate("Standard", 2.5f),
					},5,8,10,10, "EnableTrapEnding", null));

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

