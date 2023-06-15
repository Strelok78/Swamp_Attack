using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClicked;
        view.Render(weapon);
    }

    private void OnSellButtonClicked(Weapon weapon, WeaponView view)
    {
        TrySellWeaapon(weapon, view);
    }

    private void TrySellWeaapon(Weapon weapon, WeaponView view)
    {
        if(weapon.Price <= _player.Coins)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            view.SellButtonClick -= OnSellButtonClicked;
        }
    }
}