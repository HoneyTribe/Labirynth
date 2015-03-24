﻿using UnityEngine;
using System;
using System.Collections.Generic;

public class Boxes : PuzzleTemplate
{
	public Boxes() :base()
	{
		sizeX = 9;
		sizeZ = 9;
		
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 6; 
		
		templateSizeX = 17;
		templateSizeZ = 17;
		template = new int[17,17]
		{
			//0 = wall/post , 2 = space, 3 = block, 4 = mummy, 5 = key 6 = sleepingMonster 7 = vertical walls trigger, 8 = horizontal walls trigger
			// to make a gap at edge of screen place a 0 and a 2 behind it

			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
			{2,0,4,2,5,2,5,2,5,2,5,2,5,2,5,0,2},
			{2,0,2,0,0,0,0,0,0,0,0,0,0,0,2,0,2},
			{2,0,5,0,4,2,5,2,8,2,5,2,5,0,5,0,2},
			{2,0,2,0,2,0,0,0,0,0,0,0,2,0,2,0,2},
			{2,0,5,0,5,0,4,2,5,2,5,0,5,0,5,0,2},
			{2,0,2,0,2,0,2,0,0,0,2,0,2,0,2,0,2},
			{2,0,5,0,5,0,5,0,7,0,5,0,5,0,5,0,2},
			{2,0,2,0,2,0,2,0,0,0,2,0,2,0,2,0,2},
			{2,0,5,0,5,0,5,2,5,2,5,0,5,0,5,0,2},
			{2,0,2,0,2,0,0,0,0,0,0,0,2,0,2,0,2},
			{2,0,5,0,5,2,5,2,5,2,5,2,5,0,5,0,2},
			{2,0,2,0,0,0,0,0,0,0,0,0,0,0,2,0,2},
			{2,0,5,2,5,2,5,2,5,2,5,2,5,2,5,0,2},
			{2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}
			
		};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}