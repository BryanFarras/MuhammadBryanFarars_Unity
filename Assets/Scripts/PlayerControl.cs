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

    private void FixedUpdate()
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
            bool isMoving = input.x != 0 || input.y != 0;  // Cek jika ada input
            playerAnimation.PlayMovementAnimation(isMoving); // Panggil animasi sesuai status pergerakan
        }
    }

    // Fungsi untuk menggerakkan player berdasarkan input
    public void Move()
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

    public bool IsMoving()
    {
        return input.x != 0 || input.y != 0;  // True jika ada input gerak
    }
}
