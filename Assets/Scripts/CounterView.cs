using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _displayText;
    [SerializeField] private Counter _counterInstance;

    private void OnEnable()
    {
        _counterInstance.Changed += UpdateDisplayText;
    }

    private void OnDisable()
    {
        _counterInstance.Changed -= UpdateDisplayText;
    }

    private void UpdateDisplayText(float currentCount)
    {
        if (_displayText != null)
        {
            _displayText.text = "Count: " + currentCount;
        }
    }
}