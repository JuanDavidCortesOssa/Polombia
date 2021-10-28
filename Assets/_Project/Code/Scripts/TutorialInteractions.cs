using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Polombia;

public class TutorialInteractions : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI question;

    public TextMeshProUGUI button1Txt;
    public Button button1;

    public Button button2;
    public TextMeshProUGUI button2Txt;

    private List<Card> cards;
    private int contador;

    void Start()
    {
        Addlisteners();
        InitializeVariables();
    }

    public void InitializeVariables()
    {
        contador = 0;
    }

    public void LoadQuestions(List<Card> newCards)
    {
        cards = newCards;
        contador = 0;
        question.text = cards[0].questionString;
        button1Txt.text = cards[0].decisions[0].decisionString;
        button2Txt.text = cards[0].decisions[1].decisionString;
    }

    public void Addlisteners()
    {
        button1.onClick.AddListener(NextQuestion);
        button2.onClick.AddListener(NextQuestion);
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
