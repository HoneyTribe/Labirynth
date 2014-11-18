﻿using UnityEngine;
using System;
using System.Collections.Generic;

public class NoWalls2 : PuzzleTemplate
{
	public NoWalls2() :base()
	{
		sizeX = 8;
		sizeZ = 8;
		
		extX = 1;
		extZ = 1;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 16;
		templateSizeZ =16;
		template = new int[16,16]{	{4,2,5,0,5,0,5,2,5,0,5,0,5,2,4,0},
									{2,2,2,0,2,0,2,2,2,0,2,0,2,2,2,0},
									{5,2,5,0,5,0,5,2,5,0,5,0,5,2,5,0},
									{0,0,0,0,2,0,2,2,2,0,2,0,0,0,0,0},
									{5,2,5,2,5,0,4,2,4,0,5,2,5,2,5,0},
									{2,0,0,0,2,0,2,2,2,0,2,0,0,0,2,0},
									{5,0,5,0,5,0,5,2,5,0,5,0,5,0,5,0},
									{2,0,2,0,2,0,2,2,2,0,2,0,2,0,2,0},
									{5,0,5,0,5,0,5,2,5,0,5,0,5,0,5,0},
									{2,0,2,0,2,0,2,2,2,0,2,0,2,0,2,0},
									{5,0,5,0,5,0,5,2,5,0,5,0,5,0,5,0},
									{2,0,0,0,2,0,2,2,2,0,2,0,0,0,2,0},
									{5,2,5,2,5,0,5,2,5,0,5,2,5,2,5,2},
									{2,2,2,2,2,0,0,0,0,0,2,2,2,2,2,2},
									{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
									{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}};
		
		extededTemplate = new int[sizeZ * 2, sizeX * 2]; 
		init ();
	}
}

