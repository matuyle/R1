using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (StateManager.playerPosition != null) {
            Vector3 newPos = new Vector3(StateManager.playerPosition.x, StateManager.playerPosition.y , StateManager.playerPosition.z);
            transform.position = newPos;
        }
    }
}
