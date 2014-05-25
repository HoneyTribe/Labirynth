using UnityEngine;
using System;

public interface Puzzle
{
	bool[,] getGrid();
	Entrance getEntrance();
}


