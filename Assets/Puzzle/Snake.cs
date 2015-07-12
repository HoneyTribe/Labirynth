using UnityEngine;
using System;
using System.Collections.Generic;

public class Snake : PuzzleTemplate
{
	public Snake() :base()
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
			//0 = wall/post , 2 = space, 3 = block, 4 = mummy, 5 = key 6 = sleepingMonster
			// to make a gap at edge of screen place a 0 at edge and a 2 behind it

			{"5","2","3","2","5","2","5","2","4","0","2"},
			{"2","0","0","0","0","0","0","0","2","0","2"},
			{"5","0","5","2","5","2","5","2","5","0","5"},
			{"2","0","2","0","0","0","0","0","0","0","2"},
			{"5","0","4","2","5","2","5","2","2","0","5"},
			{"2","0","0","0","0","0","0","0","2","0","2"},
			{"5","0","5","2","5","2","5","2","5","0","5"},
			{"2","0","2","0","0","0","0","0","0","0","2"},
			{"0","0","5","2","5","2","5","2","6","2","5"}
		
		};
		
		extededTemplate = new string[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}