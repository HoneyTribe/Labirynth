using UnityEngine;
using System;
using System.Collections.Generic;

public class Lazer2 : PuzzleTemplate
{
	public Lazer2() :base()
	{
		sizeX = 5;
		sizeZ = 6;
		
		extX = 2;
		extZ = 4;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 9;
		templateSizeZ = 11;
		template = new int[11,9]
		{
			{5,2,5,0,5,0,5,2,5},
			{2,2,2,0,2,0,2,2,2},
			{5,2,5,0,4,0,5,2,5},
			{0,0,2,0,0,0,2,0,0},
			{6,2,5,2,2,2,5,2,5},
			{2,2,2,2,2,2,2,2,2},
			{2,2,3,2,5,2,3,2,0},
			{0,0,2,2,2,2,2,0,0},
			{5,0,5,2,3,2,5,0,5},
			{2,0,0,0,2,0,0,0,2},
			{6,2,5,0,0,0,5,2,5}
		};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}