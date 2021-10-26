using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _money;

    private void OnEnable()
    {
        _money.text = _player.Money.ToString();
        _player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
    }

    public void OnMoneyChanged(int money)
    {
        _money.text = money.ToString();
    }
}
