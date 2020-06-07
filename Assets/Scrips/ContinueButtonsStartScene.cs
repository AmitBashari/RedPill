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
    //All Plots
    public GameObject chooseShirtPlot;
    public GameObject chooseSocksPlot;
    [Space(15)]
    //All Choice Windows
    public GameObject chooseShirtChoice;
    public GameObject chooseSocksChoice;
    [Space(15)]
    //All Continue Buttons
    public GameObject chooseShirtContinue;
    public GameObject chooseSocksContinue;
    [Space(15)]
    private GameObject[] turnPffChoices;
   
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
}
