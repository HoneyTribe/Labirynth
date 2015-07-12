using UnityEngine;
using System;
using System.Collections.Generic;

public class Drone2 : PuzzleTemplate
{
	public Drone2() :base()
	{
		sizeX = 7;
		sizeZ = 4;
		
		extX = 2;
		extZ = 2;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 13;
		templateSizeZ = 7;
		template = new string[7,13]
		{
			//0 = wall/post , 2 = space, 3 = block, 4 = mummy, 5 = key 6 = sleepingMonster
			// to make a gap at edge of screen place a 0 and a 2 behind it
			
			{"0","2","5","0","4","2","5","2","5","0","5","2","0"},
			{"0","0","2","0","0","0","0","0","0","0","2","0","0"},
			{"0","2","5","0","5","2","4","2","5","0","5","2","0"},
			{"0","0","2","0","0","0","0","0","0","0","2","0","0"},
			{"0","2","5","0","5","2","2","2","5","0","5","2","0"},
			{"0","0","2","0","0","0","0","0","0","0","2","0","0"},
			{"0","2","5","0","5","0","2","0","4","0","5","2","0"}
			
		};
		
		extededTemplate = new string[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}