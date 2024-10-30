using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>(); // Ambil komponen Animator
    }

    // Fungsi untuk mengatur animasi berdasarkan input
    public void PlayMovementAnimation(float moveX, float moveY)
    {
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", moveY);

        // Atur isMoving berdasarkan ada atau tidaknya input
        bool isMoving = moveX != 0 || moveY != 0;
        animator.SetBool("isMoving", isMoving);
    }
}
