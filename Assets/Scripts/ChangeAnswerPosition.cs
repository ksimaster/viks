using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;


public class ChangeAnswerPosition : MonoBehaviour
{
    
    public Image[] answers = new Image[4];
    private Vector3[] answersPositions = new Vector3[4];
    private Vector3[] arrayNew = new Vector3[4];
    private  List<int> listNumbers =new List<int>(4) { 0, 1, 2, 3};

    public void CheckAnswersPosition()
    {
        for (int i = 0; i<answers.Length;i++)
        {
            answersPositions[i] = answers[i].transform.position;
        }
    }

    public void RandomChange()
    {
        
        listNumbers.Reverse(0, Mathf.RoundToInt(Random.Range(1,5)));
       /*
        foreach (int num in listNumbers)
        {
            Debug.Log(num);
        }
        */
        for (int i=0; i < answersPositions.Length; i++)
        {
            arrayNew[i] = answersPositions[listNumbers[i]];
            
        }
        answersPositions = arrayNew;
    }

    public void SetAnswersPositions()
    {
        for (int i = 0; i < answers.Length; i++)
        {
             answers[i].transform.position = answersPositions[i];
        }
    }

    private void Start()
    {
        CheckAnswersPosition();
        RandomChange();
        SetAnswersPositions();
    }


}
