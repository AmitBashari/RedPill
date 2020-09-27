using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class AchievementManager : MonoBehaviour
{
    private static AchievementManager instance = null; 
    public static AchievementManager Instance { get { return instance; } }

    public static bool AlreadyGotAchievment = true;

    private AchievementSavedData _savedData;

    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
        }
        else
        { 
            if (instance != this)
            { 
                Destroy(gameObject);
                return;
            }
        }
        DontDestroyOnLoad(this);

        _savedData = LoadAchievmentData();
        if (_savedData == null)
        {
            _savedData = new AchievementSavedData();
        }
       
    }

    public List<AchievementSavedData.Ending> Endings => _savedData.Endings; 

    public bool AddEnding(AchievementSavedData.Ending ending) // New ending added
    {
        if (Endings.Contains(ending))
        {
            AlreadyGotAchievment = true;
            return false;
        }
        else
        {
            AlreadyGotAchievment = false;
        }

        Endings.Add(ending);
        //AlreadyGotAchievment = false;
        //Set that bool on choice screen to true
        

        //check if we got speical ending. If yes -> add it // Check: Hash Set - like a list but not in oreder, got indexes. 

        if (Endings.Contains(AchievementSavedData.Ending.Cuddle_With_Charllote1)
            && Endings.Contains(AchievementSavedData.Ending.Charllote_Hurtful_Eyes2)
            && Endings.Contains(AchievementSavedData.Ending.Charllote_Candlestick3)
            && Endings.Contains(AchievementSavedData.Ending.Charlotte_Amused4)
            && Endings.Contains(AchievementSavedData.Ending.Charlotte_Laundromat5)
            && Endings.Contains(AchievementSavedData.Ending.Charlotte_Disappointed6)
            && Endings.Contains(AchievementSavedData.Ending.Charlotte_Yelling7)
            && Endings.Contains(AchievementSavedData.Ending.Flamboyant_Gesture8)
            && Endings.Contains(AchievementSavedData.Ending.Charlotte_Agrees9)
            && Endings.Contains(AchievementSavedData.Ending.Charlotte_IsHurt10)
            && Endings.Contains(AchievementSavedData.Ending.Charlotte_Pounds11)
            && Endings.Contains(AchievementSavedData.Ending.Charlotte_Smiling12)
            && Endings.Contains(AchievementSavedData.Ending.Charlotte_FaceRed13)
            && Endings.Contains(AchievementSavedData.Ending.Charlotte_Puzzled14)
            && Endings.Contains(AchievementSavedData.Ending.Charlotte_Furious15)
            && Endings.Contains(AchievementSavedData.Ending.Charlotte_Stares16))
        {
            Endings.Add(AchievementSavedData.Ending.AllRedShirt33);
        }

                if (Endings.Contains(AchievementSavedData.Ending.Manager_Stutters17)
            && Endings.Contains(AchievementSavedData.Ending.Manager_puzzled18)
            && Endings.Contains(AchievementSavedData.Ending.Manager_Wipes19)
            && Endings.Contains(AchievementSavedData.Ending.Manager_Walks20)
            && Endings.Contains(AchievementSavedData.Ending.Manager_Accepts21)
            && Endings.Contains(AchievementSavedData.Ending.Manager_Appologizes22)
            && Endings.Contains(AchievementSavedData.Ending.Manager_AskToCall23)
            && Endings.Contains(AchievementSavedData.Ending.Manager_LowersHisEyes24)
            && Endings.Contains(AchievementSavedData.Ending.Manager_Fuming25)
            && Endings.Contains(AchievementSavedData.Ending.Manager_PointsAtFeet26)
            && Endings.Contains(AchievementSavedData.Ending.Manager_SomehowIrritated27)
            && Endings.Contains(AchievementSavedData.Ending.Manager_Stifling28)
            && Endings.Contains(AchievementSavedData.Ending.YourArgumentHeatUp29)
            && Endings.Contains(AchievementSavedData.Ending.YouFeelBetrayed30)
            && Endings.Contains(AchievementSavedData.Ending.Manager_StartsYelling31)
            && Endings.Contains(AchievementSavedData.Ending.Manager_Scoffs32))

        {
            Endings.Add(AchievementSavedData.Ending.AllBlueShirt34);
        }
      
      
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/achievments.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        AchievementSavedData achievmentData = _savedData;

        formatter.Serialize(stream, _savedData);
        stream.Close();
  
        return true;

    }

    public static AchievementSavedData LoadAchievmentData() // This is _savedData =
    {
        string path = Application.persistentDataPath + "/achievments.json";
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            if (stream.Length == 0)
            {
                stream.Close();
                return null;
            }

            BinaryFormatter formatter = new BinaryFormatter();

            AchievementSavedData data = formatter.Deserialize(stream) as AchievementSavedData;
            stream.Close();
            return data;

            

        }
        else
        {
            //I added these lines just now, but I still can't make it work
            
            /*BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            AchievementSavedData data = formatter.Deserialize(stream) as AchievementSavedData;
            stream.Close();
            */

            Debug.Log("Save file not found in " + path);
            return null;
        }

    }

    public void ClearAchievments()
    {
        _savedData.Endings.Clear();

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/achievments.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        AchievementSavedData achievmentData = _savedData;

        formatter.Serialize(stream, _savedData);
        stream.Close();
    }
    
}




   