using UnityEngine;
using System;
using System.Collections.Generic;

public class SimpleCranePuzzle : PuzzleTemplate
{
	public SimpleCranePuzzle() :base()
	{
		sizeX = 5;
		sizeZ = 4;
		
		extX = 1;
		extZ = 1;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 5;
		templateSizeZ = 5;
		template = new int[5, 5] 	{{5,2,5,0,5},
									{2,0,0,0,2},
									{2,0,5,0,5},
									{2,0,2,2,2},
									{5,0,5,2,0}};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}