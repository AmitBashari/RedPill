using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

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
    public Choice CurrentChoice;
    public UnityEvent OnTimePause;
    public UnityEvent OnTimeContinue;





    private float letterPause = 3f;
    private Animation slideAnim;
    private Choice _nextChoice;
    private bool _isEnd = false;

    public void Setup(Choice choice)
    {
        CurrentChoice = choice;
      
        StopAllCoroutines();
        StartCoroutine(TypeSentenceEachLetter(choice.Plot));

        art.sprite = choice.Art;

        if (choice.IsEnding)
        {
            FirstChoiceButton.gameObject.SetActive(false);
            SecondChoiceButton.gameObject.SetActive(false);
            NextButton.gameObject.SetActive(true);
            _isEnd = true;
            
        }
        else
        {
            FirstChoiceText.text = choice.FirstChoice.Name;
            SecondChoiceText.text = choice.SecondChoice.Name;
            //FirstChoiceButton.gameObject.SetActive(true);
            //SecondChoiceButton.gameObject.SetActive(true);
            NextButton.gameObject.SetActive(false);
            _isEnd = false;

        }

       
    }


    public void FirstChoiceClicked()
    {
        if (CurrentChoice.FirstChoice != null)
        {
            engine.LoadChoice(CurrentChoice.FirstChoice);
        }
    }

    public void SecondChoiceClicked()
    {
        if (CurrentChoice.SecondChoice != null)
        {
            engine.LoadChoice(CurrentChoice.SecondChoice);
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
            engine.LoadEnd(CurrentChoice);
        }
       
    }

    private IEnumerator TypeSentenceEachLetter(string sentence)
    {
        TypingSound.Play();

        OnTimePause?.Invoke();
        FirstChoiceButton.gameObject.SetActive(false);
        SecondChoiceButton.gameObject.SetActive(false);

        plot.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            yield return new WaitForSeconds(letterPause * Time.deltaTime);
            plot.text += letter;    
        }
        TypingSound.Stop();

        if (_isEnd == false)
        { 
        FirstChoiceButton.gameObject.SetActive(true);
        SecondChoiceButton.gameObject.SetActive(true);
        OnTimeContinue?.Invoke();
        }

        

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




