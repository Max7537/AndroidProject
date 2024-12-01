using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelecter : MonoBehaviour
{
    [SerializeField] private GameObject WeaponContainer;
    [SerializeField] private PlayerAttack _player;
    [SerializeField] private WeaponCard _weaponCard;

    private void Start()
    {
        for (int i = 0; i < _player.Weapons.Count; i++)
        {
            WeaponCard weaponCard = Instantiate(_weaponCard, WeaponContainer.transform);
            weaponCard.SetImage(_player.Weapons[i].Icon, _player.Weapons[i]._weaponType);
        }
    }
}
