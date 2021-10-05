using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polombia
{
    [CreateAssetMenu(menuName = "Polombia/News SO", fileName = "news_")]
    public class NewsSO : ScriptableObject
    {
        public string title;
        public string content;
        public string date;
        public Sprite imageSprite;
        public UnityEngine.Video.VideoClip videoClip;
    }
}

