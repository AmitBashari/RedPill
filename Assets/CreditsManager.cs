using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public Text Headline;
    public Text FunnyQuote;
    public Text Names;

    public Credit[] CreditArray;

    public GameObject BackButton;

    public static bool EnteredFromMainMenu = true;

    private float _slidesDelay = 4f;
    private float _letterPause = 0.1f;
    private float _contentPause = 0.8f;

    private void Start()
    {
        if (EnteredFromMainMenu == false)
        {
            BackButton.SetActive(false);
        }

        Headline.text = " ";
        StartCoroutine(LoadCredits());
    }

    public IEnumerator LoadCredits()
    {
        foreach (Credit credit in CreditArray)
        {

            Headline.text = " ";
            Names.text = " ";
            FunnyQuote.text = " ";

            foreach (char letter in credit.Headline.ToCharArray())
            {
                Headline.text += letter;
                yield return new WaitForSeconds(_letterPause);
            }

            foreach (char letter in credit.Names.ToCharArray())
            {
                Names.text += letter;
                yield return new WaitForSeconds(_letterPause);
            }

            foreach (char letter in credit.FunnyQuote.ToCharArray())
            {
                FunnyQuote.text += letter;
                yield return new WaitForSeconds(_letterPause);
            }

            yield return new WaitForSeconds(_slidesDelay);

        }
            BackButton.SetActive(true);

    }

    public void goMainMenu()
    {
        SceneManager.LoadScene(0);

    }
}
