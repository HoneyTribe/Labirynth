using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
		public class LevelDefinition
		{
				private static int firstLevelWithDevice = 1;
				private static int firstLevelWithJumpItem = 3;

				List<Level> levels = new List<Level> ();

				public LevelDefinition ()
				{
					// keys, monsters, time of 1st monster appear, time of subsequent mosnters,
					// maze rows, maze columns

				// 2 player levels	
				/*
					levels.Add(new Level(1,new List<MonsterTemplate>{},15,15,6,6));
					levels.Add(new Level(1,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 2.4f)
						},5,15,7,7));
					levels.Add(new Level(2,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 2.6f),
							new MonsterTemplate("Standard", 2.6f)
						},5,6,8,8));
					levels.Add(new Level(2,new List<MonsterTemplate>{},10,15,6,6));
					levels.Add(new Level(2,new List<MonsterTemplate>{
							new MonsterTemplate("Flying", 2.0f)
						},5,6,7,7));
					levels.Add(new Level(3,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.0f),
							new MonsterTemplate("Flying", 2.4f)
						},5,6,8,8));
					levels.Add(new Level(4,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.4f),
							new MonsterTemplate("Standard", 3.4f),
							new MonsterTemplate("Flying", 2.0f)
						},5,6,9,9));
					levels.Add(new Level(4,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f)
						},5,6,9,9));
					levels.Add(new Level(5,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.8f),
							new MonsterTemplate("Flying", 2.2f),
							new MonsterTemplate("Standard", 3.8f),
							new MonsterTemplate("Flying", 3.8f)
						},5,10,10,10));
					levels.Add(new Level(5,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Flying", 2.4f),
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Flying", 2.4f)
						},5,10,10,10));
				*/

				// 3 player levels	

					levels.Add(new Level(2,new List<MonsterTemplate>{},15,15,6,6));
					levels.Add(new Level(2,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 2.4f)
						},5,15,7,7));
					levels.Add(new Level(3,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 2.6f),
							new MonsterTemplate("Standard", 2.6f)
						},5,6,8,8));
					levels.Add(new Level(3,new List<MonsterTemplate>{},10,15,6,6));
					levels.Add(new Level(3,new List<MonsterTemplate>{
							new MonsterTemplate("Flying", 2.0f)
						},5,6,7,7));
					levels.Add(new Level(4,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.0f),
							new MonsterTemplate("Flying", 2.4f)
						},5,6,8,8));
					levels.Add(new Level(5,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.4f),
							new MonsterTemplate("Standard", 3.4f),
							new MonsterTemplate("Flying", 2.0f)
						},5,6,9,9));
					levels.Add(new Level(5,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f),
							new MonsterTemplate("Standard", 3.6f)
						},5,6,9,9));
					levels.Add(new Level(6,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 3.8f),
							new MonsterTemplate("Flying", 2.2f),
							new MonsterTemplate("Standard", 3.8f),
							new MonsterTemplate("Flying", 3.8f)
						},5,10,10,10));
					levels.Add(new Level(6,new List<MonsterTemplate>{
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Flying", 2.4f),
							new MonsterTemplate("Standard", 4.0f),
							new MonsterTemplate("Flying", 2.4f)
						},5,10,10,10));

				}

				public List<Level> getLevels()
				{
					return levels;
				}

				public int getFirstLevelWithDevice()
				{
					return firstLevelWithDevice;
				}

				public int getFirstLevelWithJumpItem()
				{
					return firstLevelWithJumpItem;
				}
		}
}

