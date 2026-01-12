using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        if (_counter != null)
            _counter.AmountChanged += WriteDisplay;
    }

    private void OnDisable()
    {
        if (_counter != null)
            _counter.AmountChanged -= WriteDisplay;
    }

    private void WriteDisplay(int value)
    {
        _text.text = value.ToString("");
    }
}
