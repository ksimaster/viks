using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    private int count = 0;

    public void Add()
    {
        count = int.Parse(CounterText.text);
        count++;
        CounterText.text = count.ToString();
    }
}
