using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameActionController : MonoBehaviour
{
    [SerializeField] private TriggerModule _gateTrigger;
    [SerializeField] private List<ColliderModule> _playerTriggers;

    [SerializeField] private TimerModule _timer;
    [SerializeField] private DataController _dataController;

    [SerializeField] private float _winTimeInSeconds;

    private bool _canWin = false;

    public Action OnDead = delegate { };
    public Action OnWin; //= delegate { Debug.Log("Win"); };

    private void Start()
    {
        foreach(var i in _playerTriggers)
        {
            i.CollisionEnter += OnPlayerTriggerEnter;
        }
        
        _timer.OnTimerEnd = OnEndTimer;
        _gateTrigger.TriggerEnter += OnGateTriggerEnter;
    }

    private void Update()
    {
        if (!_canWin && _timer.TimerIsStart)
        {
            _timer.StopTimer();
        }
    }

    

    private void OnEndTimer()
    {
        OnWin();
    }

    private void OnGateTriggerEnter(Collider collider)
    {
        if (collider.transform.GetComponent<DefaultBall>() != null)
        {
            _dataController.DamageHealth(1);
            Destroy(collider.gameObject);
        }

        CheckStates();
    }

    

    private void OnPlayerTriggerEnter(Collision collider)
    {
        var ballScript = collider.transform.GetComponent<Ball>();
        if (ballScript != null)
        {
            if(!ballScript.IsPlayerTouch)
            {
                if (ballScript is DefaultBall)
                {
                    ballScript.IsPlayerTouch = true;
                    _dataController.AddHealth(1);
                }
                else if(ballScript is BombBall)
                {
                    _dataController.DamageHealth(5);
                    Destroy(ballScript.gameObject);
                }
                else if(ballScript as MoneyBall)
                {
                    _dataController.AddMoney(10);
                    Destroy(ballScript.gameObject);
                }

                CheckStates();
            }
            
        }
    }

    private void CheckStates()
    {
        CheckWin();
        CheckDead();
    }

    private void CheckWin()
    {
        if (_dataController.CurrentHealth >= _dataController._winHealth)
        {
            _canWin = true;
            _timer.StartTimer(_winTimeInSeconds);
        }
        else
        {
            _canWin = false;
            _timer.StopTimer();
        }
    }

    private void CheckDead()
    {
        if (_dataController.CurrentHealth < 0)
        {
            OnDead();
        }
    }
}
