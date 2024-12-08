using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _count = 0;
    private float _timeForWait = 0.5f;
    private bool _isWork = true;
    private Coroutine _countingCoroutine;
    private bool _isCounting;

    public event Action<float> Changed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {
                StopCounting();
            }
            else
            {
                StartCounting();
            }
        }
    }

    private void StartCounting()
    {
        if (_isCounting == false)
        {
            _isCounting = true;
            _countingCoroutine = StartCoroutine(CountCoroutine());
        }
    }

    private void StopCounting()
    {
        if (_isCounting)
        {    
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
            _isCounting = false;
        }
    }

    private IEnumerator CountCoroutine()
    {
        while (_isWork)
        {
            yield return new WaitForSeconds(_timeForWait);
            Increase();
        }
    }

    public void Increase()
    {
        _count++;
        Changed?.Invoke(_count);
    }
}