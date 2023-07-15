using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO questionSO;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    int correctAnswerIndex;
    Timer timer;

    void Start()
    {
        timer = FindAnyObjectByType<Timer>();
        ResetQuiz();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            ResetQuiz();
            timer.loadNextQuestion = false;
        }
    }

    public void ResetQuiz()
    {
        questionText.text = questionSO.GetQuestion;
        string[] answers = questionSO.GetAnswers;

        for (int i = 0; i < answers.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = answers[i];
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }

    public void CheckAnswer(int index)
    {
        Image buttonImage;

        if (index == questionSO.GetCorrectAnswerIndex)
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = questionSO.GetCorrectAnswerIndex;
            questionText.text = "Incorrect! The correct answer is " + questionSO.GetAnswers[correctAnswerIndex];
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonState(false);
        timer.CancelTimer();
    }

    public void LoadNextQuestion()
    {
        //questionSO = Resources.Load<QuestionSO>("Questions/Question" + (questionSO.GetQuestionNumber + 1));
        ResetQuiz();
        SetButtonState(true);
    }

    public void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Button>().interactable = state;
        }
    }

    public void ExitQuiz()
    {
        Application.Quit();
    }
}