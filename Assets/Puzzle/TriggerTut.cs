﻿using UnityEngine;
using System;
using System.Collections.Generic;

public class TriggerTut : PuzzleTemplate
{
	public TriggerTut() :base()
	{
		sizeX = 7;
		sizeZ = 7;
		
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 13;
		templateSizeZ = 13;
		template = new int[13,13]
		{
			//0 = wall/post , 2 = space, 3 = block, 4 = mummy, 5 = key 6 = sleepingMonster 7 = trigger
			// to make a gap at edge of screen place a 0 and a 2 behind it
			
			{2,2,2,2,2,2,7,2,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2},
			{2,2,2,2,2,2,5,2,2,2,2,2,2},
			{2,2,2,0,0,0,2,0,0,0,2,2,2},
			{2,2,2,0,5,0,5,0,5,0,2,2,2},
			{2,0,0,0,0,0,2,0,0,0,0,0,2},
			{2,0,5,0,2,2,5,2,2,0,5,0,2},
			{2,0,0,0,2,2,2,2,2,0,0,0,2},
			{2,2,2,2,2,2,5,2,2,2,2,2,2},
			{2,2,2,2,2,0,0,0,2,2,2,2,2},
			{2,2,2,2,2,0,5,0,2,2,2,2,2},
			{2,2,2,2,2,0,0,0,2,2,2,2,2},
			{2,2,2,2,2,2,5,2,2,2,2,2,2}
		};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}