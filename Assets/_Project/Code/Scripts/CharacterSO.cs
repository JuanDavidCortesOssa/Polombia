using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polombia
{
    [CreateAssetMenu(menuName = "Polombia/Characters SO", fileName = "character_")]
    public class CharacterSO : ScriptableObject
    {
        public string name;
        public AudioClip audioClip;
        public Sprite sprite;
    }
}
