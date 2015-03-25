using UnityEngine;
using System;
using System.Collections.Generic;

public class FirstJumpBox : PuzzleTemplate
{
	//0 = wall/post , 2 = space, 3 = block, 4 = mummy, 5 = key 6 = sleepingMonster
	public FirstJumpBox() :base()
	{
		sizeX = 8;
		sizeZ = 8;
		
		extX = 2;
		extZ = 2;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 15;
		templateSizeZ = 15;
		template = new int[15,15]
		{
			{0,2,0,2,0,2,0,2,0,2,0,2,0,2,0},
			{2,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{5,0,5,2,5,2,5,2,5,2,5,2,5,2,5},
			{2,0,2,0,2,0,2,0,2,0,2,0,2,0,2},
			{5,0,3,0,3,0,3,0,3,0,3,0,3,0,3},
			{2,0,2,0,2,0,2,0,2,0,2,0,2,0,2},
			{5,0,2,0,2,0,2,0,2,0,2,0,2,0,2},
			{2,0,2,0,2,0,2,0,2,0,2,0,2,0,2},
			{5,0,2,0,2,0,2,0,2,0,2,0,2,0,2},
			{2,0,2,0,2,0,2,0,2,0,2,0,2,0,2},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}				
		};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}