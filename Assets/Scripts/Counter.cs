using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private int _amount;

    private InputReader _reader;
    private Coroutine _coroutine;
    private bool _isWork;

    public event Action AmountChanged;

    public int GetAmountTimer()
    {
        return _amount;
    }

    private void Start()
    {
        _reader = GetComponent<InputReader>();
        _isWork = false;
    }

    private void Update()
    {
        if (_reader.GetIsWork())
        {
            if (_isWork == false)
            {
                _coroutine = StartCoroutine(CountTimer());
                _isWork = true;
            }
            else if (_isWork == true && _coroutine != null)
            {
                StopCoroutine(_coroutine);
                _isWork = false;
            }
        }
    }

    private IEnumerator CountTimer()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            AmountChanged?.Invoke();
            _amount++;

            yield return wait;
        }
    }
}
