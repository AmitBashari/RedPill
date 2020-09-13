using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementSavedData
{
    public enum Ending
    {
        Cuddle_With_Charllote1 = 1,
        Charllote_Hurtful_Eyes2,
        Charllote_Candlestick3,
        Charlotte_Amused4,
        Charlotte_Laundromat5,
        Charlotte_Disappointed6,
        Charlotte_Yelling7,
        Flamboyant_Gesture8,
        Charlotte_Agrees9,
        Charlotte_IsHurt10,
        Charlotte_Pounds11,
        Charlotte_Smiling12,
        Charlotte_FaceRed13,
        Charlotte_Puzzled14,
        Charlotte_Furious15,
        Charlotte_Stares16,
        Manager_Stutters17,
        Manager_puzzled18,
        Manager_Wipes19,
        Manager_Walks20,
        Manager_Accepts21,
        Manager_Appologizes22,
        Manager_AskToCall23,
        Manager_LowersHisEyes24,
        Manager_Fuming25,
        Manager_PointsAtFeet26,
        Manager_SomehowIrritated27,
        Manager_Stifling28,
        YourArgumentHeatUp29,
        YouFeelBetrayed30,
        Manager_StartsYelling31,
        Manager_Scoffs32,
        AllRedShirt33,
        AllBlueShirt34,
        TrueEnding35
    }

    public List<Ending> Endings = new List<Ending>();
}
