using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;


public class ChangeAnswerPosition : MonoBehaviour
{
    
    public Image[] answers = new Image[4];
    private Vector3[] answersPositions = new Vector3[4];
    private Vector3[] generalAnswersPositions = new Vector3[4];
    private List<int> listNumbers = new List<int>(4) { 0, 1, 2, 3 };
    public System.Random rand = new System.Random();

    public void CheckAnswersPosition()
    {
        for (int i = 0; i<answers.Length;i++)
        {
            answersPositions[i] = answers[i].transform.position;
        }
        
    }

    public void CreateGeneralAnswerPositions()
    {
        generalAnswersPositions = answersPositions;
    }


    public void RandomChange2()
    {
        listNumbers = new List<int>(4) { 0, 1, 2, 3 };

        listNumbers.Reverse(0, Mathf.RoundToInt(Random.Range(1,5)));

        for (int i=0; i < answersPositions.Length; i++)
        {
            answersPositions[i] = generalAnswersPositions[listNumbers[i]];
            
        }
        
    }
    public void RandomChange()
    {
        for (int i = answersPositions.Length - 1; i >= 1; i--)
        {
            int j = rand.Next(i + 1);

            var temp = answersPositions[j];
            answersPositions[j] = answersPositions[i];
            answersPositions[i] = temp;
        }

    }

    public void SetAnswersPositions()
    {
        for (int i = 0; i < answers.Length; i++)
        {
             answers[i].transform.position = answersPositions[i];
        }
    }

    public void ChangeForNewTask()
    {
        
        RandomChange();
        SetAnswersPositions();
    }

    private void Start()
    {
        CheckAnswersPosition();
        ChangeForNewTask();
    }


}
