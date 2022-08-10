using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarModule : MonoBehaviour
{
    [SerializeField] private Image _progressBarImage;
    [SerializeField] private RectTransform _WinMarkContainer;
    [SerializeField] private RectTransform _WinMarkObject;

    internal float MaxValue;
    internal float CurrentValue;

    public void UpdateProgressBar()
    {
        var percent = 100 / MaxValue;
        var fillNumber = (percent * CurrentValue) * 0.01f;
        _progressBarImage.fillAmount = fillNumber;
    }

    public void SetWinMarkPosition(int markValue)
    {
        var percent = _progressBarImage.rectTransform.rect.height / MaxValue;
        _WinMarkObject.localPosition = new Vector3(0, percent * markValue, 0);
    }
}
