using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Polombia
{
    public class UiManager : Singleton<UiManager>
    {
        [SerializeField] private TextMeshProUGUI question;
        [SerializeField] private Image characterImage;
        [SerializeField] private TextMeshProUGUI button1Txt;
        [SerializeField] private TextMeshProUGUI button2Txt;

        public enum TextUiType { Button_1, Button_2, Question };

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
                    question.text = text;
                    break;
                default:
                    break;
            }
        }
    }
}
