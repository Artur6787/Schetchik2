using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public float Count => _count;
    private float _count = 0;
    bool _isWork = true;
    public bool IsCounting => _isCounting;
    private Coroutine countingCoroutine = null;
    private bool _isCounting = false;
    public event Action<float> Changed;

    public void StartCounting()
    {
        if (_isCounting == false)
        {
            _isCounting = true;
            countingCoroutine = StartCoroutine(CountCoroutine());
        }
    }

    public void StopCounting()
    {
        if (_isCounting)
        {
            StopCoroutine(countingCoroutine);
            countingCoroutine = null;
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
