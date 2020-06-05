using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Countdown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;
    [SerializeField] TextMeshProUGUI countDownText;
    public GameObject Q1; 
    public GameObject victoryScreen;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        //countDownText.fontSize = 18;
        countDownText.GetComponent<TextMeshProUGUI>().fontSize = 50;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if (currentTime <= 1 && Q1 == isActiveAndEnabled)
        {
            currentTime = 1;
            victoryScreen.SetActive(true);
            Q1.SetActive(false);
            countDownText.fontSize = 0;
            
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);         
        }

        if (currentTime >= 10.0f) { countDownText.color = new Color32(255, 255, 255, 255); }
        if (currentTime < 10.0f) { countDownText.color = new Color32(255, 0, 0, 255); }

    }

   
}
