using UnityEngine;
using UnityEngine.Events;

public class ChoiceEngine : MonoBehaviour
{
    public ChoiceScreen screen;
    public Choice InitalChoice;
    public string[] Hints;
    public UnityEvent OnTimeRestart;

    private int currentIndex = -1;
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
        screen.SetupHint(Hints[currentIndex], InitalChoice);
    }

    public void TimerFinished()
    {
        // End game logic: 
    
        if (screen.CurrentChoice.IsFirstChoice == false)
        {
            LoadChoice(InitalChoice);
            OnTimeRestart?.Invoke();


            Debug.Log("Time Up");
            
        }
        else
        {
            Debug.Log("YOU WIN");
        }
   
    }

   
}
