using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Choice Object")]
public class Choice : ScriptableObject
{
    public bool IsEnding;
    public string Name;
    [TextArea (5,15)]
    public string Plot;
    public Sprite Art;
    public Choice FirstChoice;
    public Choice SecondChoice;
    public AudioClip VoiceActing;
}
