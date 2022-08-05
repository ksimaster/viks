using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class GameController : MonoBehaviour
{
    private int lengthNumbersTasks = 39;
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

    private string [] textQuestions;
    private string [] nameImages;
    private string [] textTrueAnswers;
    private string[] textFalseAnswers_1;
    private string[] textFalseAnswers_2;
    private string[] textFalseAnswers_3;
    private int numberTaskInGame = 0;
    private string pathFile;
    private int[] prefArray;
    private bool isPrefArray = false;

    private void Awake()
    {
        SetForStart();
    }

    void Start()
    {
        // image.sprite =


        RandArray();
        ReadTasksFromJSON();
        CreateTask();

    }

    void Update()
    {

    }

    public void SetForStart()
    {
        numbersTasks = new int [lengthNumbersTasks];
        numbersTasksForGame = new int [lengthNumbersTasksForGame];
        textQuestions = new string [lengthNumbersTasksForGame];
        nameImages = new string [lengthNumbersTasksForGame];
        textTrueAnswers = new string [lengthNumbersTasksForGame];
        textFalseAnswers_1 = new string [lengthNumbersTasksForGame];
        textFalseAnswers_2 = new string [lengthNumbersTasksForGame];
        textFalseAnswers_3 = new string [lengthNumbersTasksForGame];
        prefArray = new int[lengthNumbersTasksForGame];
        if (prefArray[0] != 0 && prefArray[1] != 0)
        {
            isPrefArray = true;
            for(int i = 0; i < prefArray.Length; i++)
            {
                var namePref = "Task_" + i;
                prefArray[i] = PlayerPrefs.GetInt(namePref);
            }
        }

    }

    public void RandArray()
    {
        
        // заполняем массив номеров заданий от числами 0 до 99
        for (int i = 0; i < numbersTasks.Length; i++)
        {
            if (isPrefArray) break; // если есть массив из pref, то не нужен
            numbersTasks.SetValue(i, i);
        }
        // перемешиваем массив заданий
        for (int i = numbersTasks.Length - 1; i >= 1; i--)
        {
            if (isPrefArray) break;
            int j = rand.Next(i + 1);

            var temp = numbersTasks[j];
            numbersTasks[j] = numbersTasks[i];
            numbersTasks[i] = temp;
        }

        //заполняем массив для игры первыми числами массива заданий
        for (int i = 0; i < numbersTasksForGame.Length; i++)
        {
            if (isPrefArray) break;
            numbersTasksForGame[i] = numbersTasks[i]; // написание сохранения, пока без теста и get
            prefArray[i] = numbersTasks[i]; 
            var namePref = "Task_" + i;
            PlayerPrefs.SetInt(namePref, numbersTasksForGame[i]);
        }

        // отражение массива для игры в консоли
       /* foreach (int num in numbersTasksForGame)
        {
            Debug.Log(num);
        }
        */

    }
    public void CreateTask()
    {
        numberTaskInGame = PlayerPrefs.HasKey("numberTask") ? PlayerPrefs.GetInt("numberTask") : 0;
        if (numberTaskInGame < numbersTasksForGame.Length)
        {
            
            textQuestion.text = textQuestions[numberTaskInGame];
            image.GetComponent<Image>().sprite = Resources.Load<Sprite>(nameImages[numberTaskInGame]); ;
            textTrueAnswer.text = textTrueAnswers[numberTaskInGame];
            textFalseAnswer_1.text = textFalseAnswers_1[numberTaskInGame];
            textFalseAnswer_2.text = textFalseAnswers_2[numberTaskInGame];
            textFalseAnswer_3.text = textFalseAnswers_3[numberTaskInGame];
            numberTaskInGame++;
            PlayerPrefs.SetInt("numberTask", numberTaskInGame);
        }
        else
        {
            numberTaskInGame = 0;
            Debug.Log("Конец игры! Панель сыграй снова!");
        }
    }



    public void ReadTasksFromJSON()
    {
        pathFile = Application.streamingAssetsPath + "/" + "TorJSON.json";
        
        JsonArrayTrue.List[] jsonArray = JsonHelper.FromJson<JsonArrayTrue.List>(File.ReadAllText(pathFile));
        
        //GameObject[] images = new GameObject[jsonArrayMap.Length];


        for (int i = 0; i < numbersTasksForGame.Length; i++)
        {
            nameImages[i] = jsonArray[numbersTasksForGame[i]].Id;
            textQuestions[i] = jsonArray[numbersTasksForGame[i]].Question;
            textTrueAnswers[i] = jsonArray[numbersTasksForGame[i]].TrueAnswer;
            textFalseAnswers_1[i] = jsonArray[numbersTasksForGame[i]].WrongAnswer_1;
            textFalseAnswers_2[i] = jsonArray[numbersTasksForGame[i]].WrongAnswer_2;
            textFalseAnswers_3[i] = jsonArray[numbersTasksForGame[i]].WrongAnswer_3;
        }

        /*
        for (int i = 0; i < jsonArrayMap.Length; i++)
        {

            images[i] = Instantiate(partMap);
            images[i].name = jsonArrayMap[i].Id;
            images[i].transform.SetParent(Canvas.transform, false);
            images[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(jsonArrayMap[i].Id);
            images[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(jsonArrayMap[i].X, jsonArrayMap[i].Y);
            images[i].GetComponent<RectTransform>().sizeDelta = new Vector2(jsonArrayMap[i].Width, jsonArrayMap[i].Height);
        }
        */
    }
}



[System.Serializable]
public class JsonArrayTrue
{
    [System.Serializable]
    public class List
    {
        public string Id;
        public string Question;
        public string TrueAnswer;
        public string WrongAnswer_1;
        public string WrongAnswer_2;
        public string WrongAnswer_3;
    }

    // public ListMap [] jsonArrayMap;
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.List;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.List = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.List = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] List;
    }
}

        
    
            
    



