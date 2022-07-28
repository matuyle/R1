using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureButton : MonoBehaviour
{
    public int buttonId = 0;
    float maxY;
    private void Awake() {
        maxY = transform.position.y;   
    }

    private void Update() {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        if (transform.position.y > maxY) transform.position = new Vector3(transform.position.x, maxY, transform.position.z); 
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "PressureButton") {
            EventManager.OnPressureButtonPushed(buttonId);
        }
    }
}
