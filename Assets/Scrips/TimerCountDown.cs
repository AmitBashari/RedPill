using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public float Duration = 30f;
    public UnityEvent OnTimerFinished;
    public Image SecondsImage;
    public AudioSource TimerSound;

    private float _elapsedTime = 0;

    private void Start()
    {
        ResetUI();
    }

    private void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;

        Text.SetText((Duration - _elapsedTime).ToString("F0"));

        SecondsImage.fillAmount += 1 * Time.deltaTime;

        if (SecondsImage.fillAmount == 1f && _elapsedTime <=30)
        {
            SecondsImage.fillAmount = 0f;
        }


        if (_elapsedTime >= Duration)
        {
            enabled = false;
            OnTimerFinished?.Invoke();

        }
    }

    public void Pause()
    {
        enabled = false;
        TimerSound.Stop();
    }

    public void Continue()
    {

        enabled = true;

        TimerSound.Play();
    }

    public void Restart()
    {

        ResetUI();
        TimerSound.Stop();
        enabled = false;

    }

    public void ElapsedTimeZero()
    {

        ResetUI();

        TimerSound.Stop();
    }

    public void ResetUI()
    {
        _elapsedTime = 0;
        GetComponent<TextMeshProUGUI>().text = Duration.ToString();
        SecondsImage.fillAmount = 0f;
    }

}
