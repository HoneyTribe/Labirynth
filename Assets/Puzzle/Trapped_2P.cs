using UnityEngine;
using System;
using System.Collections.Generic;

public class Trapped_2P : PuzzleTemplate
{
	//0 = wall/post, 2 = space, 3 = block, 4 = mummy, 5 = key 6 = sleepingMonster, 7 = vertical trigger, 8 = horozontal wall trigger, 9 = new mazes trigger
	//10 = fixed decoy, 11+(-1, -2, -3, -4) = One Wall Trigger 12 +(-1, -2, -3, -4) = player
	
	public Trapped_2P() :base()
	{
		sizeX = 6;
		sizeZ = 6;
		
		extX = 2;
		extZ = 2;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 11;
		templateSizeZ = 11;
		template = new string[11,11]
		{
			{"2","0","11-2","2","5","2","0","0-2","5","0","5"},
			{"2","0","2","0","0","0","2","0","2","0","2"},
			{"3","2","2","2","2","2","3","0","2","2","5"},
			{"2","0","0","0","0","0","2","0","0","0","2"},
			{"2","2","2","2","5","0","2","0","2","0","5"},
			{"0","0","0-1","0","0","0","0","0","2","0","2"},
			{"2","2","11-1","2","5","0","2","2","3","0","5"},
			{"2","0","0","0","2","0","2","0","2","0","2"},
			{"5","0","2","2","3","2","12-1","0","11-3","0-3","5"},
			{"0","0","0","0","0","0","0","0","2","0","0"},
			{"5","2","5","2","5","2","5","2","0","2","5"}
		};
		
		extededTemplate = new string[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}