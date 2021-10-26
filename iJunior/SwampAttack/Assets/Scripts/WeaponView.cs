using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellBbutton;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> SellButtonClick;

    private void OnEnable()
    {
        _sellBbutton.onClick.AddListener(OnButtonClick);
        _sellBbutton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellBbutton.onClick.RemoveListener(OnButtonClick);
        _sellBbutton.onClick.RemoveListener(TryLockItem);
    }

    private void TryLockItem()
    {
        if (_weapon.IsBuyed)
            _sellBbutton.interactable = false;
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _label.text = weapon.Label;
        _price.text = weapon.Price.ToString();
        _icon.sprite = weapon.Icon;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_weapon, this);
    }
}
