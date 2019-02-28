using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChange : MonoBehaviour
{
    public TextMeshProUGUI text;
    private string[] textStuff;

    public void ChangeText();
    {
      int randNum;
      randNum = Random.Range(0, textStuff.Length);

      text.text = textStuff[randNum];
    }
}
