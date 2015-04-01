﻿using UnityEngine;
using System;
using System.Collections.Generic;

public class DecoyTut : PuzzleTemplate
{
	public DecoyTut() :base()
	{
		sizeX = 10;
		sizeZ = 10;
		
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 8; 
		
		templateSizeX = 19;
		templateSizeZ = 19;
		template = new int[19,19]
		{
			//0 = wall/post , 2 = space, 3 = block, 4 = mummy, 5 = key 6 = sleepingMonster 7 = hirizontal walls trigger 8 = verticall walls trigger
			// to make a gap at edge of screen place a 0 and a 2 behind it
			
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{5,5,2,2,5,5,5,2,2,5,5,2,2,5,2,2,5,2,5},
			{5,2,5,2,5,2,2,2,5,2,2,2,5,2,5,2,5,2,5},
			{5,2,5,2,5,5,2,2,5,2,2,2,5,2,5,2,2,5,2},
			{5,2,5,2,5,2,2,2,5,2,2,2,5,2,5,2,2,5,2},
			{5,5,2,2,5,5,5,2,2,5,5,2,2,5,2,2,2,5,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,0,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,0,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,0,2,2,2,2,2},
			{2,2,2,2,2,2,2,5,2,2,2,2,2,0,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,5,2,2,2,2,0,2,2,2,2,2},
			{2,2,2,5,5,5,5,5,2,5,2,2,2,0,8,2,6,2,2},
			{2,2,2,2,2,2,2,2,5,2,2,2,2,0,2,2,2,2,2},
			{2,2,2,2,2,2,2,5,2,2,2,2,2,0,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,0,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}
		};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}

/*
{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{5,5,2,2,5,5,5,2,2,5,5,2,2,5,2,2,5,2,5},
			{5,2,5,2,5,2,2,2,5,2,2,2,5,2,5,2,5,2,5},
			{5,2,5,2,5,5,2,2,5,2,2,2,5,2,5,2,2,5,2},
			{5,2,5,2,5,2,2,2,5,2,2,2,5,2,5,2,2,5,2},
			{5,5,2,2,5,5,5,2,2,5,5,2,2,5,2,2,2,5,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{5,5,5,2,5,5,5,2,2,2,2,2,2,2,2,0,0,0,0},
			{2,5,5,2,5,5,2,2,2,2,2,2,2,2,2,0,2,2,6},
			{2,2,5,2,5,2,2,2,2,2,2,2,2,2,2,0,2,2,2},
			{2,2,2,5,2,2,2,2,2,2,2,2,5,2,2,0,2,2,2},
			{2,2,5,2,5,2,2,2,2,2,2,2,2,5,2,0,2,2,2},
			{2,2,5,5,5,2,2,2,2,5,5,5,5,5,5,0,8,2,2},
			{5,2,2,5,2,2,5,2,2,2,2,2,2,5,2,0,2,2,2},
			{2,5,5,5,5,5,2,2,2,2,2,2,5,2,2,0,2,2,2},
			{2,2,2,5,2,2,2,2,2,2,2,2,2,2,2,0,2,2,2},
			{2,5,5,5,5,5,2,2,2,2,2,2,2,2,2,0,0,0,0},
			{2,5,2,2,2,5,2,2,2,2,2,2,2,2,2,2,2,2,2}
*/	