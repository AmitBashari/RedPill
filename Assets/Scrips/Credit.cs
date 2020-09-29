using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Credit
{
    public string Headline;
    public string FunnyQuote;

    [TextArea(2,5)]
    public string Names;
}
