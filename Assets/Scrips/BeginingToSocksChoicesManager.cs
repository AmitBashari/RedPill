using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginingToSocksChoicesManager : MonoBehaviour
{

    //Conditions

    bool redShirt;
    bool rickAndMortySocks;

    //-----Choose Shirt Scene-----
    public void ChooseRedShirt()
    {
        redShirt = true;
    }

    public void ChooseBlueShirt()
    {
        redShirt = false;
    }
    //-----Choose Socks Scene-----
    public void ChooseRickAndMortySocks()
    {
        rickAndMortySocks = true;
    }

    public void ChooseRealMadridSocks()
    {
        rickAndMortySocks = false;
    }
    //-----Red Shirt + Rick and Morty socks-----
    public void RedShirtRickAndMorty()
    {
        if ((redShirt == true) && (rickAndMortySocks == true));
        Debug.Log("Red, Rick");
    }
    //-----Red Shirt +Real Madrid socks-----
    public void RedShirtRealMadrid()
    {
        if (redShirt == true && rickAndMortySocks == false);
        Debug.Log("Red, RealMadrid");
    }

    //-----Blue Shirt + Rick and Morty socks-----
    public void BlueShirtRickAndMorty()
    {
        if (redShirt == false && rickAndMortySocks == true) ;
        Debug.Log("Blue, Rick");
    }

    //-----Blue Shirt + Rick and Morty socks-----
    public void BlueShirtRealMadrid()
    {
        if (redShirt == false && rickAndMortySocks == false) ;
        Debug.Log("Blue, RealMadrid");
    }




    //-----Red Shirt + Real Madrid socks-----

    //-----Blue Shirt + Rick and Morty socks-----

    //-----Blue Shirt + Real Madrid socks-----


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
