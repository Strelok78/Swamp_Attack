using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private Animator _animator;
    private int _currentHealth;
    private int _currentWeaponIndex;

    public int Coins { get; private set; }

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        SwapWeapon(_weapons[_currentWeaponIndex]);
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if(_currentHealth <= 0 )
            Destroy(gameObject);
    }

    public void AddCoins(int reward)
    {
        Coins += reward;
    }

    public void BuyWeapon(Weapon weapon)
    {
        Coins -= weapon.Price;
        _weapons.Add(weapon);
    }

    public void NextWeapon()
    {
        if(_currentWeaponIndex == _weapons.Count - 1)
            _currentWeaponIndex = 0;
        else 
            _currentWeaponIndex++;

        SwapWeapon(_weapons[_currentWeaponIndex]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponIndex == 0)
            _currentWeaponIndex = _weapons.Count - 1;
        else
            _currentWeaponIndex--;

        SwapWeapon(_weapons[_currentWeaponIndex]);
    }

    private void SwapWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}