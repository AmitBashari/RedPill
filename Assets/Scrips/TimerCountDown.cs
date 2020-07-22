using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public float Duration = 30;
    public UnityEvent OnTimerFinished;
    public Image SecondsImage;




    private float _elapsedTime = 0;
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        Text.SetText((Duration - _elapsedTime).ToString("F0"));

        SecondsImage.fillAmount -= 1f * Time.deltaTime;

        if (SecondsImage.fillAmount == 0f && _elapsedTime <=30)
        {
            SecondsImage.fillAmount = 1f;
        }


        if (_elapsedTime >= Duration)
        {
            enabled = false;
            OnTimerFinished?.Invoke();
            //Debug.Log("TIme Up");
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

    public void ElapsedTimeZero()
    {

        _elapsedTime = 0;
        Text.SetText("30");
    }

}
