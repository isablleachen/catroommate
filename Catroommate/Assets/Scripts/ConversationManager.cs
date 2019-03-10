using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ConversationManager : MonoBehaviour
{
    public GameObject cat;
    public Sprite emoji_cat_1;
    public Sprite emoji_cat_2;

    public Text ques;
    public string[] questions;
    public int index;

    public float typingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach(char letter in questions[index].ToCharArray())
        {
            ques.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Update is called once per frame

    public void GetQuestion()
    {
        if(index < questions.Length - 1)
        {
            index++;
            ques.text = "";
            StartCoroutine(Type());
        }
    }

    public void ClickUP()
    {
        cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_1;
        GetQuestion();
    }

    public void ClickDOWN()
    {
        cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_2;
        GetQuestion();
    }
}
