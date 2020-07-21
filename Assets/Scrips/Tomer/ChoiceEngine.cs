using UnityEngine;

public class ChoiceEngine : MonoBehaviour
{
    public ChoiceScreen screen;
    public Choice InitalChoice;

    private void Start()
    {
        LoadChoice(InitalChoice);

    }

    public void LoadChoice(Choice choice)
    {
        if (choice.IsEnding)
        {
            // Do something else
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
}
