using UnityEngine;
using System;
using System.Collections.Generic;

public class DroneBomb : PuzzleTemplate
{
	public DroneBomb() :base()
	{
		sizeX = 6;
		sizeZ = 5;
		
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 11;
		templateSizeZ = 9;
		template = new string[9,11]
		{
			{"0","0","4","2","5","2","5","2","5","2","2"},
			{"2","0","2","2","2","2","2","2","2","2","2"},
			{"3","0","5","2","4","2","5","2","5","2","2"},
			{"2","2","2","2","2","2","2","2","2","2","2"},
			{"2","2","5","2","5","2","4","2","5","2","2"},
			{"2","2","2","2","2","2","2","2","2","2","2"},
			{"2","2","5","2","5","2","5","2","5","0","3"},
			{"2","2","2","2","2","2","2","2","2","0","2"},
			{"2","2","5","2","5","2","5","2","5","0","0"}
		};
		
		extededTemplate = new string[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}