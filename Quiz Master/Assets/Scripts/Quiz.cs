using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO questionSO;
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    int correctAnswerIndex;

    void Start()
    {
ResetQuiz();
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
}