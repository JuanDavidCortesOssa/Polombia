using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Polombia;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI question;

    public TextMeshProUGUI button1Txt;
    public Button button1;

    public Button button2;
    public TextMeshProUGUI button2Txt;

    public List<Card> cards;
    private int contador;

    void Start()
    {
        Addlisteners();
        InitializeVariables();
        LoadQuestions();
    }

    public void InitializeVariables()
    {
        contador = 0;
    }

    public void LoadQuestions()
    {
        cards = new List<Card>();
        cards = ReadData.Instance.LoadData();

        contador = 0;
        question.text = cards[0].questionString;
        button1Txt.text = cards[0].decisions[0].decisionString;
        button2Txt.text = cards[0].decisions[1].decisionString;
    }

    public void Addlisteners()
    {
        button1.onClick.AddListener(LeftAnswer);
        button2.onClick.AddListener(RightAnswer);
    }

    private void LeftAnswer()
    {
        cards[contador].decisions[0].consequence.ApplyConsequence();
        NextQuestion();
    }

    private void RightAnswer()
    {
        cards[contador].decisions[1].consequence.ApplyConsequence();
        NextQuestion();
    }

    public void NextQuestion()
    {
        contador++;
        if (contador > cards.Count - 1)
        {
            contador = 0;
        }
       
        question.text = cards[contador].questionString;
        button1Txt.text = cards[contador].decisions[0].decisionString;
        button2Txt.text = cards[contador].decisions[1].decisionString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
