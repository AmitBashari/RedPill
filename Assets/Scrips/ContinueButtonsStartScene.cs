using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContinueButtonsStartScene : MonoBehaviour
{
   

    //All Scenes
    public GameObject startScene;
    public GameObject chooseShirtScene;

    //All Plots
    public GameObject chooseShirtPlot;

    //All Choice Windows
    public GameObject chooseShirtChoice;

    //All Continue Buttons
    public GameObject chooseShirtContinue;

    //-----Start Scene-----

    public void Start_To_ChooseShirt()
    {
        startScene.SetActive(false);
        chooseShirtScene.SetActive(true);
    }

    //-----Choose Shirt Scene-----
    public void ChooseShirt_Plot_To_Choices()
    {
        chooseShirtPlot.SetActive(false);
        chooseShirtContinue.SetActive(false);
        chooseShirtChoice.SetActive(true);
       
    }

    //-----TEST-----
    public void Test()
    {
        chooseShirtPlot.SetActive(true);
        chooseShirtContinue.SetActive(true);
        chooseShirtChoice.SetActive(false);

    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
