using UnityEngine;
using System.Collections.Generic;

public interface LevelSetup  {

	List<Action> Setup(GameObject mainCamera, GameObject player1);
}
