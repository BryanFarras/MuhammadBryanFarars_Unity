using UnityEngine;
using UnityEngine.UI;

public class ChooseWeaponUI : MonoBehaviour
{
    public Text gameTitle;  // Assign via Inspector
    public Button[] weaponButtons;

    void Start()
    {
        gameTitle.text = "Choose Your Weapon!";  // Ganti sesuai nama gim.
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            int index = i;
            weaponButtons[i].onClick.AddListener(() => SelectWeapon(index));
        }
    }

    void SelectWeapon(int weaponIndex)
    {
        Debug.Log($"Weapon {weaponIndex} selected!");
        // Lanjutkan logika untuk memilih senjata.
    }
}
