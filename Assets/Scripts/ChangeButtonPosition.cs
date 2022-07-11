using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;


public class ChangeButtonPosition : MonoBehaviour
{
    public Button [] buttons = new Button [4];
    private Vector3[] buttonsPositions = new Vector3[4];
    private Vector3[] arrayNew = new Vector3[4];
    private  List<int> listNumbers =new List<int>(4) { 0, 1, 2, 3};

    public void CheckButtonPosition()
    {
        for (int i = 0; i<buttons.Length;i++)
        {
            buttonsPositions[i] = buttons[i].transform.position;
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
        for (int i=0; i < buttonsPositions.Length; i++)
        {
            arrayNew[i] = buttonsPositions[listNumbers[i]];
            
        }
        buttonsPositions = arrayNew;
    }

    public void SetTransformButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
             buttons[i].transform.position = buttonsPositions[i];
        }
    }

    private void Start()
    {
        CheckButtonPosition();
        RandomChange();
        SetTransformButtons();
    }


}
