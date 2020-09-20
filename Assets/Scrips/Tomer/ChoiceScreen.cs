using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ChoiceScreen : MonoBehaviour
{
    public ChoiceEngine engine;

    public TextMeshProUGUI plot;
    //public TextMeshProUGUI question;
    public Image art;
    public Image PreviousArt;
    public Button FirstChoiceButton;
    public Text FirstChoiceText;
    public Button SecondChoiceButton;
    public Text SecondChoiceText;
    public AudioSource TypingSound;
    public AudioSource VoiceSound;
    public Button NextButton;
    public Choice CurrentChoice;
    public Animator SlideAnimator;
    public Animator PlotAnimator;
    public Animator BehindTextAnimator;
    public Animator AchievmentPopUp;
    public UnityEvent OnTimePause;
    public UnityEvent OnTimeContinue;
    //public Button LoadUIButton;
    
    private float letterPause = 0.05f;
    private Animation slideAnim;
    private Choice _nextChoice;
    private bool _isEnd = false;
    //public bool AlreadyGotAchievment;
    private int _endingID;

   
    



    public void Setup(Choice choice)
    {
        CurrentChoice = choice;
        VoiceSound.clip = choice.VoiceActing;

        StopAllCoroutines();
        StartCoroutine(TypeSentenceEachLetter(choice.Plot));

        art.sprite = choice.Art;

        if (choice.IsEnding)
        {
            FirstChoiceButton.gameObject.SetActive(false);
            SecondChoiceButton.gameObject.SetActive(false);
            _isEnd = true;
            AchievementManager.Instance.AddEnding(choice.Achievement);
            //_gotEndingAchievement = AchievementManager.Instance.AddEnding

            //Delete bellow button
            //LoadUIButton.gameObject.SetActive(true);

        }
        else
        {
            FirstChoiceText.text = choice.FirstChoice.Name;
            SecondChoiceText.text = choice.SecondChoice.Name;
            NextButton.gameObject.SetActive(false);
            _isEnd = false;

            //Delete bellow button
            //LoadUIButton.gameObject.SetActive(false);

        }


    }


    public void FirstChoiceClicked()
    {
        if (CurrentChoice.FirstChoice != null)
        {
            engine.LoadChoice(CurrentChoice.FirstChoice);
        }
    }

    public void SecondChoiceClicked()
    {
        if (CurrentChoice.SecondChoice != null)
        {
            engine.LoadChoice(CurrentChoice.SecondChoice);
        }
    }

    public void NextClicked()
    {
        if (_nextChoice != null)
        {
            engine.LoadChoice(_nextChoice);
            _nextChoice = null;
            NextButton.gameObject.SetActive(false);
            NextButton.GetComponentInChildren<TMP_Text>().text = ". . .";

        }
        
        if (CurrentChoice == engine.Victory) // Add here True end logic 
        {
            Debug.Log("I load crecit screen");

            SceneManager.LoadScene("CreditsUI");
        }
        
         
        else
        {
            engine.LoadEnd(CurrentChoice);
        }

    }

    private IEnumerator TypeSentenceEachLetter(string sentence)
    {


        PreviousArt.sprite = art.sprite;
        SlideAnimator.SetBool("IsActive", true);
        PlotAnimator.SetBool("IsActive", true);
        BehindTextAnimator.SetBool("IsActive", true);

        OnTimePause?.Invoke();

        FirstChoiceButton.gameObject.SetActive(false);
        SecondChoiceButton.gameObject.SetActive(false);

        plot.text = "";

        yield return new WaitForSeconds(2f);

        VoiceSound.Play();

        float startTime = Time.time;
        float factor = 0;
        float voiceToTypingRatio = 0.85f;
        bool shouldSkip = false;
        float duration = sentence.Length * letterPause;
        if (VoiceSound.clip != null)
        {
            duration = VoiceSound.clip.length * voiceToTypingRatio;
        }
        

        TypingSound.Play();

        while (factor < 1) //(char letter in sentence.ToCharArray())
        {
            //yield return new WaitForSeconds(letterPause * Time.deltaTime); //check if time.deltaTime is needed

            plot.text = sentence.Substring(0, (int)(sentence.Length * factor));
            yield return null;
            factor = (Time.time - startTime) / duration;

            if (Input.GetMouseButtonDown(0)) //Ask*
            {
                // fill the plot element with all the text
                //plot.text = sentence;

                shouldSkip = true;

                // break out of typing loop (hence no more waiting)
                break;
            }
        }
        //VoiceSound.Stop();
        plot.text = sentence;
        TypingSound.Stop();
        SlideAnimator.SetBool("IsActive", false);
        PlotAnimator.SetBool("IsActive", false);
        BehindTextAnimator.SetBool("IsActive", false);

        while (VoiceSound.isPlaying && !shouldSkip)
        {
            shouldSkip = Input.GetMouseButtonDown(0);

            yield return null;
        }

        VoiceSound.Stop();

        if (_isEnd == false)
        {
            FirstChoiceButton.gameObject.SetActive(true);
            SecondChoiceButton.gameObject.SetActive(true);
            OnTimeContinue?.Invoke();
        }

        if (_isEnd == true)
        {
            NextButton.gameObject.SetActive(true);

            if (AchievementManager.AlreadyGotAchievment == false)
            {
                Debug.Log("I play Achievemnt Animation"); // Insert Achievment Anim Here 
            }
            AchievementManager.AlreadyGotAchievment = true;

        }


    }

    public void SetupHint(string hint, Choice nextChoice, Sprite hintBackground)
    {
        FirstChoiceButton.gameObject.SetActive(false);
        SecondChoiceButton.gameObject.SetActive(false);
        NextButton.gameObject.SetActive(false);
        _nextChoice = nextChoice;
        StopAllCoroutines();
        VoiceSound.clip = null;
        StartCoroutine(TypeSentenceEachLetter(hint));
        NextButton.GetComponentInChildren<TMP_Text>().text = "Wake Up!";
        //Timer SecondsImage.fillAmount = 0f;
        art.sprite = hintBackground;
    }


}




