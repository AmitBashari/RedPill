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
    public float letterPause = 2f;
    public AudioSource typingSound;
    public bool doneTypingQuestion;
    // Use this for initialization
    void Start()
    {
        string writeThis = contentText;
        StartCoroutine(TypeSentence(writeThis));
        //StartCoroutine(TypeSentenceEachLetter(writeThis));
    }


    IEnumerator TypeSentence(string sentence)
    {
        typingSound.Play();
        doneTypingQuestion = false;
        string[] array = sentence.Split(' ');
        textMeshProText.text = array[0];
        for (int i = 1; i < array.Length; ++i)
        {
            yield return new WaitForSeconds(letterPause * Time.deltaTime);
            textMeshProText.text += " " + array[i];
        }
        typingSound.Stop();
        doneTypingQuestion = true;

    }
    

    /*IEnumerator TypeSentenceEachLetter(string sentence)
    {
        typingSound.Play();
        textMeshProText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textMeshProText.text += letter;
            yield return null;
        }
        typingSound.Stop();

    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
