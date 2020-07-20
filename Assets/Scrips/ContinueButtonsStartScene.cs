using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContinueButtonsStartScene : MonoBehaviour
{

    //Conditions
    bool redShirt;
    bool rickAndMortySocks;

    //All Scenes
    public GameObject beginingToChooseSocks;
    public GameObject startScene;
    public GameObject chooseShirtScene;
    public GameObject chooseSocksScene;
    [Space(15)]
    //-----All Plots-----
    //--StartScenePlots--
    [Header("Enter Start Scene Plots")]
    public GameObject startScenePlot1;
    public GameObject startScenePlot2;
    public GameObject startScenePlot3;
    public GameObject startButton;
    [Space(10)]

    public GameObject chooseShirtPlot1;
    public GameObject chooseShirtPlot2;
    public GameObject chooseShirtPlot3;
    public GameObject chooseSocksPlot;
    [Space(15)]
    //All Choice Windows
    public GameObject chooseShirtChoice;
    public GameObject chooseSocksChoice;
    [Space(15)]
    //All Continue Buttons
    public GameObject chooseShirtContinue;
    public GameObject chooseSocksContinue;
    //[Space(15)]
    //private GameObject[] turnPffChoices;
    //public bool doneTypingQuestion;

    //-----Start Scene-----

    public void Start_Show_Plot1()
    {
        startScenePlot1.SetActive(true);
        startButton.SetActive(false);
    }

    public void Start_Plot1_To_Plot2()
    {
        startScenePlot1.SetActive(false);
        startScenePlot2.SetActive(true);

    }

    public void Start_Plot2_To_Plot3()
    {
        startScenePlot2.SetActive(false);
        startScenePlot3.SetActive(true);

    }

    public void Start_Plot3_To_ChooseShirt()
    {
        startScene.SetActive(false);
        chooseShirtScene.SetActive(true);

    }

    //-----Choose Shirt Scene-----
    public void ChooseShirt_Plot1_To_Plot2()
    {
        chooseShirtPlot1.SetActive(false);
        chooseShirtContinue.SetActive(false);
        chooseShirtChoice.SetActive(true);
    }

    public void ChooseShirt_Plot2_To_Plot3()
    {
        chooseShirtPlot1.SetActive(false);
        chooseShirtContinue.SetActive(false);
        chooseShirtChoice.SetActive(true);
    }

    public void ChooseShirt_Plot3_To_ShirtChoice()
    {
        chooseShirtPlot1.SetActive(false);
        chooseShirtContinue.SetActive(false);
        chooseShirtChoice.SetActive(true);
    }


    //Chose Red Shirt
    public void ChooseRedShirt()
    {
        redShirt = true;
        chooseShirtChoice.SetActive(false);
        chooseSocksScene.SetActive(true);
    }


    //Chose Blue Shirt

    public void ChooseBlueShirt()
    {
        redShirt = false;
        chooseShirtChoice.SetActive(false);
        chooseSocksScene.SetActive(true);
    }

    //-----Choose Socks Scene-----
    public void ChooseSocks_Plot_To_Choices()
    {
        chooseSocksPlot.SetActive(false);
        chooseSocksContinue.SetActive(false);
        chooseSocksChoice.SetActive(true);
    }
        // Start is called before the first frame update
        void Start()
    {
        startScene.SetActive(true);
        beginingToChooseSocks.SetActive(true);

    }

 
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DelayChoices()
    {
        yield return new WaitForSecondsRealtime(2f);
    }
}
