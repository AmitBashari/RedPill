using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordByWord : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText;
    [TextArea(3,15)]
    public string contentText;
    public float letterPause = 0.1f;
    // Use this for initialization
    void Start()
    {
        string writeThis = contentText;
        StartCoroutine(TypeSentence(writeThis));
    }

    IEnumerator TypeSentence(string sentence)
    {
        string[] array = sentence.Split(' ');
        textMeshProText.text = array[0];
        for (int i = 1; i < array.Length; ++i)
        {
            yield return new WaitForSeconds(letterPause * Time.deltaTime);
            textMeshProText.text += " " + array[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
