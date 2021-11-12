using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

namespace Polombia
{
    public class GameManager : Singleton<GameManager>
    {
        private List<Level> _levels;

        #region bars

        public event Action<float> OnBudgetChanged;
        public event Action<float> OnSupportChanged;
        public event Action<float> OnApprovalChanged;

        private float _budget;

        public float budget
        {
            set
            {
                _budget = Mathf.Clamp(value, 0, 100);
                OnBudgetChanged.Invoke(_budget);
            }
            get { return _budget; }
        }

        private float _support;

        public float support
        {
            set
            {
                _support = Mathf.Clamp(value, 0, 100);
                OnSupportChanged.Invoke(_support);
            }
            get { return _support; }
        }

        private float _approval;

        public float approval
        {
            set
            {
                _approval = Mathf.Clamp(value, 0, 100);
                OnApprovalChanged.Invoke(_approval);
            }
            get { return _approval; }
        }

        #endregion

        private void Awake()
        {
        }

        private void Start()
        {
            
        }

        #region DebugBars

        [Button]
        public void ChangeBudget(float value) => budget = value;

        [Button]
        public void ChangeSupport(float value) => support = value;

        [Button]
        public void Changepproval(float value) => approval = value;

        #endregion
    }
}