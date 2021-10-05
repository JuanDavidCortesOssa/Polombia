using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using Sirenix.OdinInspector;

namespace Polombia
{
    public class NewsManager : MonoBehaviour
    {
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI contentText;
        public TextMeshProUGUI dateText;
        public Image image;
        //public VideoClip videoClipContent;


        [Button]
        void SetNews(NewsSO news)
        {
            titleText.text = news.title;
            contentText.text = news.content;
            dateText.text = news.date;
            image.sprite = news.imageSprite;
        }
    }
}
