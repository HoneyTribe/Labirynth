using UnityEngine;
using System.Collections.Generic;
namespace AssemblyCSharp
{
		public class Labirynth
		{
				bool[,] maze;
				Vector2 start;
				Vector2 end;
				int sizeX;
				int sizeY;

				public Labirynth (int sizeX, int sizeY)
				{
					this.sizeX = sizeX;
					this.sizeY = sizeY;
					this.maze = new bool[sizeX * 2 + 1, sizeY * 2 + 1];

					int entrance =  Random.Range(1, sizeX-1);
					this.start = new Vector2(1 + 2 * entrance, 2*sizeY - 1);
					this.end = new Vector2(1 + 2 * (sizeX - entrance), 1);
					for (int x=0; x<=sizeX*2; x++)
					{
						makeVisited (new Vector2(x, 2*sizeY - 1));
						makeVisited (new Vector2(x, 2*sizeY));
					}
					//make the entrance wider
					makeVisited (new Vector2(start.x-1, start.y-1));
					makeVisited (new Vector2(start.x-1, start.y-2));
					makeVisited (new Vector2(start.x-2, start.y-1));
					makeVisited (new Vector2(start.x-2, start.y-2));
					makeVisited (new Vector2(start.x+1, start.y-1));
					makeVisited (new Vector2(start.x+1, start.y-2));
					makeVisited (new Vector2(start.x+2, start.y-1));
					makeVisited (new Vector2(start.x+2, start.y-2));
				}

				public void makeVisited(Vector2 pos)
				{
					this.maze[(int) pos.x, (int) pos.y] = true;
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
						     (!maze[(int) (pos.x + move.getNewPos().x), (int) (pos.y + move.getNewPos().y)]))
						{
							options.Add(move);
						}
					}
					
					return options;
				}

				public Vector2 findCellWithOptions()
				{
					for (int y = sizeY * 2 - 3; y >= 1; y -= 2)
					{
						for (int x = 1; x < sizeX * 2 + 1; x += 2)
						{
							if (maze[x, y])
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
						if ((options.Count == 0) || (curr.Equals(end)))
						{
							curr = findCellWithOptions();
							continue;
						}
						int random =  Random.Range(0, options.Count);
						Move move = options[random];
						makeVisited(curr + move.getWall());
						makeVisited(curr + move.getNewPos());
						curr = curr + move.getNewPos();
						print ();
					}	
				}

				public bool getWalls(int x, int y)
				{
					return maze[x, y];
				}

				public void print()
				{
					string line = "";
					for (int y = 0; y < sizeY * 2 + 1; y++)					{
						
						for (int x = 0; x < sizeX * 2 + 1; x++)
						{
							if (this.maze[x,y])
							{
								line = line + "o";
							}
							else
							{
								line = line + "d";
							}
						}
						//Debug.Log(line);
						line = line + System.Environment.NewLine;
					}
					line = line + " ";
				}
	}
}

