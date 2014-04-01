using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class LevelDefinition
		{
				List<Level> levels = new List<Level> ();

				public LevelDefinition ()
				{
					// keys, monsters, time of 1st monster appear, time of subsequent mosnters,
					// monster speed, maze rows, maze columns
					levels.Add(new Level(1,0,15,15,2.4f,8,8));
					levels.Add(new Level(1,1,15,15,2.4f,8,8));
					levels.Add(new Level(2,1,15,15,2.6f,9,9));
					levels.Add(new Level(2,2,10,15,2.8f,9,9));
					levels.Add(new Level(2,3,10,10,3.0f,9,9));
					levels.Add(new Level(3,3,10,10,3.2f,9,9));
					levels.Add(new Level(4,3,10,10,3.4f,9,9));
					levels.Add(new Level(4,4,5,5,3.6f,9,9));
					levels.Add(new Level(5,4,5,10,3.8f,9,9));
					levels.Add(new Level(5,5,5,20,4.0f,9,9));
				}

				public List<Level> getLevels()
				{
					return levels;
				}
		}
}

