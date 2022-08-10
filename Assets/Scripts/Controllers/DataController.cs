using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    [SerializeField] private UIController _uiController;

    [SerializeField] public int _winHealth;
    [SerializeField] public int _maxHealth;
    [SerializeField] private int _startHealth;

    public int CurrentHealth { get; private set; }
    public int CurrentMoney { get; private set; }

    private void Start()
    {
        CurrentHealth = _startHealth;
        _uiController.SetDefaultValueProgressBar(_maxHealth, _winHealth, CurrentHealth);
    }

    public void AddHealth(int number)
    {
        CurrentHealth += number;
        _uiController.UpdateProgressBar(CurrentHealth);
    }

    public void DamageHealth(int number)
    {
        CurrentHealth -= number;
        _uiController.UpdateProgressBar(CurrentHealth);
    }

    public void AddMoney(int number)
    {
        CurrentMoney += number;
        _uiController.UpdateMoneyField(CurrentMoney);
    }
}
