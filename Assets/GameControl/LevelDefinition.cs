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

			// *********1 player levels **********
			
			//1 light
			levels1.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			                      2, new List<MonsterTemplate>{},0,0,6,6, null, null));
			
			//2 switch tut
			levels1.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			                      10,new List<MonsterTemplate>{},0,0,7,7, null, "TriggerTut"));
			
			//3 zap tutorial
			levels1.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      35,new List<MonsterTemplate>{},0,0,9,9, null, "ZapWithSwitch"));
			
			//4 decoy tut with switches
			levels1.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      8,new List<MonsterTemplate>{},0,0,9,9, null, "FourSwitches"));
			
			//5 decoy + can die
			levels1.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      3,new List<MonsterTemplate>{},0,0,8,8, null, "DecoyPuzzle"));
			
			//6 mummy chase + switch
			levels1.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      6,new List<MonsterTemplate>{},0,0,8,8, null, "FirstMummyChase"));
			
			//7 1st monster door
			levels1.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      3,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 4.5f)
			},4,4,7,7, null, null));
			
			//8 ghost
			levels1.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      3,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Flying", 3.0f)
			},4,4,7,7, null, null));
			
			//9 crane
			levels1.Add(new Level(new MachineCreator(false, false, true, false, false, false),
			                      15,new List<MonsterTemplate>{
			},0,0,7,7, null, "SimpleCranePuzzle"));
			
			//10 crane, mummies in boxes
			levels1.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			                      12,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Standard", 4.5f)
			},5,15,8,8, "EnableNoWallsEnding", "Decoy2"));
			
			//11 crane, "look at all that energy"
			levels1.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			                      61,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.5f)
			},3,5,8,8, "EnableTrapEnding", "NoWalls"));
			
			//12 block tutorial
			levels1.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			                      47,new List<MonsterTemplate>{},0,0,9,9, null, "BlockTut"));
			
			//13 blocks 2
			levels1.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      7,new List<MonsterTemplate>{
			},0,0,9,9, null, "Blocks2"));
			
			//14 blocks 3
			levels1.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			                      5,new List<MonsterTemplate>{
			},0,0,9,9, null, "Blocks3"));
			
			//15 teleport drone
			levels1.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			                      9,new List<MonsterTemplate>{
			},5,5,7,7, null, "CranePuzzle"));
			
			//16 normal maze + drone
			levels1.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			                      6,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f)
			},5,5,8,8, "EnableTrapEnding", null));
			
			//17 drone + new maze triggers
			levels1.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			                      34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f),
				new MonsterTemplate("Standard", 8.0f)
			},10,10,8,8, null, "NewMazes"));
			
			//18 jump box, can't die
			levels1.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			                      40,new List<MonsterTemplate>{
			},0,0,9,9, null, "FirstJumpBox"));
			
			//19 normal maze + jump box + new maze ending
			levels1.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			                      6,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 3.5f),
				new MonsterTemplate("Flying", 3.0f)
			},5,8,8,8, "EnableNewMazeEnding", null));
			
			// 20 jump box, hard puzzle + blocks
			levels1.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			                      17,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.5f)
			},20,15,8,8, null, "Jump2"));
			
			//21 All machines, normal maze
			levels1.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			                      7,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.7f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f)
			},5,8,9,9, "EnableTrapEnding", null));
			
			//22 all machines, mummies in long boxes
			levels1.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			                      52,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.0f)
			},15,15,8,8, "EnableNoVerticalWallsEnding", "NoWalls2"));
			
			//23 all machines, two triggers
			levels1.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			                      35,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f)
			},8,8,9,9, null, "Boxes"));
			
			//24 drone bomb, easy puzzle
			levels1.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			                      17,new List<MonsterTemplate>{
			},12,12,8,8, "EnableNoVerticalWallsEnding", "DroneBomb"));
			
			//25 bomb 2, pac man
			levels1.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			                      38,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Standard", 8.0f),
				new MonsterTemplate("Standard", 7.5f)
			},1,3,7,7, null, "DroneBomb2"));
			
			//26 bomb 3, pac man
			levels1.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			                      34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 9.5f),
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Standard", 9.0f)
			},4,3,7,7, null, "DroneBomb3"));
			
			//27 lazer
			levels1.Add(new Level(new MachineCreator(false, false, false, true, false, false),
			                      31,new List<MonsterTemplate>{
			},5,5,9,9, null, "Lazer"));
			
			//28 lazer 2
			levels1.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			                      20,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f)
			},9,9,8,8, "EnableNewMazeEnding", "Lazer2"));
			
			//29 lazer 3
			levels1.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			                      40,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 4.5f)
			},12,12,8,8, "EnableNoVerticalWallsEnding", "Lazer3"));
			
			//30 Nothing
			levels1.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			                      26,new List<MonsterTemplate>{
			},1,1,8,8, null, "Run"));
			
			//31 everything, snake
			levels1.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			                      23,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f)
			},8,8,8,8, "EnableNoVerticalWallsEnding", "Snake"));
			
			//32 everything, bff, 2 triggers
			levels1.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			                      28,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 6.0f),
				new MonsterTemplate("Flying", 5.0f)
			},8,8,9,9, null, "BFF"));
			
			//33 everything, all ghosts
			levels1.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			                      42,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 5.0f),
				new MonsterTemplate("Flying", 5.5f),
				new MonsterTemplate("Flying", 6.0f)
			},6,8,9,9, "EnableNewMazeEnding", "Boo"));
			
			//34 everything, push blocks
			levels1.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			                      14,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 5.5f),
				new MonsterTemplate("Standard", 6.0f)
			},8,8,9,9, null, "PushBlocks"));
			
			//35 everything, normal maze + new maze ending
			levels1.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			                      30,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.2f)
			},5,8,10,10, "EnableNewMazeEnding", null));
			
			// *********2 player levels **********
			
			//1 light
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			    2, new List<MonsterTemplate>{},0,0,6,6, null, null));

			//2 switch tut
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			    10,new List<MonsterTemplate>{},0,0,7,7, null, "TriggerTut"));
			
			//3 zap tutorial
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			     35,new List<MonsterTemplate>{},0,0,9,9, null, "ZapWithSwitch"));

			//4 decoy tut with switches
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			     8,new List<MonsterTemplate>{},0,0,9,9, null, "FourSwitches"));

			//5 decoy + can die
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			     3,new List<MonsterTemplate>{},0,0,8,8, null, "DecoyPuzzle"));
			
			//6 mummy chase + switch
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    6,new List<MonsterTemplate>{},0,0,8,8, null, "FirstMummyChase"));
			
			//7 1st monster door
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    3,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 4.5f)
			},4,4,7,7, null, null));
			
			//8 ghost
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    3,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Flying", 3.0f)
			},4,4,7,7, null, null));
			
			//9 crane
			levels2.Add(new Level(new MachineCreator(false, false, true, false, false, false),
			    15,new List<MonsterTemplate>{
			},0,0,7,7, null, "SimpleCranePuzzle"));
			
			//10 crane, mummies in boxes
			levels2.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    12,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Standard", 4.5f)
			},5,15,8,8, "EnableNoWallsEnding", "Decoy2"));
			
			//11 crane, "look at all that energy"
			levels2.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    61,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.5f)
			},3,5,8,8, "EnableTrapEnding", "NoWalls"));

			//12 block tutorial
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			  47,new List<MonsterTemplate>{},0,0,9,9, null, "BlockTut"));

			//13 blocks 2
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    7,new List<MonsterTemplate>{
			},0,0,9,9, null, "Blocks2"));

			//14 blocks 3
			levels2.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    5,new List<MonsterTemplate>{
			},0,0,9,9, null, "Blocks3"));
			
			//15 teleport drone
			levels2.Add(new Level(new MachineCreator(true, false, false, false, true, false),
				9,new List<MonsterTemplate>{
			},5,5,7,7, null, "CranePuzzle"));
			
			//16 normal maze + drone
			levels2.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			    6,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f)
			},5,5,8,8, "EnableTrapEnding", null));

			//17 drone + new maze triggers
			levels2.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f),
				new MonsterTemplate("Standard", 8.0f)
			},10,10,8,8, null, "NewMazes"));
			
			//18 jump box, can't die
			levels2.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			    40,new List<MonsterTemplate>{
			},0,0,9,9, null, "FirstJumpBox"));
			
			//19 normal maze + jump box + new maze ending
			levels2.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			    6,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 3.5f),
				new MonsterTemplate("Flying", 3.0f)
			},5,8,8,8, "EnableNewMazeEnding", null));

			// 20 jump box, hard puzzle + blocks
			levels2.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			    17,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.5f)
			},20,15,8,8, null, "Jump2"));
			
			//21 All machines, normal maze
			levels2.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    7,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.7f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f)
			},5,8,9,9, "EnableTrapEnding", null));
			
			//22 all machines, mummies in long boxes
			levels2.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    52,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.0f)
			},15,15,8,8, "EnableNoVerticalWallsEnding", "NoWalls2"));
			
			//23 all machines, two triggers
			levels2.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    35,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f)
			},8,8,9,9, null, "Boxes"));
			
			//24 drone bomb, easy puzzle
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			 	17,new List<MonsterTemplate>{
			},12,12,8,8, "EnableNoVerticalWallsEnding", "DroneBomb"));
			
			//25 bomb 2, pac man
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    38,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Standard", 8.0f),
				new MonsterTemplate("Standard", 7.5f)
			},1,3,7,7, null, "DroneBomb2"));

			//26 bomb 3, pac man
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 9.5f),
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Standard", 9.0f)
			},4,3,7,7, null, "DroneBomb3"));

			//27 lazer
			levels2.Add(new Level(new MachineCreator(false, false, false, true, false, false),
				31,new List<MonsterTemplate>{
			},5,5,9,9, null, "Lazer"));
			
			//28 lazer 2
			levels2.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			   20,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f)
			},9,9,8,8, "EnableNewMazeEnding", "Lazer2"));
			
			//29 lazer 3
			levels2.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			    40,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 4.5f)
			},12,12,8,8, "EnableNoVerticalWallsEnding", "Lazer3"));

			//30 Nothing
			levels2.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			     26,new List<MonsterTemplate>{
			},1,1,8,8, null, "Run"));

			//31 everything, snake
			levels2.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    23,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f)
			},8,8,8,8, "EnableNoVerticalWallsEnding", "Snake"));

			//32 everything, bff, 2 triggers
			levels2.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    28,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 6.0f),
				new MonsterTemplate("Flying", 5.0f)
			},8,8,9,9, null, "BFF"));

			//33 everything, all ghosts
			levels2.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    42,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 5.0f),
				new MonsterTemplate("Flying", 5.5f),
				new MonsterTemplate("Flying", 6.0f)
			},6,8,9,9, "EnableNewMazeEnding", "Boo"));

			//34 everything, push blocks
			levels2.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    14,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 5.5f),
				new MonsterTemplate("Standard", 6.0f)
			},8,8,9,9, null, "PushBlocks"));
			
			//35 everything, normal maze + new maze ending
			levels2.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    30,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.2f)
			},5,8,10,10, "EnableNewMazeEnding", null));

			
			
			// ************** 3 player levels ******************************
			
			//1 light
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			    3, new List<MonsterTemplate>{},0,0,6,6, null, null));
			
			//2 switch tut
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			    10,new List<MonsterTemplate>{},0,0,7,7, null, "TriggerTut"));

			//3 zap tutorial
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    35,new List<MonsterTemplate>{},0,0,9,9, null, "ZapWithSwitch"));
			
			//4 decoy tut with switches
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    8,new List<MonsterTemplate>{},0,0,9,9, null, "FourSwitches"));
			
			//5 decoy + can die
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    3,new List<MonsterTemplate>{},0,0,8,8, null, "DecoyPuzzle"));
			
			//6 mummy + block
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
				6,new List<MonsterTemplate>{},0,0,8,8, null, "FirstMummyChase"));
			
			//7 monster door
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    4,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 5.5f)
			},4,4,7,7, null, null));
			
			//8 ghost
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    4,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Flying", 3.0f),
				new MonsterTemplate("Flying", 4.0f)
			},4,4,7,7, null, null));
			
			//9 crane
			levels3.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    15,new List<MonsterTemplate>{
			},0,0,7,7, null, "SimpleCranePuzzle"));
			
			//10 crane, mummies in box
			levels3.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    12,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Standard", 5.0f)
			},5,8,8,8, "EnableNoWallsEnding", "Decoy2"));
			
			//11 no walls, "look at all that energy"
			levels3.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    61,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.0f)
			},2,4,8,8, "EnableTrapEnding", "NoWalls"));

			//12 block tutorial
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			    47,new List<MonsterTemplate>{},0,0,9,9, null, "BlockTut"));
			
			//13 blocks 2
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    7,new List<MonsterTemplate>{
			},0,0,9,9, null, "Blocks2"));
			
			//14 blocks 3
			levels3.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    5,new List<MonsterTemplate>{
			},0,0,9,9, null, "Blocks3"));
			
			//15 teleport drone, puzzle
			levels3.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			    9,new List<MonsterTemplate>{
			},5,5,7,7, null, "CranePuzzle"));
			
			//16 drone + normal maze
			levels3.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			    7,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Flying", 3.0f)
			},5,5,8,8, "EnableTrapEnding", null));

			//17 drone + new maze triggers
			levels3.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			    34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f),
				new MonsterTemplate("Standard", 8.0f),
				new MonsterTemplate("Standard", 6.0f)
			},10,8,8,8, null, "NewMazes"));

			
			//18 jump box
			levels3.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			40,new List<MonsterTemplate>{	
			},15,15,9,9, null, "FirstJumpBox"));
			
			//19 jump box + normal maze + new ending
			levels3.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			    7,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 3.5f),
				new MonsterTemplate("Flying", 3.0f),
				new MonsterTemplate("Standard", 2.8f)
			},4,7,8,8, "EnableNewMazeEnding", null));

			//20 jump box, hard puzzle
			levels3.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			    17,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f)
			},16,10,8,8, null, "Jump2"));

			
			//21 All machines
			levels3.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    8,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.8f),
				new MonsterTemplate("Standard", 3.0f)
			},5,8,9,9, "EnableTrapEnding", null));
			
			//22 All machines, mummies in long boxes
			levels3.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			     52,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.0f)
			},13,13,8,8, "EnableNoVerticalWallsEnding", "NoWalls2"));
			
			//23 all machines
			levels3.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    35,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 4.5f)
			},8,8,9,9, null, "Boxes"));
			
			//24 drone bomb
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			17,new List<MonsterTemplate>{
			},12,12,8,8, "EnableNoVerticalWallsEnding", "DroneBomb"));
			
			//25 bomb 2 - chase
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    38,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Standard", 8.0f),
				new MonsterTemplate("Flying", 6.0f),
				new MonsterTemplate("Standard", 7.0f)
			},1,3,7,7, null, "DroneBomb2"));

			//26 bomb 3 - chase
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 9.5f),
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Standard", 7.5f),
				new MonsterTemplate("Standard", 8.0f)
			},4,3,7,7, null, "DroneBomb3"));

			//27 lazer
			levels3.Add(new Level(new MachineCreator(false, false, false, true, false, false),
			  	31,new List<MonsterTemplate>{
			},5,5,9,9, null, "Lazer"));
			
			//28 lazer 2
			levels3.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			    20,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.5f)
			},9,9,8,8, "EnableNewMazeEnding", "Lazer2"));
			
			//29 lazer 3
			levels3.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			     40,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Standard", 5.0f)
			},10,10,8,8, "EnableNoVerticalWallsEnding", "Lazer3"));

			//30 Nothing
			levels3.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			    26,new List<MonsterTemplate>{
			},1,1,8,8, null, "Run"));

			//31 everything, snake
			levels3.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    23,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f),
				new MonsterTemplate("Standard", 7.5f)
			},8,8,8,8, "EnableNoVerticalWallsEnding", "Snake"));

			//32 everything, bff, 2 triggers
			levels3.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    28,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 6.0f),
				new MonsterTemplate("Flying", 5.0f),
				new MonsterTemplate("Flying", 6.0f)
			},8,7,9,9, null, "BFF"));

			//33 everything, all ghosts
			levels3.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    42,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 5.0f),
				new MonsterTemplate("Flying", 5.5f),
				new MonsterTemplate("Flying", 6.0f),
				new MonsterTemplate("Flying", 4.5f)
			},6,6,9,9, "EnableNewMazeEnding", "Boo"));
			
			//34 everything, push blocks
			levels3.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    14,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 5.5f),
				new MonsterTemplate("Standard", 6.0f),
				new MonsterTemplate("Standard", 4.5f)
			},7,6,9,9, null, "PushBlocks"));
			
			//35 everything
			levels3.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    35,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.2f),
				new MonsterTemplate("Standard", 3.0f)
			},5,8,10,10, "EnableNewMazeEnding", null));
			
			//********* 4 player levels ****************
			
			//1 light
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
				4, new List<MonsterTemplate>{},0,0,6,6, null, null));

			//2 switch tut
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			    10,new List<MonsterTemplate>{},0,0,7,7, null, "TriggerTut"));

			//3 zap tutorial
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
				35,new List<MonsterTemplate>{},0,0,9,9, null, "ZapWithSwitch"));
			
			//4 decoy tut with switches
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			     8,new List<MonsterTemplate>{},0,0,9,9, null, "FourSwitches"));
			
			//5 decoy + can die
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			     3,new List<MonsterTemplate>{},0,0,8,8, null, "DecoyPuzzle"));
			
			//6 mummy + block
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
				6,new List<MonsterTemplate>{},0,0,8,8, null, "FirstMummyChase"));
			
			//7 monster door
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    5,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 5.5f),
				new MonsterTemplate("Standard", 4.5f)
			},4,4,7,7, null, null));
			
			//8 ghost
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    5,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Flying", 3.0f),
				new MonsterTemplate("Flying", 4.0f)
			},4,4,7,7, null, null));
			
			//9 crane
			levels4.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    15,new List<MonsterTemplate>{
			},0,0,7,7, null, "SimpleCranePuzzle"));
			
			//10 crane, mummies in box
			levels4.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    12,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 3.5f)
			},5,7,8,8, "EnableNoWallsEnding", "Decoy2"));
			
			//11 no walls "look at all that energy"
			levels4.Add(new Level(new MachineCreator(true, false, true, false, false, false),
			    61,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 3.0f)
			},2,4,8,8, "EnableTrapEnding", "NoWalls"));

			//12 block tutorial
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			    47,new List<MonsterTemplate>{},0,0,9,9, null, "BlockTut"));
			
			//13 blocks 2
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    7,new List<MonsterTemplate>{
			},0,0,9,9, null, "Blocks2"));
			
			//14 blocks 3
			levels4.Add(new Level(new MachineCreator(true, false, false, false, false, false),
			    5,new List<MonsterTemplate>{
			},0,0,9,9, null, "Blocks3"));

			//15 teleport drone
			levels4.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			    9,new List<MonsterTemplate>{
			},5,5,7,7, null, "CranePuzzle"));
			
			//16 drone + normal maze
			levels4.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			    8,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Flying", 3.0f),
				new MonsterTemplate("Standard", 5.0f)
			},5,5,8,8, "EnableTrapEnding", null));

			//17 drone + new maze triggers
			levels4.Add(new Level(new MachineCreator(true, false, false, false, true, false),
			     34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f),
				new MonsterTemplate("Standard", 8.0f),
				new MonsterTemplate("Standard", 6.0f)
			},10,6,8,8, null, "NewMazes"));
			
			//18 jump box
			levels4.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			40,new List<MonsterTemplate>{
			},0,0,9,9, null, "FirstJumpBox"));

			//19 jump box + normal maze + new ending
			levels4.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			    8,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 3.5f),
				new MonsterTemplate("Flying", 3.0f),
				new MonsterTemplate("Standard", 2.8f)
			},4,5,8,8, "EnableNewMazeEnding", null));

			//20 jump box hard puzzle
			levels4.Add(new Level(new MachineCreator(true, true, false, false, false, false),
			    17,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 3.8f),
				new MonsterTemplate("Standard", 3.5f)
			},15,8,8,8, null, "Jump2"));
			
			//21 All machines
			levels4.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    12,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 3.0f)
			},5,8,9,9, "EnableTrapEnding", null));
			
			//22 All machines, mummmies in long boxes
			levels4.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    52,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Flying", 3.5f),
				new MonsterTemplate("Standard", 4.0f),
				new MonsterTemplate("Standard", 5.0f)
			},10,10,8,8, "EnableNoVerticalWallsEnding", "NoWalls2"));
			
			//23 all machines
			levels4.Add(new Level(new MachineCreator(true, true, true, false, true, false),
			    35,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Flying", 5.0f)
			},8,6,9,9, null, "Boxes"));
			
			//24 drone bomb, easy puzzle
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    17,new List<MonsterTemplate>{
			},12,12,8,8, "EnableNoVerticalWallsEnding", "DroneBomb"));
			
			//25 bomb 2 - chase
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    38,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Flying", 7.0f),
				new MonsterTemplate("Standard", 8.0f),
				new MonsterTemplate("Standard", 7.5f)
			},1,3,7,7, null, "DroneBomb2"));

			//26 bomb 3 - chase
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, true),
			    34,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 9.5f),
				new MonsterTemplate("Standard", 8.5f),
				new MonsterTemplate("Standard", 7.5f),
				new MonsterTemplate("Standard", 8.0f)
			},4,3,7,7, null, "DroneBomb3"));

			//27 lazer
			levels4.Add(new Level(new MachineCreator(false, false, false, true, false, false),
			    31,new List<MonsterTemplate>{
			},5,5,9,9, null, "Lazer"));
			
			//28 lazer 2
			levels4.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			    20,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 3.5f)
			},9,9,8,8, "EnableNewMazeEnding", "Lazer2"));
			
			//29 lazer 3
			levels4.Add(new Level(new MachineCreator(true, false, false, true, false, false),
			    40,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 4.0f),
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Standard", 5.0f)
			},8,8,8,8, "EnableNoVerticalWallsEnding", "Lazer3"));

			//30 Nothing
			levels4.Add(new Level(new MachineCreator(false, false, false, false, false, false),
			    26,new List<MonsterTemplate>{
			},1,1,8,8, null, "Run"));

			//31 everything
			levels4.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    23,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 7.0f),
				new MonsterTemplate("Standard", 7.5f),
				new MonsterTemplate("Standard", 8.0f)
			},8,8,8,8, "EnableNoVerticalWallsEnding", "Snake"));

			//32 everything, bff, 2 triggers
			levels4.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    28,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 6.0f),
				new MonsterTemplate("Flying", 5.0f),
				new MonsterTemplate("Flying", 6.0f),
				new MonsterTemplate("Standard", 8.0f)
				},8,6,9,9, null, "BFF"));

			//33 everything, all ghosts
			levels4.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    42,new List<MonsterTemplate>{
				new MonsterTemplate("Flying", 5.0f),
				new MonsterTemplate("Flying", 5.5f),
				new MonsterTemplate("Flying", 6.0f),
				new MonsterTemplate("Flying", 4.5f),
				new MonsterTemplate("Flying", 4.0f)
			},6,6,9,9, "EnableNewMazeEnding", "Boo"));
			
			//34 everything, push blocks
			levels4.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    14,new List<MonsterTemplate>{
				new MonsterTemplate("Standard", 5.0f),
				new MonsterTemplate("Standard", 5.5f),
				new MonsterTemplate("Standard", 6.0f),
				new MonsterTemplate("Standard", 4.5f),
				new MonsterTemplate("Standard", 4.0f)
			},7,6,9,9, null, "PushBlocks"));

			//35 everything
			levels4.Add(new Level(new MachineCreator(true, true, true, true, true, true),
			    40,new List<MonsterTemplate>{
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

