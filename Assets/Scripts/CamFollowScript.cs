using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (StateManager.playerPosition != null) {
            Vector3 newPos = new Vector3(transform.position.x, StateManager.playerPosition.y + 3, transform.position.z);
            transform.position = newPos;
        }
    }
}
