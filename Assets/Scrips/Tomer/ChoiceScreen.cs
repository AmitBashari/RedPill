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
    public Button NextButton;

    private Choice currentChoice;
    private float letterPause = 3f;
    private Animation slideAnim;
    private Choice _nextChoice;

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
            NextButton.gameObject.SetActive(true);
            
        }
        else
        {
            FirstChoiceText.text = choice.FirstChoice.Name;
            SecondChoiceText.text = choice.SecondChoice.Name;
            FirstChoiceButton.gameObject.SetActive(true);
            SecondChoiceButton.gameObject.SetActive(true);
            NextButton.gameObject.SetActive(false);

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

    public void NextClicked()
    {
        if (_nextChoice != null)
        {
            engine.LoadChoice(_nextChoice);
            _nextChoice = null;
        }
        else
        {
            engine.LoadEnd(currentChoice);
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

    public void SetupHint(string hint, Choice nextChoice)
    {
        FirstChoiceButton.gameObject.SetActive(false);
        SecondChoiceButton.gameObject.SetActive(false);
        NextButton.gameObject.SetActive(true);
        _nextChoice = nextChoice;
        StopAllCoroutines();
        StartCoroutine(TypeSentenceEachLetter(hint));
    }


}




