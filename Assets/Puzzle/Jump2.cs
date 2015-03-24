using UnityEngine;
using System;
using System.Collections.Generic;

public class Jump2 : PuzzleTemplate
{
	public Jump2() :base()
	{
		sizeX = 6;
		sizeZ = 5;
		
		extX = 2;
		extZ = 2;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 11;
		templateSizeZ = 9;
		template = new int[9,11]
		{
			//0 = wall/post , 2 = space, 3 = block, 4 = mummy, 5 = key 6 = sleepingMonster
			// to make a gap at edge of screen place a 0 and a 2 behind it

			{5,2,5,2,5,2,3,2,4,2,5},
			{2,2,2,2,2,2,2,0,0,0,0},
			{5,2,2,2,5,2,2,0,5,2,5},
			{0,0,2,0,0,0,0,0,2,2,2},
			{0,0,3,0,5,2,5,2,5,2,5},
			{0,0,2,0,2,0,2,0,2,0,2},
			{0,0,2,0,5,2,6,2,5,2,5},
			{0,0,2,0,2,0,2,0,2,0,2},
			{2,2,0,2,5,0,5,0,5,0,5}

		};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}