using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

namespace Polombia
{
    public class Card : MonoBehaviour
    {
        private Character character;
        [InlineEditor] public List<Decision> decisions;
        public string questionString;

        public TMP_Text questionText;

        private void Start()
        {
            if (!questionString.IsNullOrWhitespace()) questionText.text = questionString;
        }
    }
}