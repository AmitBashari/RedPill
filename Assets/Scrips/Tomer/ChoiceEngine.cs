using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ChoiceEngine : MonoBehaviour
{
    public ChoiceScreen screen;
    public Choice InitalChoice;
    public Choice Victory;
    public string[] Hints;
    public Hint[] SmartHints;
    public UnityEvent OnTimeRestart;
    public Sprite DefualtHintImage;

    private int currentIndex = -1;

    [System.Serializable]
    public class Hint
    {
        public string Text;
        public Sprite Image;
    }

    private void Start()
    {
        LoadChoice(InitalChoice);

    }


    public void LoadChoice(Choice choice)
    {


        if (choice.IsEnding)
        {
            screen.Setup(choice);
        }
        else
        {
            screen.Setup(choice);
        }
    }

    [ContextMenu("Test")]
    public void Test()
    {
        LoadChoice(InitalChoice);
    }

    public void LoadEnd (Choice choice)
    {
        if (currentIndex < Hints.Length-1)
        { 
            currentIndex++;
        }
        //currentIndex = Mathf.Min(currentIndex + 1, Hints.Length - 1);
        screen.SetupHint(Hints[currentIndex], InitalChoice, DefualtHintImage); // Replace "Hints[currentIndex], InitalChoice, DefualtHintImage" with SmartHint.text and SmartHints.Image
    }

    public void TimerFinished()
    {
        // End game logic: 

        if (screen.CurrentChoice != InitalChoice)
        {
            LoadChoice(InitalChoice);
            OnTimeRestart?.Invoke();
            

            Debug.Log("Time Up");
        }
        else
        {
            Debug.Log("YOU WIN");
            LoadChoice(Victory);
            CreditsManager.EnteredFromMainMenu = false;
        }
   
    }

   
}
