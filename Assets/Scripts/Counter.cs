using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _count = 0;
    private bool _isWork = true;
    private Coroutine _countingCoroutine = null;
    private bool _isCounting = false;

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

    public void StartCounting()
    {
        if (_isCounting == false)
        {
            _isCounting = true;
            _countingCoroutine = StartCoroutine(CountCoroutine());
        }
    }

    public void StopCounting()
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
            yield return new WaitForSeconds(0.5f);
            Increment();
        }
    }

    public void Increment()
    {
        _count++;
        Changed?.Invoke(_count);
    }
}