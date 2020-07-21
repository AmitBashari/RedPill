using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TImer : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public float Duration = 30;
    public UnityEvent OnTimerFinished;

    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        Text.SetText((Duration - _elapsedTime).ToString());
        
        if (_elapsedTime >= Duration)
        {
            enabled = false;
            OnTimerFinished?.Invoke();
            Text.SetText("0");
        }
    }

    public void Pause()
    {
        enabled = false;
    }

    public void Continue()
    {
        enabled = true;
    }

    public void Restart()
    {
        _elapsedTime = 0;
        enabled = true;

    }
}
