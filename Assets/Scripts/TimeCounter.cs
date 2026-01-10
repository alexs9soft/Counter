using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay;
    [SerializeField] private int _amount;

    private Coroutine _coroutine;
    private bool _isWork = false;

    private void Start()
    {
        _text.text = "";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isWork == false)
            {
                _coroutine = StartCoroutine(CountTimer());
                _isWork = true;
            }
            else
            {
                StopCoroutine(_coroutine);
                _isWork = false;
            }
        }
    }

    private IEnumerator CountTimer()
    {
        var wait = new WaitForSeconds(_delay);

        for (int i = _amount; i < int.MaxValue; i++)
        {
            WriteDisplay(i);
            _amount++;

            yield return wait;
        }
    }

    private void WriteDisplay(int count)
    {
        _text.text = count.ToString("");
    }
}
