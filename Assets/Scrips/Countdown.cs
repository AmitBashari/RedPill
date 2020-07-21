using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Countdown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 30f;
    public bool timerOn;
    public GameObject choices = null;
    public Image redTimeBar;
    public GameObject timeBarUI;
    Animation anim; 

  
    [SerializeField] TextMeshProUGUI countDownText;

    
    // Start is called before the first frame update
    void Start()
    {
        timerOn = false;
        currentTime = startingTime;
        //countDownText.fontSize = 18;
        countDownText.GetComponent<TextMeshProUGUI>().fontSize = 50;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameObject.FindWithTag("Choices") != null)
        {
            choices = GameObject.FindWithTag("Choices");
           
        }
        else
        {
            choices = null;
        }

        if (choices != null)
        {
            timerOn = true;
            
        }

        else
        {
            timerOn = false;

        }

        /*choices = GameObject.FindGameObjectsWithTag("Choices");

        if (choices == null)
        {
            timerOn = true;
        }
        else
        {
            timerOn = false;
        }
            
    */
        if (timerOn == true)
        {
            currentTime -= 1 * Time.deltaTime;
            redTimeBar.fillAmount = currentTime / startingTime;




            /*
            // Causes to bar to blink 
            timeBarUI.SetActive(false);

            StartCoroutine(Bink(0.1f));
            IEnumerator Bink(float time)
            {
                yield return new WaitForSeconds(time);
                timeBarUI.SetActive(true);
               
            }
         */

        }
        else
        {
        }

        
     


        countDownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);         
        }

      
        //if (currentTime >= 10.0f) { countDownText.color = new Color32(255, 255, 255, 255); }
        //if (currentTime < 10.0f) { countDownText.color = new Color32(255, 0, 0, 255); }

    }


}
