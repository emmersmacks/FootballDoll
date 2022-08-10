using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerModule : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    private float _currentTimerNumber = 0;
    internal bool TimerIsStart = false;

    public Action OnTimerEnd = delegate { };

    private void Update()
    {
        if (TimerIsStart)
        {
            _currentTimerNumber -= Time.deltaTime;

            if (_timerText != null)
                _timerText.text = ((int)_currentTimerNumber).ToString();

            if (_currentTimerNumber <= 0)
            {
                TimerIsStart = false;
                OnTimerEnd();
            }
        }
    }

    public void StartTimer(float timeInSeconds)
    {
        if(!TimerIsStart)
            _currentTimerNumber = timeInSeconds;

        TimerIsStart =true;
    }

    public void StopTimer()
    {
        TimerIsStart = false;
        _timerText.text = "0";

    }
}
