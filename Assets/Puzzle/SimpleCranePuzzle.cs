using UnityEngine;
using System;
using System.Collections.Generic;

public class SimpleCranePuzzle : PuzzleTemplate
{
	public SimpleCranePuzzle() :base()
	{
		sizeX = 4;
		sizeZ = 4;
	
		extX = 1;
		extZ = 1;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 8;
		templateSizeZ = 8;
		template = new int[8, 8] 	{{0,2,5,2,5,2,5,0},
									{0,0,0,0,0,0,2,0},
									{5,0,5,0,5,0,5,0},
									{2,0,0,0,0,0,2,0},
									{4,0,5,0,5,0,5,0},
									{2,0,2,0,2,0,2,0},
									{5,0,5,0,5,0,5,0},
									{0,0,0,0,0,0,0,0}};
		
		extededTemplate = new int[sizeZ * 2 , sizeX * 2 ]; 
		init ();
	}
}

