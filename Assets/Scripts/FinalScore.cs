using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text FinalText;
    
    void Update()
    {
        if(PlayerPrefs.HasKey(FinalText.name))
        {
            FinalText.text = PlayerPrefs.GetString(FinalText.name);
        }
        else
        {
            FinalText.text = "0";
        }
    }
}
