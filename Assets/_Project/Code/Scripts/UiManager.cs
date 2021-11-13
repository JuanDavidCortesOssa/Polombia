using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Polombia
{
    public class UiManager : Singleton<UiManager>
    {
        [SerializeField] public SuperTextMesh questionText;
        [SerializeField] private Image characterImage;
        [SerializeField] private TextMeshProUGUI button1Txt;
        [SerializeField] private TextMeshProUGUI button2Txt;

        public enum TextUiType { Button_1, Button_2, Question };

        public void SetCharacterImage(Sprite sprite)
        {
            characterImage.sprite = sprite;
        }

        //[Button]
        //public void superTextTest()
        //{
        //    questionText._text = testText;
        //}

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
                default:
                    break;
            }
        }
    }
}
