using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GameController : MonoBehaviour
{
    private int lengthNumbersTasks = 100;
    private int lengthNumbersTasksForGame = 20;
    public int[] numbersTasks;
    public int[] numbersTasksForGame; 
    public System.Random rand = new System.Random();
    public Text textQuestion;
    public Image image;
    public Text textTrueAnswer;
    public Text textFalseAnswer_1;
    public Text textFalseAnswer_2;
    public Text textFalseAnswer_3;

    private string pathFile;




    private void Awake()
    {
        numbersTasks = new int[lengthNumbersTasks];
        numbersTasksForGame = new int[lengthNumbersTasksForGame];

    }

    void Start()
    {
        // image.sprite =
        
        
        RandArray();
    }

    void Update()
    {

    }

    public void RandArray()
    {
        // заполняем массив номеров заданий от числами 0 до 99
        for (int i = 0; i < numbersTasks.Length; i++)
        {
            numbersTasks.SetValue(i, i);
        }
        // перемешиваем массив заданий
        for (int i = numbersTasks.Length - 1; i >= 1; i--)
        {
            int j = rand.Next(i + 1);
            
            var temp = numbersTasks[j];
            numbersTasks[j] = numbersTasks[i];
            numbersTasks[i] = temp;
        }

        //заполняем массив для игры первыми числами массива заданий
        for (int i = 0; i < numbersTasksForGame.Length; i++)
        {
            numbersTasksForGame[i] = numbersTasks[i];
        }
        // отражение массива для игры в консоли
        foreach (int num in numbersTasksForGame)
        {
            Debug.Log(num);
        }

    }

    public void CreateTasks()
    {

    }


        
    
            
    


}
