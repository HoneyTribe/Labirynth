using UnityEngine;
using System;
using System.Collections.Generic;

public class Lazer : PuzzleTemplate
{
	public Lazer() :base()
	{
		sizeX = 6;
		sizeZ = 7;
		
		extX = 1;
		extZ = 1;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 12;
		templateSizeZ = 14;
		template = new int[14,12]
		{
			{2,0,3,0,5,2,5,2,5,2,2,0},
			{0,0,0,0,0,0,2,2,2,2,2,2},
			{3,0,5,0,3,0,5,2,5,2,2,0},
			{0,0,0,0,0,0,2,2,2,2,2,2},
			{5,2,5,0,5,2,5,2,5,2,2,0},
			{0,0,2,0,0,0,0,0,0,0,2,2},
			{2,2,2,2,2,2,5,2,5,0,2,2},
			{0,0,0,0,2,2,2,2,2,0,2,2},
			{5,2,5,0,3,2,3,2,2,0,2,2},
			{2,2,2,0,2,0,0,0,0,0,2,2},
			{5,2,5,0,2,0,5,2,5,2,2,2},
			{2,2,2,0,2,0,2,2,2,2,2,2},
			{2,2,2,2,2,2,2,2,2,2,2,2},
			{2,2,2,0,2,0,2,2,2,2,2,2},
		};
		
		extededTemplate = new int[sizeZ * 2, sizeX * 2]; 
		init ();
	}
}