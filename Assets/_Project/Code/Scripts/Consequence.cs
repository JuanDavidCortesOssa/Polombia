using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polombia
{
    public class Consequence : MonoBehaviour
    {
        public float budget;
        public float approval;
        public float support;

        public void ApplyConsequence()
        {
            GameManager.instance.budget += budget;
            GameManager.instance.approval += approval;
            GameManager.instance.support += support;
        }
    }
}