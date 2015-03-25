using UnityEngine;
using System;
using System.Collections.Generic;

public class NewMazes : PuzzleTemplate
{
	//0 = wall/post , 2 = space, 3 = block, 4 = mummy, 5 = key 6 = sleepingMonster, 7 = vertical trigger, 8 = horozontal wall trigger, 9 = new mazes trigger
	public NewMazes() :base()
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
			{1,1,1,1,5,1,5,1,5,1,5,1,1,1,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,1,5,1,1,1,1,1,1,1,1,1,5,1,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{5,1,9,1,5,1,1,1,5,1,1,1,9,1,5},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{5,1,9,1,5,1,1,1,5,1,1,1,9,1,5},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{5,1,9,1,1,1,1,1,1,1,5,1,9,1,5},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{5,1,1,1,5,1,5,1,5,1,1,1,1,1,5},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,1,5,1,1,1,1,1,1,1,1,1,5,1,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,1,1,1,5,1,5,1,5,1,5,1,1,1,1}					
		};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}