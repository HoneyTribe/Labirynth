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
				new MonsterTemplate("Standard", 20f)
			},1,15,7,7, null, null));
			
			// 2 player levels
			
			//1 light
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			    2, new List<MonsterTemplate>{},0,0,6,6, null, null));

			//2 trigger tutorial
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			     10,new List<MonsterTemplate>{},0,0,7,7, null, "TriggerTut"));
			
			//3 decoy tutorial
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			     52,new List<MonsterTemplate>{},0,0,10,10, null, "DecoyTut"));

			//4 decoy + can die
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    3,new List<MonsterTemplate>{},0,0,8,8, null, "DecoyPuzzle"));
			
			//5 mummy + block
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			     5,new List<MonsterTemplate>{},0,0,7,7, null, "First"));
			
			//6 1st monster door
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			      3,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 4.5f)
			},4,4,7,7, null, null));
			
			//7 ghost
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    3,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Flying", 3.0f)
			},4,4,7,7, null, null));
			
			//8 crane
			levels2.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    15,new List<MonsterTemplate>{
			},0,0,7,7, null, "SimpleCranePuzzle"));
			
			//9 crane, mummies in boxes
			levels2.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    12,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Standard", 4.5f)
			},5,15,8,8, "EnableNoWallsEnding", "Decoy2"));
			
			//10 crane, "look at all that energy"
			levels2.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    61,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.5f)
			},3,5,8,8, "EnableTrapEnding", "NoWalls"));
			
			//11 teleport drone
			levels2.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			                      9,new List<MonsterTemplate>{
			},5,5,7,7, null, "CranePuzzle"));
			
			//12 normal maze + drone
			levels2.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			                      6,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f)
			},5,5,8,8, "EnableTrapEnding", null));

			//13 drone + new maze triggers
			levels2.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f),
				new MonsterTemplate("Standard", 8.0f)
			},10,10,8,8, null, "NewMazes"));

			//14 two triggers
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			15,new List<MonsterTemplate>{},0,0,8,8, null, "TwoTriggers"));
			
			//15 jump box, can't die
			levels2.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			    11,new List<MonsterTemplate>{
			},15,15,8,8, null, "FirstJumpBox"));
			
			//16 normal maze + jump box + new maze ending
			levels2.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			    6,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 3.5f),
				new MonsterTemplate("Flying", 3.0f)
			},5,8,8,8, "EnableNewMazeEnding", null));

			// 17 jump box, hard puzzle
			levels2.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			    19,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.5f)
			},20,15,8,8, null, "Jump2"));
			
			//18 All machines, normal maze
			levels2.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    7,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.7f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f)
			},5,8,9,9, "EnableTrapEnding", null));
			
			//19 all machines, mummies in long boxes
			levels2.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    52,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f)
			},15,15,8,8, "EnableNoVerticalWallsEnding", "NoWalls2"));
			
			//20 all machines, two triggers
			levels2.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    35,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f)
			},8,8,9,9, null, "Boxes"));
			
			//21 drone bomb, easy puzzle
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			 	17,new List<MonsterTemplate>{
			},12,12,8,8, "EnableNoVerticalWallsEnding", "DroneBomb"));
			
			//22 bomb 2, pac man
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    38,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Standard", 8.0f),
				new MonsterTemplate("Standard", 7.5f)
			},1,3,7,7, null, "DroneBomb2"));

			//23 bomb 3, pac man
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 10.5f),
				new MonsterTemplate("Standard", 9.5f),
				new MonsterTemplate("Standard", 10.0f)
			},4,3,7,7, null, "DroneBomb3"));

			//24 lazer
			levels2.Add(new Level(new MachineCreator(false, false, false, true, false, false),
				31,new List<MonsterTemplate>{
			},5,5,9,9, null, "Lazer"));
			
			//25 lazer 2
			levels2.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			   20,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f)
			},9,9,8,8, "EnableNewMazeEnding", "Lazer2"));
			
			//26 lazer 3
			levels2.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			    40,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 4.5f)
			},12,12,8,8, "EnableNoVerticalWallsEnding", "Lazer3"));

			//27 Nothing
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			     26,new List<MonsterTemplate>{
			},1,1,8,8, null, "Run"));

			//28 everything, snake
			levels2.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    23,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f)
			},8,8,8,8, "EnableNoVerticalWallsEnding", "Snake"));

			//29 everything, bff, 2 triggers
			levels2.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    28,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 6.0f),
				new MonsterTemplate("Flying", 5.0f)
			},8,8,9,9, null, "BFF"));
			
			//30 everything, normal maze + new maze ending
			levels2.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    40,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.2f)
			},5,8,10,10, "EnableNewMazeEnding", null));

			
			
			// 3 player levels	
			
			//1 light
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			                      3, new List<MonsterTemplate>{},0,0,6,6, null, null));

			//2 trigger tutorial
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			                      10,new List<MonsterTemplate>{},0,0,7,7, null, "TriggerTut"));
			
			//3 decoy tutorial
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      52,new List<MonsterTemplate>{},0,0,10,10, null, "DecoyTut"));
			
			//4 decoy + can die
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      3,new List<MonsterTemplate>{},0,0,8,8, null, "DecoyPuzzle"));
			
			//5 monster + block
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      5,new List<MonsterTemplate>{},0,0,7,7, null, "First"));
			
			//6 monster door
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      4,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 5.5f),
				new MonsterTemplate("Standard", 4.5f)
			},4,4,7,7, null, null));
			
			//7 ghost
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      4,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Flying", 3.0f),
				new MonsterTemplate("Flying", 4.0f)
			},4,4,7,7, null, null));
			
			//8 crane
			levels3.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			                      15,new List<MonsterTemplate>{
			},0,0,7,7, null, "SimpleCranePuzzle"));
			
			//9 crane, mummies in box
			levels3.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			                      12,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Standard", 5.0f)
			},5,8,8,8, "EnableNoWallsEnding", "Decoy2"));
			
			//10 no walls, "look at all that energy"
			levels3.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    61,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.0f)
			},2,4,8,8, "EnableTrapEnding", "NoWalls"));
			
			//11 teleport drone, puzzle
			levels3.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			                      9,new List<MonsterTemplate>{
			},5,5,7,7, null, "CranePuzzle"));
			
			//12 drone + normal maze
			levels3.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			                      7,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Flying", 3.0f)
			},5,5,8,8, "EnableTrapEnding", null));

			//13 drone + new maze triggers
			levels3.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			                      34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f),
				new MonsterTemplate("Standard", 8.0f),
				new MonsterTemplate("Standard", 6.0f)
			},10,8,8,8, null, "NewMazes"));

			//14 two triggers
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			 15,new List<MonsterTemplate>{},0,0,8,8, null, "TwoTriggers"));
			
			//15 jump box
			levels3.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			11,new List<MonsterTemplate>{	
			},15,15,8,8, null, "FirstJumpBox"));
			
			// 16 jump box + normal maze + new ending
			levels3.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			    7,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 3.5f),
				new MonsterTemplate("Flying", 3.0f),
				new MonsterTemplate("Standard", 2.8f)
			},4,7,8,8, "EnableNewMazeEnding", null));

			// 17 jump box, hard puzzle
			levels3.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			                      19,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f)
			},16,10,8,8, null, "Jump2"));

			
			//18 All machines
			levels3.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			                      8,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.8f),
				new MonsterTemplate("Standard", 3.0f)
			},5,8,9,9, "EnableTrapEnding", null));
			
			//19 All machines, mummies in long boxes
			levels3.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			                      52,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.0f)
			},13,13,8,8, "EnableNoVerticalWallsEnding", "NoWalls2"));
			
			//20 all machines
			levels3.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    35,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 4.5f)
			},8,8,9,9, null, "Boxes"));
			
			//21 drone bomb
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			17,new List<MonsterTemplate>{
			},12,12,8,8, "EnableNoVerticalWallsEnding", "DroneBomb"));
			
			//22 bomb 2 - chase
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    38,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Standard", 8.0f),
				new MonsterTemplate("Flying", 6.0f),
				new MonsterTemplate("Standard", 7.0f)
			},1,3,7,7, null, "DroneBomb2"));

			//23 bomb 3 - chase
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 10.5f),
				new MonsterTemplate("Standard", 9.5f),
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Standard", 7.5f)
			},3,3,7,7, null, "DroneBomb3"));

			//24 lazer
			levels3.Add(new Level(new MachineCreator(false, false, false, true, false, false),
			  	31,new List<MonsterTemplate>{
			},5,5,9,9, null, "Lazer"));
			
			//25 lazer 2
			levels3.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			    20,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.5f)
			},9,9,8,8, "EnableNewMazeEnding", "Lazer2"));
			
			//26 lazer 3
			levels3.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			     40,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Standard", 5.0f)
			},10,10,8,8, "EnableNoVerticalWallsEnding", "Lazer3"));

			//27 Nothing
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			    26,new List<MonsterTemplate>{
			},1,1,8,8, null, "Run"));

			//27 everything, snake
			levels3.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    23,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f),
				new MonsterTemplate("Standard", 7.5f)
			},8,8,8,8, "EnableNoVerticalWallsEnding", "Snake"));

			//29 everything, bff, 2 triggers
			levels3.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    28,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 6.0f),
				new MonsterTemplate("Flying", 5.0f),
				new MonsterTemplate("Flying", 6.0f)
			},8,7,9,9, null, "BFF"));
			
			//30 everything
			levels3.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    40,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.2f),
				new MonsterTemplate("Standard", 3.0f)
			},5,8,10,10, "EnableNewMazeEnding", null));
			
			// 4 player levels
			
			//1 light
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			                      4, new List<MonsterTemplate>{},0,0,6,6, null, null));

			//2 trigger tutorial
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			                      10,new List<MonsterTemplate>{},0,0,7,7, null, "TriggerTut"));
			
			//3 decoy tutorial
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      52,new List<MonsterTemplate>{},0,0,10,10, null, "DecoyTut"));
			
			//4 decoy + can die
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      3,new List<MonsterTemplate>{},0,0,8,8, null, "DecoyPuzzle"));
			
			//5 monster + block
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      5,new List<MonsterTemplate>{},0,0,7,7, null, "First"));
			
			//6 monster door
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      5,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 5.5f),
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 6.0f)
			},4,4,7,7, null, null));
			
			//7 ghost
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      5,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Flying", 3.0f),
				new MonsterTemplate("Flying", 4.0f)
			},4,4,7,7, null, null));
			
			//8 crane
			levels4.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			                      15,new List<MonsterTemplate>{
			},0,0,7,7, null, "SimpleCranePuzzle"));
			
			//9 crane, mummies in box
			levels4.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			                      12,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 3.5f)
			},5,7,8,8, "EnableNoWallsEnding", "Decoy2"));
			
			//10 no walls "look at all that energy"
			levels4.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    61,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 3.0f)
			},2,4,8,8, "EnableTrapEnding", "NoWalls"));
			
			//11 teleport drone
			levels4.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			                      9,new List<MonsterTemplate>{
			},5,5,7,7, null, "CranePuzzle"));
			
			//12 drone + normal maze
			levels4.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			                      8,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Flying", 3.0f),
				new MonsterTemplate("Standard", 5.0f)
			},5,5,8,8, "EnableTrapEnding", null));

			//13 drone + new maze triggers
			levels4.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			     34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f),
				new MonsterTemplate("Standard", 8.0f),
				new MonsterTemplate("Standard", 6.0f)
			},10,6,8,8, null, "NewMazes"));

			//14 two triggers
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			15,new List<MonsterTemplate>{},0,0,8,8, null, "TwoTriggers"));
			
			//15 jump box
			levels4.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			11,new List<MonsterTemplate>{
			},15,15,8,8, null, "FirstJumpBox"));

			// 16 jump box + normal maze + new ending
			levels4.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			    8,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 3.5f),
				new MonsterTemplate("Flying", 3.0f),
				new MonsterTemplate("Standard", 2.8f)
			},4,5,8,8, "EnableNewMazeEnding", null));

			// 17 jump box hard puzzle
			levels4.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			                      19,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 3.8f),
				new MonsterTemplate("Standard", 3.5f)
			},15,8,8,8, null, "Jump2"));
			
			//18 All machines
			levels4.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			                      12,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 3.0f)
			},5,8,9,9, "EnableTrapEnding", null));
			
			//19 All machines, mummmies in long boxes
			levels4.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			                      52,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Standard", 4.2f)
			},10,10,8,8, "EnableNoVerticalWallsEnding", "NoWalls2"));
			
			//20 all machines
			levels4.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    35,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Flying", 5.0f)
			},8,6,9,9, null, "Boxes"));
			
			//21 drone bomb, easy puzzle
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    17,new List<MonsterTemplate>{
			},12,12,8,8, "EnableNoVerticalWallsEnding", "DroneBomb"));
			
			//22 bomb 2 - chase
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    38,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Flying", 7.0f),
				new MonsterTemplate("Standard", 8.0f),
				new MonsterTemplate("Standard", 7.5f)
			},1,3,7,7, null, "DroneBomb2"));

			//23 bomb 3 - chase
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 10.5f),
				new MonsterTemplate("Standard", 9.5f),
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Standard", 7.5f)
			},3,2,7,7, null, "DroneBomb3"));

			//24 lazer
			levels4.Add(new Level(new MachineCreator(false, false, false, true, false, false),
			    31,new List<MonsterTemplate>{
			},5,5,9,9, null, "Lazer"));
			
			//25 lazer 2
			levels4.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			    20,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 3.5f)
			},9,9,8,8, "EnableNewMazeEnding", "Lazer2"));
			
			//26 lazer 3
			levels4.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			    40,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Standard", 5.0f)
			},8,8,8,8, "EnableNoVerticalWallsEnding", "Lazer3"));

			//27 Nothing
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			    26,new List<MonsterTemplate>{
			},1,1,8,8, null, "Run"));

			//28 everything
			levels4.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    23,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f),
				new MonsterTemplate("Standard", 7.5f),
				new MonsterTemplate("Standard", 8.0f)
			},8,8,8,8, "EnableNoVerticalWallsEnding", "Snake"));

			//29 everything, bff, 2 triggers
			levels4.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    28,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 6.0f),
				new MonsterTemplate("Flying", 5.0f),
				new MonsterTemplate("Flying", 6.0f),
				new MonsterTemplate("Standard", 8.0f)
				},8,6,9,9, null, "BFF"));
			
			//30 everything
			levels4.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    22,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.2f),
				new MonsterTemplate("Standard", 3.0f)
			},5,8,10,10, "EnableNewMazeEnding", null));
			
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

