using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpinner : MonoBehaviour
{
    Vector3 center;
    bool isWheelSpinning;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.onPlayerInZoneE += OnPlayerInZone;
        center = new Vector3(-1.7f, 32.92f, 0);
    }

    private void OnDestroy() {
        EventManager.onPlayerInZoneE -= OnPlayerInZone;
    }

    void OnPlayerInZone(bool isInZone) {
        isWheelSpinning = isInZone;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWheelSpinning) 
            transform.RotateAround(center, Vector3.forward, 20 * Time.deltaTime);
    }
}
