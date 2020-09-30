using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementDisplay : MonoBehaviour
{
    [System.Serializable]
    public class AchievementToImage
    {
        public GameObject Icon;
        public AchievementSavedData.Ending Ending;
    }

    public List<AchievementToImage> AchievmentsToImages;

    private void Start()
    {

        foreach (var a2i in AchievmentsToImages)
        {
            if (AchievementManager.Instance.Endings.Contains(a2i.Ending))
            {
                a2i.Icon.SetActive(true);
            }
        }

    }

}
