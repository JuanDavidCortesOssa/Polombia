using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Polombia;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Button button1;
    public Button button2;
    public List<Card> cards;
    private int contador;
    private UiManager uiManager;
    private ReadData readData;
    private GameManager gameManager;
    void Start()
    {
        Addlisteners();
        
    }

    private void Awake()
    {
        InitializeVariables();
        LoadQuestions();
    }

    public void InitializeVariables()
    {
        contador = 0;
        uiManager = UiManager.Instance;
        readData = ReadData.Instance;
        gameManager = GameManager.Instance;
    }

    public void LoadQuestions()
    {

        cards = new List<Card>();
        Debug.Log(readData.tag);
        cards = readData.LoadData();

        contador = 0;

        uiManager.SetUiTexts(UiManager.TextUiType.Question, cards[contador].questionString);
        uiManager.SetUiTexts(UiManager.TextUiType.Button_1, cards[contador].decisions[0].decisionString);
        uiManager.SetUiTexts(UiManager.TextUiType.Button_2, cards[contador].decisions[1].decisionString);
        uiManager.SetCharacter(cards[0].CharacterName);
    }

    public void Addlisteners()
    {
        button1.onClick.AddListener(LeftAnswer);
        button2.onClick.AddListener(RightAnswer);
    }

    private void LeftAnswer()
    {
        cards[contador].decisions[0].consequence.ApplyConsequence();
        cards.RemoveAt(contador);
        NextQuestion();
    }

    private void RightAnswer()
    {
        cards[contador].decisions[1].consequence.ApplyConsequence();
        cards.RemoveAt(contador);
        NextQuestion();
    }

    public void NextQuestion()
    {
        //contador++;
        if (contador > cards.Count - 1)
        {
            contador = 0;
            gameManager.WinGame();
        }
        else
        {
            uiManager.SetUiTexts(UiManager.TextUiType.Question, cards[contador].questionString);
            uiManager.SetUiTexts(UiManager.TextUiType.Button_1, cards[contador].decisions[0].decisionString);
            uiManager.SetUiTexts(UiManager.TextUiType.Button_2, cards[contador].decisions[1].decisionString);
            uiManager.SetCharacter(cards[contador].CharacterName);
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
