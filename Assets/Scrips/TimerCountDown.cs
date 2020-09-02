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
    public AudioSource IntenseTimerSound;
    public float LastSeconds = 6f;

    private float _elapsedTime = 0f;

    private void Start()
    {
        ResetUI();
        IntenseTimerSound.volume = 0f;
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

        if ((Duration - _elapsedTime <= LastSeconds))
        {
            Debug.Log("I play Intense");
            IntenseTimerSound.volume = 0.6f;
        }
        else
        {
            IntenseTimerSound.volume = 0f;
        }




    }

    public void Pause()
    {
        enabled = false;
        StopTimeSounds();
    }

    public void Continue()
    {

        enabled = true;
        TimerSound.Play();    
    }

    public void Restart()
    {
        ResetUI();
        StopTimeSounds();
        enabled = false;
    }

    public void ElapsedTimeZero()
    {

        ResetUI();
        StopTimeSounds();
    }

    public void ResetUI()
    {
        _elapsedTime = 0;
        GetComponent<TextMeshProUGUI>().text = Duration.ToString();
        SecondsImage.fillAmount = 0f;
    }

    public void StopTimeSounds()
    {
        IntenseTimerSound.volume = 0f;
        TimerSound.Stop();
    }

}
