using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Polombia
{
    public class UiManager : Singleton<UiManager>
    {
        [SerializeField] public SuperTextMesh questionText;
        [SerializeField] public SuperTextMesh yearText;
        [SerializeField] private Image characterImage;
        [SerializeField] private TextMeshProUGUI button1Txt;
        [SerializeField] private TextMeshProUGUI button2Txt;

        [SerializeField] private Animator characterAnimator;

        public enum TextUiType { Button_1, Button_2, Question, Year };

        public void SetCharacter(string characterName)
        {
            GetCharacterSpriteByName(characterName);
        }

        public void GetCharacterSpriteByName(string characterName)
        {
            switch (characterName)
            {
                case "Petro":
                    characterAnimator.SetInteger("Character", 3);
                    break;
                case "Vicky":
                    characterAnimator.SetInteger("Character", 2);
                    break;
                case "Martuchis":
                    characterAnimator.SetInteger("Character", 0);
                    break;
                case "Mafer":
                    characterAnimator.SetInteger("Character", 1);
                    break;
                case "ElPaisa":
                    characterAnimator.SetInteger("Character", 4);
                    break;
                default:
                    break;
            }
        }

        public void SetCharacterImage(Sprite sprite)
        {
            characterImage.sprite = sprite;
        }

        public void SetUiTexts(TextUiType textType, string text)
        {
            switch (textType)
            {
                case TextUiType.Button_1:
                    button1Txt.text = text;
                    break;
                case TextUiType.Button_2:
                    button2Txt.text = text;
                    break;
                case TextUiType.Question:
                    questionText.text = text;
                    break;
                case TextUiType.Year:
                    yearText.text = text;
                    break;
                default:
                    break;
            }
        }
    }
}
