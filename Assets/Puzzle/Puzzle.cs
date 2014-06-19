using UnityEngine;
using System;

public interface Puzzle
{
	int[,] getGrid();
	void create();
	void finish();
}


