using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowScript : MonoBehaviour
{
    void Update() {
        if (StateManager.playerPosition != null) {
            Vector3 newPos = new Vector3(StateManager.playerPosition.x + 0.1f, StateManager.playerPosition.y, StateManager.playerPosition.z);
            transform.position = newPos;
        }
    }
}
