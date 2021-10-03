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
        public Slider budget, support, approval;
        public float animationTime;

        private void Start()
        {
            GameManager.instance.OnBudgetChanged += UpdateBudgetBar;
            GameManager.instance.OnSupportChanged += UpdateSupportBar;
            GameManager.instance.OnApprovalChanged += UpdateApprovalBar;
        }

        public void UpdateBudgetBar(float value) =>
            DOTween.To(() => budget.value, x => budget.value = x, value / 100, animationTime);

        public void UpdateSupportBar(float value) =>
            DOTween.To(() => support.value, x => support.value = x, value / 100, animationTime);

        public void UpdateApprovalBar(float value) =>
            DOTween.To(() => approval.value, x => approval.value = x, value / 100, animationTime);

        private void OnDestroy()
        {
            GameManager.instance.OnBudgetChanged -= UpdateBudgetBar;
            GameManager.instance.OnSupportChanged -= UpdateSupportBar;
            GameManager.instance.OnApprovalChanged -= UpdateApprovalBar;
        }
    }
}
