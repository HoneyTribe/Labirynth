using UnityEngine;
using System;
using System.Collections.Generic;

public class DecoyPuzzle : PuzzleTemplate
{
	public DecoyPuzzle() :base()
	{
		sizeX = 3;
		sizeZ = 4;
		
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 5;
		templateSizeZ = 7;
		template = new int[7, 5] {{5,0,5,0,5},
								  {2,0,2,0,2},
								  {6,0,6,0,6},
								  {2,0,2,0,2},
								  {2,0,2,0,2},
								  {2,0,2,0,2},
								  {2,2,2,2,0}};

		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}