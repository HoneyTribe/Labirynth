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
					// maze rows, maze columns
					levels.Add(new Level(1,new List<MonsterTemplate>{},15,15,4,4));
					levels.Add(new Level(1,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 2.4f)
						},10,15,8,8));
					levels.Add(new Level(2,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 2.6f)
						},10,15,9,9));
					levels.Add(new Level(2,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 2.8f),
							new MonsterTemplate("Standard", 2.8f)
						},10,15,9,9));
					levels.Add(new Level(2,new List<MonsterTemplate>{
							new MonsterTemplate("Flying", 2.0f)
						},10,10,8,8));
					levels.Add(new Level(3,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.0f),
							new MonsterTemplate("Flying", 2.4f)
						},10,15,9,9));
					levels.Add(new Level(4,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.4f),
							new MonsterTemplate("Standard", 3.4f),
							new MonsterTemplate("Flying", 2.0f)
						},10,10,9,9));
					levels.Add(new Level(4,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f)
						},5,5,9,9));
					levels.Add(new Level(5,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.8f),
							new MonsterTemplate("Standard", 3.8f),
							new MonsterTemplate("Standard", 3.8f),
							new MonsterTemplate("Flying", 2.2f)
						},5,10,9,9));
					levels.Add(new Level(5,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Flying", 2.4f)
						},5,20,9,9));
				}

				public List<Level> getLevels()
				{
					return levels;
				}
		}
}

