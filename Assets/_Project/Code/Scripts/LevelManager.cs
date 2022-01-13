using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Polombia;

public class LevelManager : Singleton<LevelManager>
{
    // Start is called before the first frame update

    public Button button1;
    public Button button2;
    public List<List<Card>> cards;
    private int contador;
    private float maxQuestionsNum;
    private UiManager uiManager;
    private ReadData readData;
    private GameManager gameManager;

    public int levelNumber = new int();

    //public AudioSource duqueQuote;
    //Duque
    [SerializeField] private Animator duqueAnimator;

    void Start()
    {
        Addlisteners();
        uiManager.SetUiTexts(UiManager.TextUiType.Year, "<w>AÑO # " + (InfoHack.levelNumber + 1));

        gameManager.progress = (InfoHack.questionNum / maxQuestionsNum) * 100;
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

        cards = new List<List<Card>>();

        cards.Add(readData.LoadData(ReadData.Level.Level1));
        cards.Add(readData.LoadData(ReadData.Level.Level2));
        cards.Add(readData.LoadData(ReadData.Level.Level3));

        foreach (var t in cards)
        {
            maxQuestionsNum += t.Count;
        }
    }

    public void LoadQuestions()
    {
        int level = (InfoHack.levelNumber + 1);

        if (level == 1)
        {
            InfoHack.questionNum = 0;
        }

        contador = 0;

        uiManager.SetUiTexts(UiManager.TextUiType.Question, cards[levelNumber][contador].questionString);
        uiManager.SetUiTexts(UiManager.TextUiType.Button_1, cards[levelNumber][contador].decisions[0].decisionString);
        uiManager.SetUiTexts(UiManager.TextUiType.Button_2, cards[levelNumber][contador].decisions[1].decisionString);
        uiManager.SetCharacter(cards[levelNumber][0].CharacterName);
    }

    public void Addlisteners()
    {
        button1.onClick.AddListener(LeftAnswer);
        button2.onClick.AddListener(RightAnswer);
    }

    private void LeftAnswer()
    {
        cards[levelNumber][contador].decisions[0].consequence.ApplyConsequence();
        cards[levelNumber].RemoveAt(contador);
        NextQuestion();
    }

    private void RightAnswer()
    {
        cards[levelNumber][contador].decisions[1].consequence.ApplyConsequence();
        cards[levelNumber].RemoveAt(contador);
        NextQuestion();
    }

    public void NextQuestion()
    {
        InfoHack.questionNum++;
        gameManager.progress = (InfoHack.questionNum / maxQuestionsNum) * 100;
        Debug.Log(
            $"questionNUm{InfoHack.questionNum} maxque {maxQuestionsNum}, progress{(InfoHack.questionNum / maxQuestionsNum)}");

        StartCoroutine(DuqueAnimationCoroutine());
        // contador++;
        if (contador > cards[levelNumber].Count - 1)
        {
            contador = 0;
            gameManager.WinGame();
        }
        else
        {
            uiManager.SetUiTexts(UiManager.TextUiType.Question, cards[levelNumber][contador].questionString);
            uiManager.SetUiTexts(UiManager.TextUiType.Button_1,
                cards[levelNumber][contador].decisions[0].decisionString);
            uiManager.SetUiTexts(UiManager.TextUiType.Button_2,
                cards[levelNumber][contador].decisions[1].decisionString);
            uiManager.SetCharacter(cards[levelNumber][contador].CharacterName);
        }
    }

    public void ExecuteDuqueQuote()
    {
        //duqueQuote.Play();
    }


    IEnumerator DuqueAnimationCoroutine()
    {
        //Set true variable
        duqueAnimator.SetBool("ButtonPressed", true);

        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);

        //Set false variable
        duqueAnimator.SetBool("ButtonPressed", false);
    }
}