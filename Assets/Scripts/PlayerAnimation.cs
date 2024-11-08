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

    // Fungsi untuk mengatur animasi berdasarkan status pergerakan
    public void PlayMovementAnimation(bool isMoving)
    {
        if (isMoving)
        {
            animator.Play("Moving"); // Mainkan animasi Boost saat bergerak
        }
        else
        {
            animator.Play("Idle"); // Mainkan animasi Idle saat berhenti
        }
    }
}
