using UnityEngine;
using System;

public interface Puzzle
{
	int[,] getGrid();
	Entrance getEntrance();
}


