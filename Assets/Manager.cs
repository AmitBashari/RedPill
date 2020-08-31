using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public GameObject IntroImages;
    public AudioClip IntroVoice;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Input.GetKeyDown("escape"))
            Application.Quit();

    }

    public void Intro()
    {
        IntroImages.SetActive(true);
        _audioSource.Play();

        Invoke("StartGame", _audioSource.clip.length*0.3f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
