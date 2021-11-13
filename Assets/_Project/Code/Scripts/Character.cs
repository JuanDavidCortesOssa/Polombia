using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polombia
{
    public class Character : MonoBehaviour
    {
        private string name;
        private AudioClip audioClip;
        private Sprite sprite;

        public Character(string name, AudioClip audioClip, Sprite sprite)
        {
            this.name = name;
            this.audioClip = audioClip;
            this.sprite = sprite;
        }
    }
}

