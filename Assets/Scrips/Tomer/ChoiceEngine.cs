using UnityEngine;

public class ChoiceEngine : MonoBehaviour
{
    public ChoiceScreen screen;
    public Choice InitalChoice;
    public string[] Hints;
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

    public void OnTimerFinished()
    {
        // End game logic: 
    }
}
