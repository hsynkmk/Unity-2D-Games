using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question", order = 1)]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)][SerializeField] string question = "Enter your question here";
    [SerializeField] string[] answers = new string[4];
    [Range(0, 3)][SerializeField] int correctAnswer = 0;

    public string GetQuestion { get { return question; } }
    public string[] GetAnswers { get { return answers; } }
    public int GetCorrectAnswerIndex { get { return correctAnswer;  } }
}
