﻿using UnityEngine;
using System;
using System.Collections.Generic;

public class Boxes_2P : PuzzleTemplate
{
	public Boxes_2P() :base()
	{
		sizeX = 9;
		sizeZ = 9;
		
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 6; 
		
		templateSizeX = 17;
		templateSizeZ = 17;
		template = new string[17,17]
		{
			//0 = wall/post , 0-x = wall to breal from switch,  2 = space"," 3 = block"," 4 = mummy"," 5 = key 6 = sleepingMonster"," 7 = vertical trigger","
			//8 = horozontal wall trigger"," 9 = new mazes trigger, 10 = fixed decoy, 11-x = switch for one wall
			// To make a gap at edge of screen place a 0 and a 2 behind it

			
			{"2","2","5","2","5","2","2","2","2","2","2","2","5","2","5","2","2"},
			{"2","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","2"},
			{"5","0","4","2","2","2","5","2","5","2","5","2","2","2","12-1","0","5"},
			{"2","0","2","0","0","0","0","0","0","0","0","0","0","0","2","0","2"},
			{"5","0","5","0","4","2","5","2","2","2","5","2","2","0","5","0","5"},
			{"2","0","2","0","2","0","0","0","0","0","0","0","2","0","2","0","2"},
			{"2","0","5","0","5","0","4","2","5","2","2","0","5","0","5","0","2"},
			{"2","0","2","0","2","0","2","0","0","0","2","0","2","0","2","0","2"},
			{"2","0","2","0","5","0","5","0","7","0","5","0","5","0","2","0","2"},
			{"2","0","2","0","2","0","2","0","0","0","2","0","2","0","2","0","2"},
			{"2","0","2","0","2","0","5","2","5","2","5","0","2","0","2","0","2"},
			{"2","0","2","0","2","0","0","0","0","0","0","0","2","0","2","0","2"},
			{"2","0","2","0","2","2","2","2","5","2","2","2","2","0","2","0","2"},
			{"2","0","2","0","0","0","0","0","0","0","0","0","0","0","2","0","2"},
			{"2","0","5","2","2","2","2","2","2","2","2","2","2","2","5","0","2"},
			{"2","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","2"},
			{"5","2","2","2","5","2","2","2","5","2","2","2","5","2","2","2","5"}
			
		};
		
		extededTemplate = new string[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}