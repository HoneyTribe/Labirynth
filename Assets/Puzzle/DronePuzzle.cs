using UnityEngine;
using System;
using System.Collections.Generic;

public class DronePuzzle : PuzzleTemplate
{
	public DronePuzzle() :base()
	{
		sizeX = 7;
		sizeZ = 7;
		
		extX = 4;
		extZ = 4;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 9;
		templateSizeZ = 9;
		template = new int[9, 9] {{2,2,2,2,2,2,2,2,2},
								  {2,0,0,0,0,0,0,0,2},
								  {2,0,4,2,5,2,4,0,2},
								  {2,0,2,2,5,2,2,0,2},
								  {2,0,2,2,5,2,2,0,2},
								  {2,0,2,2,5,2,2,0,2},
								  {2,0,2,2,5,2,2,0,2},
								  {2,0,0,0,0,0,0,0,2},
								  {2,2,2,2,2,2,2,2,2}};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}