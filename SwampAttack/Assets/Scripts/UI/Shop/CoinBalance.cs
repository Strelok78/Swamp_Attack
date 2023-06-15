using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _coins.text = _player.Coins.ToString();
    }
}