using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Text))]
public class Sentence : MonoBehaviour
{
    public AnimationCurve Curve = AnimationCurve.Linear(0, 0, 1, 1);
    public float FadeOutDistance = 30f;
    public float FadeOutDuration = 0.5f;
    public float WriteInDuration = 1f;

    public UnityEvent OnWriteInFinished;

    public bool IsWriting { get; private set; } = false;

    private Text _textUI;
    public string OriginalText;

    private void Awake()
    {
        _textUI = GetComponent<Text>();
        _textUI.enabled = false;
    }

    private IEnumerator FadeOut()
    {
        var startTime = Time.time;
        var factor = 0f;
        var originalColor = _textUI.color;
        while (factor < 1)
        {
            factor = Curve.Evaluate(factor);
            transform.localPosition = Vector3.up * FadeOutDistance * factor;
            _textUI.color = originalColor * new Color(1, 1, 1, 1 - factor);
            yield return null;
            factor = (Time.time - startTime) / FadeOutDuration;
        }
        StopFadeOut();
    }

    private IEnumerator WriteIn()
    {
        var startTime = Time.time;
        var factor = 0f;
        IsWriting = true;
        while (factor < 1)
        {
            var text = OriginalText.Substring(0, (int)(OriginalText.Length * factor));
            _textUI.text = text;
            yield return null;
            factor = (Time.time - startTime) / WriteInDuration;
        }
        StopWriteIn();
    }

    [ContextMenu("Start Fade Out")]
    public void StartFadeOut() => StartCoroutine(FadeOut());

    [ContextMenu("Stop Fade Out")]
    public void StopFadeOut()
    {
        StopAllCoroutines();
        Destroy(gameObject);

    }

    [ContextMenu("Start Write In")]
    public void StartWriteIn()
    {
        OriginalText = _textUI.text;
        _textUI.enabled = true;
        _textUI.color = Color.white;
        StartCoroutine(WriteIn());
    }

    [ContextMenu("Stop Write In")]
    public void StopWriteIn()
    {
        StopAllCoroutines();
        _textUI.text = OriginalText;
        IsWriting = false;
        OnWriteInFinished?.Invoke();
    }

    public string Text
    {
        get => _textUI.text;
        set => _textUI.text = value;
    }
}
