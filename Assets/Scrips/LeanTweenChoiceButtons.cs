using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenChoiceButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.7f).setEaseOutBack().setDelay(0.8f);
        //LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.7f).setEaseInQuint().setDelay(0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
