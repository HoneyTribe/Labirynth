using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class LevelDefinition
		{
				List<Level> levels = new List<Level> ();

				public LevelDefinition ()
				{
					levels.Add(new Level(1,0,15,15,2.4f,9,9));
					levels.Add(new Level(1,1,15,15,2.4f,9,9));
					levels.Add(new Level(2,1,15,15,2.4f,9,9));
					levels.Add(new Level(2,2,15,15,2.4f,9,9));
					levels.Add(new Level(2,3,15,15,2.4f,9,9));
					levels.Add(new Level(3,3,15,15,2.4f,9,9));
					levels.Add(new Level(4,3,15,15,2.4f,9,9));
					levels.Add(new Level(4,4,15,15,2.4f,9,9));
					levels.Add(new Level(5,4,15,15,2.4f,9,9));
					levels.Add(new Level(5,5,15,15,2.4f,9,9));
				}

				public List<Level> getLevels()
				{
					return levels;
				}
		}
}

