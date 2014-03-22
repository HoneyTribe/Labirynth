using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class LevelDefinition
		{
				List<Level> levels = new List<Level> ();

				public LevelDefinition ()
				{
					levels.Add(new Level(1,1));
					levels.Add(new Level(2,1));
					levels.Add(new Level(2,2));
					levels.Add(new Level(3,2));
					levels.Add(new Level(2,3));
					levels.Add(new Level(3,3));
					levels.Add(new Level(4,3));
					levels.Add(new Level(2,4));
					levels.Add(new Level(3,4));
					levels.Add(new Level(4,4));
				}

				public List<Level> getLevels()
				{
					return levels;
				}
		}
}

