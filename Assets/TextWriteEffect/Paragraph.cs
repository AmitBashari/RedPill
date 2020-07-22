using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Paragraph : MonoBehaviour
{
    [TextArea] public string OriginalText;
    public Sentence SentencePrefab;
    public UnityEvent OnParagraphFinished;

    private readonly List<Sentence> _sentences = new List<Sentence>();
    private int _currentSentenceIndex = 0;

    private void Awake() => LoadText();

    public void LoadText()
    {
        // Fade out the last sentence.
        if (_sentences.Count != 0)
        {
            var lastSentence = _sentences[_sentences.Count - 1];
            lastSentence.StartFadeOut();
        }


        // Divide the text into paragraphs.
        _sentences.Clear();

        var lines = OriginalText.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            // Create sentence GameObject for every line.
            var sentence = Instantiate(SentencePrefab, transform);
            sentence.Text = line;
            _sentences.Add(sentence);
        }
        _currentSentenceIndex = 0;
    }

    public void LoadText(string text)
    {
        OriginalText = text;
        LoadText();
    }

    public void Next()
    {
        var currentSentence = _sentences[_currentSentenceIndex];
        if (currentSentence != null && currentSentence.IsWriting)
        {
            // Stop the writing effect and show the full text.
            currentSentence.StopWriteIn();
            // Also finish fading out the previous sentence.
            if (_currentSentenceIndex > 0)
            {
                var previousSentence = _sentences[_currentSentenceIndex - 1];
                if (previousSentence != null) previousSentence.StopFadeOut();
            }
            return;
        }


        // Advance to the next sentence.
        _currentSentenceIndex++;
        if (_currentSentenceIndex < _sentences.Count)
        {
            // Fade out the previous sentence.
            currentSentence.StartFadeOut();
            var nextSentence = _sentences[_currentSentenceIndex];
            // Write in the next sentence.
            nextSentence.StartWriteIn();

            // Make the final sentence call the OnParagraphFinished event.
            if (_currentSentenceIndex == _sentences.Count - 1)
            {
                nextSentence.OnWriteInFinished.AddListener(() => OnParagraphFinished?.Invoke());
            }
        }
    }
}
