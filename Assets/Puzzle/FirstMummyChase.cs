using UnityEngine;
using System;
using System.Collections.Generic;

public class FirstMummyChase : PuzzleTemplate
{
	public FirstMummyChase() :base()
	{
		sizeX = 4;
		sizeZ = 3;
		
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 0; 
		
		templateSizeX = 7;
		templateSizeZ = 5;
		template = new string[5,7]
		{
			{"5","2","4","2","4","2","2"},
			{"2","2","2","2","2","2","2"},
			{"5","2","5","2","2","2","3"},
			{"2","2","2","2","2","0","2"},
			{"5","2","5","2","5","0","0"}
		};
		
		extededTemplate = new string[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}