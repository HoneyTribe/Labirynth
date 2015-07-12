using UnityEngine;
using System;
using System.Collections.Generic;

public class SimpleCranePuzzle : PuzzleTemplate
{
	public SimpleCranePuzzle() :base()
	{
		sizeX = 4;
		sizeZ = 4;
	
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 1; 
		
		templateSizeX = 7;
		templateSizeZ = 7;
		template = new string[7, 7] 	
		{
			{"5","2","5","2","5","2","5"},
			{"0","0","0","0","0","0","2"},
			{"4","0","5","0","5","0","5"},
			{"2","0","0","0","0","0","2"},
			{"5","0","5","0","5","0","5"},
			{"2","0","2","0","2","0","2"},
			{"5","0","5","0","5","0","5"}						
		};
		
		extededTemplate = new string[sizeZ * 2 -1 , sizeX * 2 -1]; 
		init ();
	}
}

