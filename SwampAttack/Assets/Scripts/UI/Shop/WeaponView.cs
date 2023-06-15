using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClicked);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClicked);
        _sellButton.onClick.RemoveListener(TryLockItem);

    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        _label.text = _weapon.Label;
        _price.text = weapon.Price.ToString();
        _icon.sprite = weapon.Icon;
    }

    private void TryLockItem()
    {
        if (_weapon.IsBought)
            _sellButton.interactable = false;
    }

    private void OnButtonClicked()
    {
        SellButtonClick?.Invoke(_weapon, this);
    }
}
