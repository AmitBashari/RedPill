using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject achievementButton;
    public GameObject creditsButton;
    public GameObject quitButton;

    public GameObject IntroImages;
    public AudioClip IntroVoice;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        /*if (Input.GetKeyDown("escape"))
            Application.Quit();*/

    }

    public void Intro()
    {
        achievementButton.SetActive(false);
        creditsButton.SetActive(false);
        quitButton.SetActive(false);

        IntroImages.SetActive(true);
        _audioSource.Play();

        Invoke("StartGame", _audioSource.clip.length);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoAchievements()
    {
        SceneManager.LoadScene("Achievements");
    }

    public void goCredits()
    {
        SceneManager.LoadScene("CreditsUI");
        CreditsManager.EnteredFromMainMenu = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
