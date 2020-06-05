using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GameManager : MonoBehaviour
{
    static int wakeUpScore = 0; // +1 for each time the player reach an ending
    bool redShirt;
    bool rickAndMortySocks;
    public GameObject opening1;
    public GameObject opening2;
    public GameObject opening3;
    public GameObject story;

    //Questions Canvas Area
    public GameObject Q0; //WakeUp
    public GameObject Q1; //Choose Shirt
    public GameObject Q2; //Choose Socks
    public GameObject Q3; //Top Q5. Bottom Q6.
    public GameObject Q4; //Top Q7. Bottom Q8.
    public GameObject Q5; //Top Q9. Bottom Q10.
    public GameObject Q6; //Top Q11. Bottom Q12. 
    public GameObject Q7; //Top Q13. Bottom Q14.
    public GameObject Q8; //Top Q15. Bottom Q16.
    public GameObject Q9; //Top Q17. Bottom Q18
    public GameObject Q10;//Top Q19. Bottom Q20
    public GameObject Q11;//Top Q21. Bottom Q22
    public GameObject Q12;//Top Q23. Bottom Q24
    public GameObject Q13;//Top Q25. Bottom Q26
    public GameObject Q14;//Top Q27. Bottom Q28
    public GameObject Q15;//Top Q29. Bottom Q30
    public GameObject Q16;//Top Q31. Bottom Q32
    //public GameObject Q17;//Top Q33. Bottom Q34
    public GameObject Q18;//Top Q35. Bottom Q36
    public GameObject Q19;//Top Q37. Bottom Q38
    public GameObject Q20;//Top Q39. Bottom Q40
    public GameObject Q21;//Top Q41. Bottom Q42
    public GameObject Q22;//Top Q43. Bottom Q44
    public GameObject Q23;//Top Q45. Bottom Q46
    public GameObject Q24;//Top Q47. Bottom Q48
    public GameObject Q25;//Top Q49. Bottom Q50
    public GameObject Q26;//Top Q51. Bottom Q52
    public GameObject Q27;//Top Q53. Bottom Q54
    public GameObject Q28;//Top Q55. Bottom Q56
    public GameObject Q29;//Top Q57. Bottom Q58
    public GameObject Q30;//Top Q59. Bottom Q60
    public GameObject Q31;//Top Q61. Bottom Q62
    public GameObject Q32;//Top Q63. Bottom Q64
    public GameObject Q33;//Top Q65. Bottom Q66
    public GameObject Q34;//Top Q67. Bottom Q68
    public GameObject Q65;//Ending
    public GameObject Q66;//Ending
    public GameObject Q67;//Ending
    public GameObject Q68;//Ending
    // arrays - game objects (1) IDs (2)

 
    //Question 0
    public void WakeUp() // Perhaps should have named it Q0
    {
        
        Q0.SetActive(false);
        Q1.SetActive(true);

        Debug.Log("Wake Up Score Is"+" "+wakeUpScore);
    }
    //----------Question 1----------
    public void Question1_Top() // RedShirt
    {
        redShirt = true;
        Q1.SetActive(false);
        Q2.SetActive(true);
        Debug.Log(redShirt);
    }
    public void Question1_Bottom() // BlueShirt
    {
        redShirt = false;
        Q1.SetActive(false);
        Q2.SetActive(true);
        Debug.Log("Is Shirt Red ?" +" "+ redShirt);
    }
    //----------Question 2----------
    public void Question2_Top() // Rick and Morty Socks
    {
        rickAndMortySocks = true;
        Q2.SetActive(false);
        if (redShirt == true)
        {
            Q3.SetActive(true);
        }

        else
        {
            Q4.SetActive(true);
        }

        Debug.Log("Are socks Rick and Morty?" +" "+ rickAndMortySocks);
    }
    public void Question2_Bottom() // "Real Madrid" Socks
    {
        rickAndMortySocks = false;
        Q2.SetActive(false);
        if (redShirt == true)
        {
            Q3.SetActive(true);
        }

        else
        {
            Q4.SetActive(true);
        }
 
        Debug.Log(rickAndMortySocks);
    }

    //----------Question 3----------
    public void Question3_Top()
    {
        Q3.SetActive(false);
        Q5.SetActive(true);
    }
    public void Question3_Bottom()
    {
        Q3.SetActive(false);
        Q6.SetActive(true);
    }

    //----------Question 4----------
    public void Question4_Top()
    {
        Q4.SetActive(false);
        Q7.SetActive(true);
    }
    public void Question4_Bottom()
    {
        Q4.SetActive(false);
        Q8.SetActive(true);
    }

    //----------Question 5----------
    public void Question5_Top()
    {
        Q5.SetActive(false);
        Q9.SetActive(true);
    }
    public void Question5_Bottom()
    {
        Q5.SetActive(false);
        Q10.SetActive(true);
    }

    //----------Question 9----------
    public void Question9_Top()
    {
        Q9.SetActive(false);
        //Q17.SetActive(true);
        //Q17.SetActive(false);
        if (rickAndMortySocks == true)
        {
            Q33.SetActive(true);
        }

        else
        {
            Q34.SetActive(true);
        }

    }
    public void Question9_Bottom()
    {
        Q9.SetActive(false);
        Q18.SetActive(true);
    }
    //----------Question 10----------
    public void Question10_Top()
    {
        Q10.SetActive(false);
        Q19.SetActive(true);
    }
    public void Question10_Bottom()
    {
        Q10.SetActive(false);
        Q20.SetActive(true);
    }

    //-----Question 17----- //Disabled Options
    //public void Question17_Top()
    //{
    //    Q17.SetActive(false);
      //  if (rickAndMortySocks == true)
        //{
          //  Q33.SetActive(true);
        //}

        //else
        //{
         //   Q34.SetActive(true);
        //}
   // }
    

    //----------Question 33----------
    public void Question33_Top()
    {
        Q33.SetActive(false);
        Q65.SetActive(true);
    }
    public void Question33_Bottom()
    {
        Q33.SetActive(false);
        Q66.SetActive(true);
    }

    //----------Question 34----------
    public void Question34_Top()
    {
        Q34.SetActive(false);
        Q67.SetActive(true);
    }
    public void Question34_Bottom()
    {
        Q34.SetActive(false);
        Q68.SetActive(true);
    }
    //----------Question 65---------- / End
    public void Question65_End()
    {
        Q65.SetActive(false);
        Q0.SetActive(true);
        wakeUpScore = wakeUpScore + 1;

        Debug.Log("Wake Up Score Is" + " " + wakeUpScore);
    }
    //----------Question 66---------- / End
    public void Question66_End()
    {
        Q66.SetActive(false);
        Q0.SetActive(true);
        wakeUpScore = wakeUpScore + 1;

        Debug.Log("Wake Up Score Is" + " " + wakeUpScore);
    }
    //----------Question 67---------- / End
    public void Question67_End()
    {
        Q67.SetActive(false);
        Q0.SetActive(true);
        wakeUpScore = wakeUpScore + 1;

        Debug.Log("Wake Up Score Is" + " " + wakeUpScore);
    }
    //----------Question 68---------- / End
    public void Question68_End()
    {
        Q67.SetActive(false);
        Q0.SetActive(true);
        wakeUpScore = wakeUpScore + 1;

        Debug.Log("Wake Up Score Is" + " " + wakeUpScore);
    }

    // Start is called before the first frame update
    void Start()
    {
        Q0.SetActive(true);
      
       opening1.SetActive(true);
    
    }
    // Update is called once per frame
    void Update()
    {
        if (wakeUpScore == 0)
        {
            opening1.SetActive(true);

        }
        if (wakeUpScore == 1)
        {
            opening1.SetActive(false);
            opening2.SetActive(true);
        }
        if (wakeUpScore > 1)
        {
            opening1.SetActive(false);
            opening2.SetActive(false);
            opening3.SetActive(true);
        }

        if (Input.GetKeyDown("escape"))
            Application.Quit();
    }
}
