using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationManager : MonoBehaviour
{
    public TextMeshProUGUI question;
    public string[] questions;

    private void Start()
    {
        
    }

    public void ShowNextQuestion()
    {
        question.text = "";
    }

    public void ClickOnRight()
    {
        ShowNextQuestion();
    }

    public void ClickOnLeft()
    {
        ShowNextQuestion();
    }
}

