using UnityEngine;
using System;
using System.Collections.Generic;

public class NoWalls : PuzzleTemplate
{
	public NoWalls() :base()
	{
		sizeX = 7;
		sizeZ = 7;
		
		extX = 1;
		extZ = 1;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 7;
		templateSizeZ = 7;
		template = new int[7,7] {{5,2,5,2,5,2,5},
								{2,2,2,2,2,2,2},
								{5,2,5,2,5,2,5},
								{2,2,2,2,2,2,2},
								{5,2,5,2,5,2,5},
								{2,2,2,2,2,2,2},
								{5,2,5,2,5,2,5}};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}