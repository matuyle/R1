using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.onPressureButtonE += OnPressureButtonPushed;
    }

    private void OnDestroy() {
        EventManager.onPressureButtonE -= OnPressureButtonPushed;
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }

    void OnPressureButtonPushed(int buttonId) {
        if (buttonId == 1) {
            foreach (Transform child in transform) {
                child.gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
