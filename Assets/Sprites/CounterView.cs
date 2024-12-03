using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private Counter _counter;

    private Coroutine _counterCoroutine = null;
    private bool _isCounting = false;
    private bool _isWorck = true;

    private void OnEnable()
    {
        if (_counter != null)
        {
            _counter.OnCountChanged += UpdateCounterText;
        }
    }

    private void OnDisable()
    {
        if (_counter != null)
        {
            _counter.OnCountChanged -= UpdateCounterText;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {
                StopCounter();
            }
            else
            {
                StartCounter();
            }
        }
    }

    private void StartCounter()
    {
        if (_counterCoroutine == null)
        {
            _isCounting = true;
            _counterCoroutine = StartCoroutine(UpdateCounter());
        }
    }

    private void StopCounter()
    {
        if (_counterCoroutine != null)
        {
            StopCoroutine(_counterCoroutine);
            _counterCoroutine = null;
            _isCounting = false;
        }
    }

    private IEnumerator UpdateCounter()
    {
        while (_isWorck)
        {
            yield return new WaitForSeconds(0.5f);
            _counter.Increment();
        }
    }

    private void UpdateCounterText(float currentCount)
    {
        if (_counterText != null)
        {
            _counterText.text = "Count: " + currentCount;
        }
    }
}