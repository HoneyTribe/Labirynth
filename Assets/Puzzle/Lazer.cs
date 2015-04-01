using UnityEngine;
using System;
using System.Collections.Generic;

public class Lazer : PuzzleTemplate
{
	public Lazer() :base()
	{
		sizeX = 6;
		sizeZ = 7;
		
		extX = 2;
		extZ = 2;
		internalSize = sizeZ - 2; 
		
		templateSizeX = 11;
		templateSizeZ = 13;
		template = new int[13,11]
		{
			{2,0,3,0,5,2,5,2,5,2,5},
			{0,0,0,0,0,0,2,2,2,2,2},
			{3,0,5,0,3,0,5,2,5,2,5},
			{0,0,2,0,0,0,2,2,2,2,2},
			{5,2,3,0,5,2,5,2,5,2,5},
			{0,0,2,0,0,0,0,0,0,0,2},
			{2,2,2,2,2,2,5,2,5,0,5},
			{0,0,0,0,2,2,2,2,2,0,2},
			{5,2,5,0,3,2,3,2,2,0,5},
			{2,2,2,0,2,0,0,0,0,0,2},
			{5,2,5,0,5,0,5,2,5,2,5},
			{2,2,2,0,2,0,2,2,2,2,2},
			{5,2,5,2,5,2,5,2,5,2,5}
		};
		
		extededTemplate = new int[sizeZ * 2 -1, sizeX * 2 -1]; 
		init ();
	}
}