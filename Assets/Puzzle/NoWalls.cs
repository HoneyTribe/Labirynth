using UnityEngine;
using System;
using System.Collections.Generic;

public class NoWalls : PuzzleTemplate
{
	public NoWalls() :base()
	{
		sizeX = 7;
		sizeZ = 7;
		
		extX = 1;
		extZ = 1;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 14;
		templateSizeZ = 14;
		template = new int[14,14] 
		{
			{5,2,5,2,5,2,5,2,5,2,5,2,5,2},
			{2,0,0,0,2,2,2,2,2,2,2,2,2,2},
			{5,0,5,0,5,2,5,2,5,2,5,2,5,2},
			{2,0,0,0,2,2,2,2,2,2,2,2,2,2},
			{5,2,5,2,5,2,5,2,5,2,5,2,5,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{5,2,5,2,5,2,5,2,5,2,5,2,5,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2},
			{5,2,5,2,5,2,5,2,5,2,5,2,5,2},
			{2,2,2,2,2,2,2,2,2,0,0,0,2,2},
			{5,2,5,2,5,2,5,2,5,0,5,0,5,2},
			{2,2,2,2,2,2,2,2,2,0,0,0,2,2},
			{5,2,5,2,5,2,5,2,5,2,5,2,5,2},
			{2,2,2,2,2,2,2,2,2,2,2,2,2,2},
		};
		
		extededTemplate = new int[sizeZ * 2, sizeX * 2]; 
		init ();
	}
}