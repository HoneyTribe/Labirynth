using UnityEngine;
using System;
using System.Collections.Generic;

public class Blocks3 : PuzzleTemplate
{
	//0 = wall/post , 0-x = wall to breal from switch,  2 = space"," 3 = block"," 4 = mummy"," 5 = key 6 = sleepingMonster"," 7 = vertical trigger","
	//8 = horozontal wall trigger"," 9 = new mazes trigger, 10 = fixed decoy, 11-x = switch for one wall
	// To make a gap at edge of screen place a 0 and a 2 behind it
	
	public Blocks3() :base()
	{
		sizeX = 7;
		sizeZ = 5;
		
		extX = 2;
		extZ = 2;
		internalSize = sizeZ - 0; 
		
		templateSizeX = 13;
		templateSizeZ = 9;
		template = new string[9,13]
		{
			{"4","2","11-1","2","5","0","2","0","2","0","11-4","0","2"},
			{"0","0","2","0","0","0","2","0","0","0","2","0","0"},
			{"5","0-2","11-2","0","5","0","2","2","3","2","2","2","2"},
			{"0","0","0-1","0","2","0","2","0","0","0","2","0","0"},
			{"2","0","2","0","5","2","3","0","5","0-3","11-3","0-4","4"},
			{"2","0","2","0","0","0","2","0","0","0","0","0","0"},
			{"2","2","2","2","3","2","2","2","3","2","2","0","2"},
			{"0","0","0","0","0","0","2","0","0","0","0","0","2"},
			{"2","2","2","2","2","0","0","0","2","2","2","2","2"}
		};
		
		extededTemplate = new string[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}