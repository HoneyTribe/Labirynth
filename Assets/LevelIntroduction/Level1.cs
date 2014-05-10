using UnityEngine;
using System.Collections.Generic;

public class Level1 : LevelSetup {

	public List<Action> Setup()
	{
		List<Action> actions = new List<Action>();

		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(0, "BFFOD will be a both a 1 player stealth game and a local multiplayer co-op. The multilplayer aspect will have 2 to 4 people co-operating as part of a team."));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(1, "There’s a great tension as each player relies on the others. Then when a level ends by either winning or losing there’s a very visible release of tension with either celebrations or amused commiserations."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(0, "Let's play then!"));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(1, "But I don't know what I should do..."));
		actions.Add(new MoveCameraAction("Key"));
		actions.Add(new TextAction(4, "Enter the maze and collect all keys."));
		actions.Add(new MoveCameraAction("Player1"));
		actions.Add(new TextAction(0, "But it is dark. Help us master!"));
		actions.Add(new CreateMonsterAction("Standard"));
		actions.Add(new MoveCameraAction("Monster"));
		actions.Add(new TextAction(4, "And I forgot to tell you. Watch out the monster!"));
		actions.Add(new MoveCameraAction("Player2"));
		actions.Add(new TextAction(1, "We're gonna die..."));
		actions.Add(new MoveCameraAction("Lighthouse"));
		actions.Add(new TextAction(4, "I prepared for you a lighthouse that will show you the way."));

		return actions;
	}


}
