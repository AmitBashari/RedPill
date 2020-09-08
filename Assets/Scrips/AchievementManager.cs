using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    private static AchievementManager instance = null; 
    public static AchievementManager Instance { get { return instance; } }

    //public List<GameObject> AchievementsToEarn = new List<GameObject>();

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

        _savedData = new AchievementSavedData(); // Read from file , save to file
    }

    public List<AchievementSavedData.Ending> Endings => _savedData.Endings; 

    public bool AddEnding(AchievementSavedData.Ending ending) // New ending added
    {
        if (Endings.Contains(ending))
        {
            return false;
        }

        Endings.Add(ending);
        //Save Data here
        return true;

    }

}

   