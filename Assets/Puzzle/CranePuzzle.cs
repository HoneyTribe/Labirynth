using UnityEngine;
using System;
using System.Collections.Generic;

public class CranePuzzle : PuzzleTemplate
{
	public CranePuzzle() :base()
	{
		sizeX = 6;
		sizeZ = 6;
		
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 7;
		templateSizeZ = 9;
		template = new int[9, 7] {{2,2,2,2,2,2,2},
								  {2,0,0,0,0,0,2},
								  {3,2,4,2,2,0,2},
								  {2,2,2,2,2,0,2},
								  {2,2,5,2,2,0,2},
								  {2,2,2,2,2,0,2},
								  {2,2,5,2,3,0,2},
								  {0,0,0,0,2,0,2},
								  {0,0,0,0,2,2,2}};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}