using UnityEngine;
using System;
using System.Collections.Generic;

public class Decoy2 : PuzzleTemplate
{
	public Decoy2() :base()
	{
		sizeX = 5;
		sizeZ = 5;
		
		extX = 1;
		extZ = 1;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 10;
		templateSizeZ = 10;
		template = new int[10,10]
		{
			{0,2,5,2,2,2,5,2,0,2},
			{2,0,0,0,0,0,0,0,2,2},
			{5,0,5,2,4,2,5,0,5,2},
			{2,0,0,0,0,0,0,0,2,2},
			{0,2,5,2,5,2,5,2,2,2},
			{2,0,0,0,6,0,0,0,2,2},
			{5,0,5,2,2,2,5,0,5,2},
			{2,0,0,0,0,0,0,0,2,2},
			{2,2,5,2,2,2,5,2,2,0},
			{2,2,2,2,2,2,2,2,2,2},
		};
		
		extededTemplate = new int[sizeZ * 2, sizeX * 2]; 
		init ();
	}
}