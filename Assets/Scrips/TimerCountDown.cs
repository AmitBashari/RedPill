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
    public float LastSeconds = 25f;

    private float _elapsedTime = 0f;
    private bool _IsLastSeconds = false;

    private void Start()
    {
        _IsLastSeconds = false;
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

        Debug.Log((Duration - _elapsedTime));

        if ((Duration - _elapsedTime) == LastSeconds)
        {
            //_IsLastSeconds = true;
            IntenseTimerSound.Play();
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

        PlayTImerSounds();
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

    public void PlayTImerSounds()
    {
        TimerSound.Play();
        
        if (_IsLastSeconds == true)
        {
            Debug.Log("I play Intense");
            //IntenseTimerSound.Play();
        }
    }

    public void StopTimeSounds()
    {
        TimerSound.Stop();
        IntenseTimerSound.Stop();
    }

}
