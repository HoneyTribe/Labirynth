using UnityEngine;
using System;

public interface Puzzle
{
	string[,] getGrid();
	void create();
	void finish();
}


