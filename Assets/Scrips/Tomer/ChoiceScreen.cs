using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceScreen : MonoBehaviour
{
    public ChoiceEngine engine;

    public TextMeshProUGUI plot;
    public TextMeshProUGUI question;
    public Image art;
    public Button FirstChoiceButton;
    public Text FirstChoiceText;
    public Button SecondChoiceButton;
    public Text SecondChoiceText;

    private Choice currentChoice;

    public void Setup(Choice choice)
    {
        currentChoice = choice;
        plot.text = choice.Plot;
        art.sprite = choice.Art;
        if (choice.IsEnding)
        {
            FirstChoiceButton.gameObject.SetActive(false);
            SecondChoiceButton.gameObject.SetActive(false);
            return;
        }

        FirstChoiceText.text = choice.FirstChoice.Name;
        //question.text = choice.Content.Question;
        SecondChoiceText.text = choice.SecondChoice.Name;
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
}
