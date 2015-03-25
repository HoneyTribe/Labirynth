﻿using UnityEngine;
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
			{2,2,9,2,5,2,5,2,5,2,5,2,2,2,2},
			{2,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{2,0,5,0,2,2,2,2,6,2,9,2,5,2,2},
			{2,0,0,0,2,2,2,2,2,2,2,2,2,2,2},
			{5,0,2,2,2,2,5,2,2,2,2,2,2,2,5},
			{2,0,2,2,2,0,0,0,0,0,2,0,0,0,0},
			{5,0,9,0,2,0,2,2,2,0,9,2,5,2,5},
			{2,0,2,0,2,0,2,2,2,0,2,2,2,2,2},
			{5,2,6,0,2,0,5,2,5,0,5,2,5,2,5},
			{2,2,2,2,2,0,0,0,0,0,2,0,2,2,2},
			{5,2,2,2,5,2,5,2,5,2,2,0,5,2,5},
			{2,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
			{2,0,5,2,5,2,5,2,5,2,5,2,5,0,2},
			{2,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
			{2,2,2,2,5,2,5,2,5,2,5,2,2,2,2}				
		};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}