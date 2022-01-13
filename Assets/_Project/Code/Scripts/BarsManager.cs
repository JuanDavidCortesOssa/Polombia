using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Polombia
{
    public class BarsManager : MonoBehaviour
    {
        public Slider budget, support, approval, progress;
        public float animationTime;

        private void Start()
        {
            GameManager.Instance.OnBudgetChanged += UpdateBudgetBar;
            GameManager.Instance.OnSupportChanged += UpdateSupportBar;
            GameManager.Instance.OnApprovalChanged += UpdateApprovalBar;
            GameManager.Instance.OnProgressChanged += UpdateProgressBar;

            GameManager.Instance.budget = 50;
            GameManager.Instance.support = 50;
            GameManager.Instance.approval = 50;
            GameManager.Instance.progress = 0;
        }

        public void UpdateBudgetBar(float value) =>
            DOTween.To(() => budget.value, x => budget.value = x, value / 100, animationTime);

        public void UpdateSupportBar(float value) =>
            DOTween.To(() => support.value, x => support.value = x, value / 100, animationTime);

        public void UpdateApprovalBar(float value) =>
            DOTween.To(() => approval.value, x => approval.value = x, value / 100, animationTime);

        public void UpdateProgressBar(float value) =>
            DOTween.To(() => progress.value, x => progress.value = x, value / 100, animationTime);
    }
}