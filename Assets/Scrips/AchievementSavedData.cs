using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementSavedData
{
    public enum Ending
    {
        Cuddle_With_Charllote = 1,
        Charllote_Hurtful_Eyes,
        EndNumber3,
        EndNumber4
    }

    public List<Ending> Endings = new List<Ending>();

}
