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
    [CreateAssetMenu(menuName = "Polombia/Card SO", fileName = "Card_")]
    public class Card : MonoBehaviour
    {
        public string CharacterName;
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