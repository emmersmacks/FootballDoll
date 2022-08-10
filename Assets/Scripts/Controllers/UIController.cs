using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private ProgressBarModule _progressBarModule;
    [SerializeField] private GameActionController _gameActionController;

    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private Text _moneyText;

    private void Start()
    {
        Time.timeScale = 1;
        _gameActionController.OnDead += ShowDeadScreen;
        _gameActionController.OnWin += ShowWinScreen;

    }

    public void SetDefaultValueProgressBar(int maxHealth, int winHealth, int currentHealth)
    {
        _progressBarModule.MaxValue = maxHealth;
        _progressBarModule.SetWinMarkPosition(winHealth);
        UpdateProgressBar(currentHealth);
    }

    public void UpdateProgressBar(int currentHealth)
    {
        _progressBarModule.CurrentValue = currentHealth;
        _progressBarModule.UpdateProgressBar();
    }

    public void UpdateMoneyField(int number)
    {
        _moneyText.text = number.ToString();
    }

    public void ShowDeadScreen()
    {
        Time.timeScale = 0;
        _endScreen.SetActive(true);
    }

    public void ShowWinScreen()
    {
        Debug.Log("AA");
        Time.timeScale = 0;
        _winScreen.SetActive(true);
    }
}
