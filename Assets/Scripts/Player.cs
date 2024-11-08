using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private PlayerControl playerControl;
    private PlayerAnimation playerAnimation;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Ambil komponen PlayerControl pada GameObject yang sama
        playerControl = GetComponent<PlayerControl>();
        
        // Cari GameObject "EngineEffect" dan ambil komponen PlayerAnimation dari sana
        GameObject engineEffect = GameObject.Find("EngineEffect");
        if (engineEffect != null)
        {
            playerAnimation = engineEffect.GetComponent<PlayerAnimation>();
        }

        // Cek apakah PlayerAnimation ditemukan, jika tidak tampilkan pesan error
        if (playerAnimation == null)
        {
            Debug.LogError("PlayerAnimation component is missing from EngineEffect GameObject!");
        }

        if (playerControl == null)
        {
            Debug.LogError("PlayerControl component is missing from this GameObject!");
        }
    }

    void FixedUpdate()
    {
        if (playerControl != null)
        {
            playerControl.Move(); // Panggil fungsi Move() dari PlayerControl
        }
    }

    void LateUpdate()
    {
        if (playerAnimation != null && playerControl != null)
        {
            // Update animasi berdasarkan status pergerakan
            playerAnimation.PlayMovementAnimation(playerControl.IsMoving());
        }
    }
}
