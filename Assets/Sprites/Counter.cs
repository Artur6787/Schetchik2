using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<float> OnCountChanged;
    public float Count => _count;
    private float _count = 0;
    
    public void Increment()
    {
        _count++;
        OnCountChanged?.Invoke(_count);
    }
}
