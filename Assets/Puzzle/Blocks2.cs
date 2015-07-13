using UnityEngine;
using System;
using System.Collections.Generic;

public class Blocks2 : PuzzleTemplate
{
	//0 = wall/post, 2 = space, 3 = block, 4 = mummy, 5 = key 6 = sleepingMonster, 7 = vertical trigger, 8 = horozontal wall trigger, 9 = new mazes trigger
	//10 = fixed decoy, 11 = One Wall Trigger

	public Blocks2() :base()
	{
		sizeX = 7;
		sizeZ = 5;
		
		extX = 2;
		extZ = 2;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 13;
		templateSizeZ = 9;
		template = new string[9,13]
		{
			{"5","2","0","2","2","2","2","2","2","2","2","2","5"},
			{"0","0","2","2","2","0","0","0","2","2","2","0","0"},
			{"6","0","2","2","2","0","4","0","2","2","2","0","11-1"},
			{"2","0","2","0","0","0","2","0","2","0","0","0","2"},
			{"2","0","5","0","2","2","3","2","5","2","3","2","4"},
			{"0-1","0","2","0","0","0","0-2","0","2","0","2","2","2"},
			{"11-2","0","2","2","2","0","5","0","2","0","2","2","2"},
			{"0","0","2","2","2","0","0","0","2","0","0","0","2"},
			{"5","2","2","2","2","2","2","2","0","2","2","0","5"}
		};
		
		extededTemplate = new string[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}