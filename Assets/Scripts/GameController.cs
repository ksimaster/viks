using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


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
        pathFile = Application.streamingAssetsPath + "/" + "testingArray.json";
        JsonArrayTrue.List[] jsonArrayMap = JsonHelper.FromJson<JsonArrayTrue.List>(File.ReadAllText(pathFile));
        GameObject[] images = new GameObject[jsonArrayMap.Length];

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

        
    
            
    



