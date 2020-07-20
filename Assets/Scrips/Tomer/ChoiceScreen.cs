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
        plot.text = choice.Content.Plot;
        art.sprite = choice.Content.Art;
        if (choice.IsEnding)
        {
            FirstChoiceButton.gameObject.SetActive(false);
            SecondChoiceButton.gameObject.SetActive(false);
            return;
        }

        FirstChoiceText.text = choice.FirstChoice.Content.Name;
        question.text = choice.Content.Question;
        SecondChoiceText.text = choice.SecondChoice.Content.Name;
    }


    public void FirstChoiceClicked()
    {
        engine.LoadChoice(currentChoice.FirstChoice);
    }

    public void SecondChoiceClicked()
    {
        engine.LoadChoice(currentChoice.SecondChoice);
    }
}
