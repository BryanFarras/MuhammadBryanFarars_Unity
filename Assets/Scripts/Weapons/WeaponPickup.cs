using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder; // The weapon prefab to spawn when picked up
    private static Weapon currentWeapon; // Track the currently equipped weapon (shared across all instances)
    private static Transform originalParent; // Track the original parent of the current weapon
    private static Vector3 originalPosition; // Track the original position of the current weapon

    void Awake()
    {
        if (weaponHolder != null)
        {
            originalParent = weaponHolder.transform.parent;
            originalPosition = weaponHolder.transform.position;
        }
        else
        {
            Debug.LogWarning("weaponHolder is not assigned in the Inspector.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (weaponHolder == null)
            {
                Debug.LogError("Weapon prefab is not assigned in the Inspector.");
                return;
            }

            if (currentWeapon != null)
            {
                TurnVisual(false, currentWeapon);
                Destroy(currentWeapon.gameObject);
            }

            currentWeapon = Instantiate(weaponHolder, other.transform.position, Quaternion.identity);
            currentWeapon.transform.SetParent(other.transform);
            currentWeapon.transform.localPosition = Vector3.zero;

            TurnVisual(true, currentWeapon);
            gameObject.SetActive(false);
        }
    }

    void TurnVisual(bool on, Weapon specificWeapon)
    {
        if (specificWeapon == null) return;

        foreach (Renderer renderer in specificWeapon.GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = on;
        }

        if (specificWeapon.weaponPickUp != null)
        {
            specificWeapon.weaponPickUp.gameObject.SetActive(!on);
        }
    }

    void ReturnWeaponToOriginalPosition()
    {
        if (currentWeapon == null) return;

        currentWeapon.transform.SetParent(originalParent);
        currentWeapon.transform.position = originalPosition;

        TurnVisual(false, currentWeapon);
        currentWeapon = null;
    }
}