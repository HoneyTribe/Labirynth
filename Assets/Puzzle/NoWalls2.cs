﻿using UnityEngine;
using System;
using System.Collections.Generic;

public class NoWalls2 : PuzzleTemplate
{
	public NoWalls2() :base()
	{
		sizeX = 8;
		sizeZ = 8;
		
		extX = 2;
		extZ = 2;
		internalSize = sizeZ -1; 
		
		templateSizeX = 15;
		templateSizeZ =15;
		template = new int[15,15]
		{
			//0 = wall/post , 2 = space, 3 = block, 4 = mummy, 5 = key 6 = sleepingMonster
			// to make a gap at edge of screen place a 0 at edge and a 2 behind it

			{4,2,5,0,5,0,4,2,4,0,5,0,4,2,5},
			{2,2,2,0,2,0,2,2,2,0,2,0,2,2,2},
			{5,2,5,0,5,0,5,2,5,0,5,0,5,2,5},
			{0,0,0,0,2,0,2,2,2,0,2,0,0,0,0},
			{5,2,5,2,5,0,5,2,5,0,5,2,5,2,5},
			{2,0,0,0,2,0,2,2,2,0,2,0,0,0,2},
			{5,0,5,0,5,0,5,2,5,0,5,0,2,0,5},
			{2,0,2,0,2,0,2,2,2,0,2,0,2,0,2},
			{5,0,5,0,5,0,5,2,5,0,5,0,5,0,5},
			{2,0,2,0,2,0,2,2,2,0,2,0,2,0,2},
			{5,0,5,0,5,0,5,2,5,0,5,0,5,0,5},
			{2,0,0,0,2,0,2,2,2,0,2,0,0,0,2},
			{5,2,5,2,5,0,5,2,5,0,5,2,5,2,5},
			{2,2,2,2,2,0,0,0,0,0,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}					
		};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}

