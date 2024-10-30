using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan gerak
    private Vector2 input; // Input dari player
    public LayerMask solidObjectsLayer; // Layer untuk objek solid

    private PlayerAnimation playerAnimation; // Referensi ke PlayerAnimation

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>(); // Ambil komponen PlayerAnimation
    }

    private void Update()
    {
        GetInput(); // Ambil input dari player
        Move(); // Gerakkan player
    }

    // Fungsi untuk mengambil input dari player
    private void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Panggil animasi setiap kali ada perubahan input
        if (playerAnimation != null)
        {
            playerAnimation.PlayMovementAnimation(input.x, input.y);
        }
    }

    // Fungsi untuk menggerakkan player berdasarkan input
    private void Move()
    {
        Vector3 targetPos = transform.position + (Vector3)(input * moveSpeed * Time.deltaTime);

        // Cek tabrakan dengan objek solid
        if (!IsSolid(targetPos))
        {
            transform.position = targetPos;
        }
    }

    // Cek apakah ada tabrakan dengan objek solid
    private bool IsSolid(Vector3 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) != null;
    }
}
