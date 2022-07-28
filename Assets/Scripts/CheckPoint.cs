using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int id;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            EventManager.OnPointTaken(id);
        }
    }
}
