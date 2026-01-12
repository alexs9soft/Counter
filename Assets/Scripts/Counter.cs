using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private int _amount;
    [SerializeField] private InputReader _reader;

    private Coroutine _coroutine;

    public event Action<int> AmountChanged;

    private void Awake()
    {
        _reader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        if (_reader != null)
        {
            _reader.OnMouseClick += StartCount;
        }
    }

    private void OnDisable()
    {
        if (_reader != null)
        {
            _reader.OnMouseClick -= StartCount;
        }
    }

    private void StartCount()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
            return;
        }

        _coroutine = StartCoroutine(CountTimer());
    }

    private IEnumerator CountTimer()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _amount++;
            AmountChanged?.Invoke(_amount);
            
            yield return wait;
        }
    }
}
