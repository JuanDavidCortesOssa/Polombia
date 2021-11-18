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
    public List<Card> cards;
    private int contador;
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
        uiManager.SetUiTexts(UiManager.TextUiType.Year, "<w>AÑO # " + (InfoHack.levelNumber+1));
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
        int level = (InfoHack.levelNumber + 1);

        if (level == 1)
        {
            cards = readData.LoadData(ReadData.Level.Level1);

        }
        else
        {
            if (level == 2)
            {
                cards = readData.LoadData(ReadData.Level.Level2);
            }
            else
            {
                cards = readData.LoadData(ReadData.Level.Level3);
            }
        }

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
        StartCoroutine(DuqueAnimationCoroutine());
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
