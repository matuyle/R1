using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score = 0;
    bool stopWatchActive = false;
    float currentTime;
    public Text currentTimeText;

    // Start is called before the first frame update
    private void Start()
    {
        EventManager.onGameEndE += StopStopWatch;
        EventManager.onPauseE += OnPause;
        EventManager.onPointTakenE += OnPointTaken;
        stopWatchActive = true;
        currentTime = 0;
    }

    private void OnDestroy() {
        EventManager.onPointTakenE -= OnPointTaken;
        EventManager.onGameEndE -= StopStopWatch;
        EventManager.onPauseE -= OnPause;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopWatchActive == true) {
            currentTime += Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString(); 
    }

    public void StartStopWatch() {
        stopWatchActive = true;
    }

    public void StopStopWatch() {
        stopWatchActive = false;
    }

    void OnPointTaken(int id) { 

    }

    void OnPause(bool isPaused) {
        stopWatchActive = !isPaused;
    }
}
