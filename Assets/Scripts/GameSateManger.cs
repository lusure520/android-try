using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSateManger : MonoBehaviour {

	public void PauseAndContinue()
    {
        EggAction._instance.transformGameState();
    }
}
