﻿using System;
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

        public Consequence(float budget, float aproval, float support)
        {
            this.budget = budget;
            this.approval = aproval;
            this.support = support;
        }

        public void ApplyConsequence()
        {
            GameManager.Instance.budget += budget;
            GameManager.Instance.approval += approval;
            GameManager.Instance.support += support;
        }
    }
}