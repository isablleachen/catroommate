using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ConversationManager : MonoBehaviour
{
    public GameObject cat;
    public Sprite emoji_cat_0;
    public Sprite emoji_cat_1;
    public Sprite emoji_cat_2;
    public Sprite emoji_cat_3;
    public Sprite emoji_cat_4;
    public Sprite emoji_cat_5;
    public Sprite emoji_cat_6;
    public Sprite emoji_cat_7;
    public Sprite emoji_cat_8;
    public Sprite emoji_cat_9;
    public Sprite emoji_cat_10;
    public Sprite emoji_cat_11;

    public Text ques;
    public string[] questions;
    public int index;

    public Button LeftButton;
    public string[] LAnswers;
    public Button RightButton;
    public string[] RAnswers;

    public int count1 = 0;
    public int count2 = 0;
    public Text buttonLeft;
    public Text buttonRight;

    public float typingSpeed;

    public int GoodAnswers;
    public int BadAnswers;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type1());
        StartCoroutine(Type2());
        StartCoroutine(Type3());
    }

    IEnumerator Type1()
    {
        foreach(char letter in questions[index].ToCharArray())
        {
            ques.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }  
    }

    IEnumerator Type2()
    { foreach (char letter in LAnswers[count1].ToCharArray())
        {
            buttonLeft.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator Type3()
    {
        foreach (char letter in RAnswers[count2].ToCharArray())
        {
            buttonRight.text += letter;
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
            StartCoroutine(Type1());
        }
    }

    public void GetLeftAnswers()
    {
        if (count1 < LAnswers.Length - 1)
        {
            count1++;
            buttonLeft.text = "";
            StartCoroutine(Type2());
        }
    }
    public void GetRightAnswers()
    {   if (count2 < RAnswers.Length - 1)
        {
            count2++;
            buttonRight.text = "";
            StartCoroutine(Type3());
        }
    }

    public void ClickLeft()
    {
        GetQuestion();
        GetLeftAnswers();
        GetRightAnswers();

        if (index == 1)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_3;
            GoodAnswers++;
        }
        if (index == 2)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_2;
            GoodAnswers++;
        }
        if (index == 3)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_8;
            BadAnswers++;
        }
        if (index == 4)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_9;
            GoodAnswers++;
        }
        if (index == 5)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_11;
            GoodAnswers++;
        }
        if (index == 6)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_4;
            BadAnswers++;
        }
        if (index == 7)
        {
            ShowResult();
        }
    }

    public void ClickRight()
    {
        GetQuestion();
        GetLeftAnswers();
        GetRightAnswers();

        if (index == 1)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_11;
            BadAnswers++;
        }
        if (index == 2)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_0;
            BadAnswers++;
        }
        if (index == 3)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_2;
            GoodAnswers++;
        }
        if (index == 4)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_5;
            BadAnswers++;
        }
        if (index == 5)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_2;
            BadAnswers++;
        }
        if (index == 6)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_10;
            GoodAnswers++;
        }
        if (index == 7)
        {
            ShowResult();
        }
    }

    public void ShowResult()
    {
        if (GoodAnswers >= BadAnswers)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_1;
            ques.text = "Let's be roommates!!";
            Destroy(LeftButton.gameObject);
            Destroy(RightButton.gameObject);
        }

        if (BadAnswers >= GoodAnswers)
        {
            cat.gameObject.GetComponent<SpriteRenderer>().sprite = emoji_cat_7;
            ques.text = "I can't live with you...";
            Destroy(LeftButton.gameObject);
            Destroy(RightButton.gameObject);
        }
    }
}
