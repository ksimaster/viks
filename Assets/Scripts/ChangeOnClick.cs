using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOnClick : MonoBehaviour
{
    public Color replaceColor;
    public Color returnColor;
    public Image imageAnswer;

    public void ChangeColor()
    {
        imageAnswer.color = replaceColor;
        StartCoroutine(DelayTime(10f));
        imageAnswer.color = returnColor;

    }

    public void ReturnColor()
    {
        imageAnswer.color = returnColor;
    }

    IEnumerator DelayTime(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

}
