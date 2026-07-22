using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Weapon _weapon;

    private void Update()
    {
        _text.text = $"Ammo: {_weapon.CurrentAmmo}";
    }
}