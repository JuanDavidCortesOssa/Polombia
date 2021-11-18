using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

namespace Polombia
{
    public class GameManager : Singleton<GameManager>
    {
        public enum Characters {Petro, Vicky, Martuchis, mafer, ElPaisa}

        private List<CharacterSO> characterSOs;
        private List<Character> characters;
        private List<Level> _levels;

        SceneManager sceneManager;

        #region bars

        public event Action<float> OnBudgetChanged;
        public event Action<float> OnSupportChanged;
        public event Action<float> OnApprovalChanged;
        public event Action OnBarEmpty;

        private float _budget;

        public float budget
        {
            set
            {
                _budget = Mathf.Clamp(value, 0, 100);
                OnBudgetChanged.Invoke(_budget);
                if(_budget == 0)
                {
                    OnBarEmpty.Invoke();
                }
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
                if (_support == 0)
                {
                    OnBarEmpty.Invoke();
                }
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
                if (_approval == 0)
                {
                    OnBarEmpty.Invoke();
                }
            }
            get { return _approval; }
        }

        #endregion

        private void Awake()
        {
            AddListeners();
            sceneManager = SceneManager.Instance;
        }

        private void Start()
        {
            
        }

        private void AddListeners()
        {
            OnBarEmpty += LoseGame;
        }

        #region DebugBars

        [Button]
        public void ChangeBudget(float value) => budget = value;

        [Button]
        public void ChangeSupport(float value) => support = value;

        [Button]
        public void Changepproval(float value) => approval = value;

        public void LoseGame()
        {
            sceneManager.GoToLose();
            InfoHack.levelNumber = 0;
        }

        public void WinGame()
        {
            if (InfoHack.levelNumber > 1)
            {
                sceneManager.GoToWin2();
                InfoHack.levelNumber = 0;
            }
            else
            {
                sceneManager.GoToWin();
                InfoHack.levelNumber++;
            }
        }

        [Button]
        public void DebugLevel()
        {
            Debug.Log(InfoHack.levelNumber);
        }

        #endregion
    }
}