using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEvents : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void StopAnimation()
    {
        animator.speed = 0;
    }

    public void StartAnimation()
    {
        animator.speed = 1f;
    }
}
