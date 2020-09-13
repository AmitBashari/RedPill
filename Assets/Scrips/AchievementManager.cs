using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class AchievementManager : MonoBehaviour
{
    private static AchievementManager instance = null; 
    public static AchievementManager Instance { get { return instance; } }
    
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
       
    }

    public List<AchievementSavedData.Ending> Endings => _savedData.Endings; 

    public bool AddEnding(AchievementSavedData.Ending ending) // New ending added
    {
        if (Endings.Contains(ending))
        {
            return false;
        }

        Endings.Add(ending);

        //check if we got speical ending. If yes -> add it

        if (Endings.Contains(AchievementSavedData.Ending.Cuddle_With_Charllote1)
            && Endings.Contains(AchievementSavedData.Ending.Charllote_Hurtful_Eyes2))
        {
            Endings.Add(AchievementSavedData.Ending.AllRedShirt33);
        }
      
      
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "achievments.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        AchievementSavedData achievmentData = _savedData;

        formatter.Serialize(stream, _savedData);
        stream.Close();
  
        return true;

    }

    public static AchievementSavedData LoadAchievmentData()
    {
        string path = Application.persistentDataPath + "achievments.json";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            AchievementSavedData data = formatter.Deserialize(stream) as AchievementSavedData;
            stream.Close();
            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public void ClearAchievments()
    {
        _savedData.Endings.Clear();

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "achievments.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        AchievementSavedData achievmentData = _savedData;

        formatter.Serialize(stream, _savedData);
        stream.Close();
    }
    
}




   