using UnityEngine;
using System.Collections.Generic;

public class Labirynth
{
	public const int WALL = 0;
	public const int MAZE = 1;
	public const int GRID = 2;

	int[,] maze;
	Vector2 start;
	int sizeX;
	int sizeY;

	List<KeyPosition> keys = new List<KeyPosition> ();

	public Labirynth (int sizeX, int sizeY, int[,] grid)
	{
		this.sizeX = sizeX;
		this.sizeY = sizeY;
		this.maze = new int[sizeX * 2 + 1, sizeY * 2 + 1];
		if (grid != null)
		{
			this.maze = grid;
		}

		int entrance =  Random.Range(1, sizeX-1);
		this.start = new Vector2(1 + 2 * entrance, 2*sizeY - 1);
			
		//make the entrance wider
		makeVisited (new Vector2 (start.x, start.y));;
		makeVisited (new Vector2 (start.x, start.y + 1));
		makeVisited (new Vector2 (start.x - 1, start.y));
		makeVisited (new Vector2 (start.x - 1, start.y + 1));
		makeVisited (new Vector2 (start.x - 2, start.y));
		makeVisited (new Vector2 (start.x - 2, start.y + 1));
		makeVisited (new Vector2 (start.x + 1, start.y));
		makeVisited (new Vector2 (start.x + 1, start.y + 1));
		makeVisited (new Vector2 (start.x + 2, start.y));
		makeVisited (new Vector2 (start.x + 2, start.y + 1));
	}

	public void makeVisited(Vector2 pos)
	{
		this.maze[(int) pos.x, (int) pos.y] = Labirynth.MAZE;
	}

	public Move convertToMove(int input)
	{
		bool[] bits = new bool[2];
		for (int i = 1; i >= 0; i--) {
			bits[i] = (input & (1 << i)) != 0;
		}
		
		if (bits[0] == false)
		{
			return new Move(new Vector2(bits[1] == false ? -1 : 1, 0),
			                new Vector2(bits[1] == false ? -2 : 2, 0));
		}
		else
		{
			return new Move(new Vector2(0, bits[1] == false ? -1 : 1),
			                new Vector2(0, bits[1] == false ? -2 : 2));   			
		}
	}

	public List<Move> findOptions(Vector2 pos)
	{
		List<Move> options = new List<Move>();
		
		for (int i = 0; i < 4; i++)
		{
			Move move = convertToMove(i);
			if  ((pos.x + move.getNewPos().x > 0) && (pos.x + move.getNewPos().x < sizeX * 2) &&
			     (pos.y + move.getNewPos().y > 0) && (pos.y + move.getNewPos().y < sizeY * 2) &&
			     (maze[(int) (pos.x + move.getNewPos().x), (int) (pos.y + move.getNewPos().y)] == Labirynth.WALL))
			{
				options.Add(move);
			}
		}
		
		return options;
	}

	public List<Move> findOptionsToMove(int[,] m, Vector2 pos)
	{
		List<Move> options = new List<Move>();
		
		for (int i = 0; i < 4; i++)
		{
			Move move = convertToMove(i);
			if  ((pos.x + move.getNewPos().x > 0) && (pos.x + move.getNewPos().x < sizeX * 2) &&
			     (pos.y + move.getNewPos().y > 0) && (pos.y + move.getNewPos().y < sizeY * 2) &&
	    		 (m[(int) (pos.x + move.getWall().x), (int) (pos.y + move.getWall().y)] == Labirynth.MAZE))
			{
				options.Add(move);
			}
		}
		
		return options;
	}

	public Vector2 findCellWithOptions()
	{
		for (int y = sizeY * 2 - 1; y >= 1; y -= 2)
		{
			for (int x = 1; x < sizeX * 2 + 1; x += 2)
			{
				if (maze[x, y] == Labirynth.MAZE)
				{
					Vector2 temp = new Vector2(x, y);
					if (findOptions(temp).Count != 0)
					{
						return temp;
					}
				}
			}
		}
		
		return Vector2.zero;
	}

	public void generate()
	{
		Vector2 curr = start;
		List<Move> options;

		while(!findCellWithOptions().Equals (Vector2.zero))
		{	
			options = findOptions(curr);
			if (options.Count == 0)
			{
				print (maze);
				keys.Add(new KeyPosition(curr, (int) Vector2.Distance(curr, start)));
				curr = findCellWithOptions();
				continue;
			}
			int random =  Random.Range(0, options.Count);
			Move move = options[random];
			makeVisited(curr + move.getWall());
			makeVisited(curr + move.getNewPos());
			curr = curr + move.getNewPos();
		}	
		keys.Add(new KeyPosition(curr, (int) Vector2.Distance(curr, start)));
	}

	public int getWalls(int x, int y)
	{
		return maze[x, y];
	}

	public List<KeyPosition> getKeys()
	{
		return keys;
	}

	public Vector2 getJumps()
	{
		Vector2 position = Vector2.zero;
		while (position.Equals(Vector2.zero))
		{
			position = new Vector2 (Random.Range (0, sizeX) * 2 + 1, Random.Range (0, 4) * 2 + 1);
			foreach (KeyPosition keyPosition in getKeys())
			{
				if (keyPosition.Equals(position))
				{
					position = Vector2.zero;
				}
			}
		}
		return position;
	}

	public Vector2 getStart()
	{
		return start;
	}

	public void print(int[,] m)
	{
		string line = "";
		for (int y = 0; y < sizeY * 2 + 1; y++)					{
			
			for (int x = 0; x < sizeX * 2 + 1; x++)
			{
				line = line + m[x,y];
			}
			//Debug.Log(line);
			line = line + System.Environment.NewLine;
		}
		line = line + " ";
	}
}