using UnityEngine;
using System;
using System.Collections.Generic;

public class Lazer3 : PuzzleTemplate
{
	public Lazer3() :base()
	{
		sizeX = 7;
		sizeZ = 8;
		
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 9; 
		
		templateSizeX = 13;
		templateSizeZ = 15;
		template = new int[15,13]
		{
			//0 = wall/post , 2 = space, 3 = block, 4 = mummy, 5 = key 6 = sleepingMonster
			// to make a gap at edge of screen place a 0 and a 2 behind it

			{5,0,5,2,5,2,5,2,5,2,5,2,5},
			{2,0,2,2,2,2,2,2,2,0,0,0,2},
			{5,2,5,2,5,2,5,2,5,0,5,0,5},
			{2,2,2,2,2,2,2,2,2,0,0,0,2},
			{5,2,5,2,3,2,5,2,3,2,5,2,5},
			{2,2,2,0,2,0,0,0,2,0,2,2,2},
			{5,2,4,0,5,0,5,0,5,0,5,2,5},
			{2,2,2,0,2,0,0,0,2,0,2,2,2},
			{4,2,5,2,3,2,5,2,3,2,5,2,4},
			{2,0,0,0,2,2,2,2,2,2,2,2,2},
			{5,0,2,0,5,2,5,2,5,2,5,2,5},
			{2,0,0,0,2,2,2,2,2,2,2,0,2},
			{5,2,5,2,5,2,3,2,5,2,5,0,5},
			{0,0,0,0,0,0,2,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0}
		};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}