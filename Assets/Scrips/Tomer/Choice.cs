using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Choice Object")]
public class Choice : ScriptableObject
{
    public bool IsEnding;
    public ChoiceContent Content;
    public Choice FirstChoice;
    public Choice SecondChoice;
}
