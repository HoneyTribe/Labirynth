using UnityEngine;
using System;
using System.Collections.Generic;

public class DecoyPuzzle : PuzzleTemplate
{
	//0 = wall/post , 0-x = wall to breal from switch,  2 = space"," 3 = block"," 4 = mummy"," 5 = key 6 = sleepingMonster"," 7 = vertical trigger","
	//8 = horozontal wall trigger"," 9 = new mazes trigger, 10 = fixed decoy, 11-x = switch for one wall
	// To make a gap at edge of screen place a 0 and a 2 behind it

	public DecoyPuzzle() :base()
	{
		sizeX = 4;
		sizeZ = 4;
		
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 7;
		templateSizeZ = 7;
		template = new string[7, 7]
		{
		{"5","2","5","0","11-3","0","5"},
		{"0","0","2","0","0-2","0","2"},
		{"6","0","6","0","6","0","2"},
		{"0-3","0","0-1","0","2","0","2"},
		{"2","0","11-2","0","2","0","11-1"},
		{"2","0","0-4","0","0","0","2"},
		{"11-4","0","2","2","0","0","0"}
		};

		extededTemplate = new string[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}