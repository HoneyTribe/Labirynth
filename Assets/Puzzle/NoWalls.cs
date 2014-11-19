using UnityEngine;
using System;
using System.Collections.Generic;

public class NoWalls : PuzzleTemplate
{
	public NoWalls() :base()
	{
		sizeX = 7;
		sizeZ = 7;
		
		extX = 2;
		extZ = 2;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 13;
		templateSizeZ = 13;
		template = new int[13,13] 
		{
			{5,2,5,2,5,2,5,2,5,2,5,2,5},
			{2,0,0,0,2,2,2,2,2,2,2,2,2},
			{5,0,5,0,5,2,5,2,5,2,5,2,5},
			{2,0,0,0,2,2,2,2,2,2,2,2,2},
			{5,2,5,2,5,2,5,2,5,2,5,2,5},
			{2,2,2,2,2,2,2,2,2,2,2,2,2},
			{5,2,5,2,5,2,5,2,5,2,5,2,5},
			{2,2,2,2,2,2,2,2,2,2,2,2,2},
			{5,2,5,2,5,2,5,2,5,2,5,2,5},
			{2,2,2,2,2,2,2,2,2,0,0,0,2},
			{5,2,5,2,5,2,5,2,5,0,5,0,5},
			{2,2,2,2,2,2,2,2,2,0,0,0,2},
			{5,2,5,2,5,2,5,2,5,2,5,2,5}
		};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}