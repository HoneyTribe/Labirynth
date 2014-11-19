using UnityEngine;
using System;
using System.Collections.Generic;

public class Decoy2 : PuzzleTemplate
{
	public Decoy2() :base()
	{
		sizeX = 5;
		sizeZ = 5;
		
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 9;
		templateSizeZ = 9;
		template = new int[9, 9] 
		{  
			{0,2,5,2,2,2,5,2,0},
			{2,0,0,0,0,0,0,0,2},
			{5,0,5,2,4,2,5,0,5},
			{2,0,0,0,0,0,0,0,2},
			{2,2,2,2,6,2,2,2,2},
			{2,0,0,0,0,0,0,0,2},
			{5,0,5,2,2,2,5,0,5},
			{2,0,0,0,0,0,0,0,2},
			{2,2,5,2,2,2,5,2,2}						
		};
		
		extededTemplate = new int[sizeZ * 2 -1 , sizeX * 2 -1]; 
		init ();
	}
}