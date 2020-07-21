using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class ChoiceScreen : MonoBehaviour
{
    public ChoiceEngine engine;

    public TextMeshProUGUI plot;
    //public TextMeshProUGUI question;
    public Image art;
    public Button FirstChoiceButton;
    public Text FirstChoiceText;
    public Button SecondChoiceButton;
    public Text SecondChoiceText;
    public AudioSource TypingSound;

    private Choice currentChoice;
    private float letterPause = 3f;
    private Animation slideAnim;

    public void Setup(Choice choice)
    {
        currentChoice = choice;
      
        StopAllCoroutines();
        StartCoroutine(TypeSentenceEachLetter(choice.Plot));
        art.sprite = choice.Art;
        if (choice.IsEnding)
        {
            FirstChoiceButton.gameObject.SetActive(false);
            SecondChoiceButton.gameObject.SetActive(false);
            return;
        }
        else
        {
            FirstChoiceText.text = choice.FirstChoice.Name;
            SecondChoiceText.text = choice.SecondChoice.Name;
        }

       
    }


    public void FirstChoiceClicked()
    {
        if (currentChoice.FirstChoice != null)
        {
            engine.LoadChoice(currentChoice.FirstChoice);
        }
    }

    public void SecondChoiceClicked()
    {
        if (currentChoice.SecondChoice != null)
        {
            engine.LoadChoice(currentChoice.SecondChoice);
        }
    }


    private IEnumerator TypeSentenceEachLetter(string sentence)
    {
        TypingSound.Play();

        plot.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            yield return new WaitForSeconds(letterPause * Time.deltaTime);
            plot.text += letter;
           
        }

        TypingSound.Stop();

    }


}




