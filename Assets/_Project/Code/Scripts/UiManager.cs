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

        [SerializeField] private Sprite vicky;
        [SerializeField] private Sprite petro;
        [SerializeField] private Sprite martuchis;
        [SerializeField] private Sprite mafer;
        [SerializeField] private Sprite elPaisa;

        public enum TextUiType { Button_1, Button_2, Question, Year };

        public void SetCharacter(string characterName)
        {
            Sprite characterSprite = GetCharacterSpriteByName(characterName);
            if(characterSprite != null)
            {
                SetCharacterImage(characterSprite);
            }
        }

        public Sprite GetCharacterSpriteByName(string characterName)
        {
            switch (characterName)
            {
                case "Petro":
                    return petro;
                    break;
                case "Vicky":
                    return vicky;
                    break;
                case "Martuchis":
                    return martuchis;
                    break;
                case "Mafer":
                    return mafer;
                    break;
                case "ElPaisa":
                    return elPaisa;
                    break;
                default:
                    return null;
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
