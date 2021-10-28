using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using TMPro;

namespace Polombia
{
    [Serializable]
    public class Decision : MonoBehaviour
    {
        public Consequence consequence;
        private List<Quote> duqueQuotes;
        private NewsSO news;
        private List<Card> consequenceCards;

        public TMP_Text decisionText;
        public string decisionString;

        private void Start()
        {
            if (!decisionString.IsNullOrWhitespace()) decisionText.text = decisionString;
        }
    }
}