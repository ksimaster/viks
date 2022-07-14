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
    }

    public void ReturnColor()
    {
        imageAnswer.color = returnColor;
    }

}
