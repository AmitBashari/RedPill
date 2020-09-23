using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScreen : MonoBehaviour
{
    public CreditsEngine CEngine;

    public Text CreditsHeadline;
    public Text[] CreditsNames;
    public Text CreditsFunnyQuote;

    public Credit[] CreditObjects;

    public Animator Animator;

    private float letterPause = 0.05f;

    private void Start()
    {
        CreditsHeadline.text = CreditObjects[0].Headline;
        CreditsNames[0].text = CreditObjects[0].Names[0];
        
        CreditsNames[1].text = CreditObjects[0].Names[1];
    }
}
