using UnityEngine;
using System;
using System.Collections.Generic;

public class Crane2 : PuzzleTemplate
{
	public Crane2() :base()
	{
		sizeX = 5;
		sizeZ = 5;
		
		extX = 2;
		extZ = 2;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 9;
		templateSizeZ = 9;
		template = new string[9, 9]
		   {
			{"5","2","5","2","5","2","5","2","5"},
			{"0","0","0","0","2","0","0","0","2"},
			{"2","0","5","0","5","0","5","0","2"},
			{"2","0","0","0","2","0","0","0","2"},
			{"2","2","5","2","5","2","5","2","2"},
			{"2","0","0","0","2","0","0","0","2"},
			{"0","0","5","0","5","0","5","0","0"},
			{"2","0","0","0","2","0","2","0","2"},
			{"5","0","5","2","5","2","5","2","5"}
			};
		
		extededTemplate = new string[sizeZ * 2 -1 , sizeX * 2 -1 ]; 
		init ();
	}
}

