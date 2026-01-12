using UnityEngine;

public class InputReader : MonoBehaviour
{
    private bool _isWork;

    public bool GetIsWork() => GetBoolAsTrigger(ref _isWork);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isWork = true;
        }
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
