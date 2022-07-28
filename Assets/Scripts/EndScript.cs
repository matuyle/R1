using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            transform.parent.gameObject.SetActive(false);
            EventManager.OnGameEnd();
        }
    }        
}
