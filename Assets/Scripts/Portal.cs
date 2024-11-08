using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private float speed;          // Speed at which the portal (asteroid) moves
    [SerializeField] private float rotateSpeed;    // Rotation speed for the portal (asteroid)
    private Vector3 newPosition;                   // Target position for dynamic movement
    private Player player;                         // Reference to the player

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();       // Find player reference in the scene
        ChangePosition();                          // Initialize newPosition
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player has a weapon
        if (player != null && player.GetComponentInChildren<Weapon>() != null)
        {
            // Make asteroid visible and enable collider
            GetComponent<Renderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;

            // Move towards the newPosition
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime); // Rotate asteroid

            // Check distance to the target position
            if (Vector3.Distance(transform.position, newPosition) < 0.5f)
            {
                ChangePosition(); // Update to a new position
            }
        }
        else
        {
            // Hide asteroid and disable collider if player doesn't have a weapon
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    // Method to handle collision with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.LevelManager.LoadScene("Main");
        }
    }

    // Set a new random position for the asteroid to move towards
    private void ChangePosition()
    {
        // Set newPosition to a random point within a certain range
        newPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
    }
}
