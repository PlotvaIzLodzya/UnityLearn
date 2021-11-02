using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpellView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _upgradeButton;

    private Spell _spell;

    public event UnityAction<Spell> UpgradeButtonClick;

    private void OnEnable()
    {
        _upgradeButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _upgradeButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(Spell weapon)
    {
        _spell = weapon;
        _label.text = weapon.Label;
        _upgradeButton.image.sprite = weapon.Icon;
    }

    private void OnButtonClick()
    {
        UpgradeButtonClick?.Invoke(_spell);
    }
}
