using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SpellView _template;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private Spawner _spawner;

    public Spawner Spawner => _spawner;

    private void Start()
    {
        for (int i = 0; i < _player.Spells.Count; i++)
        {
            AddItem(_player.Spells[i]);
        }
    }

    private void OnDisable()
    {
        _template.UpgradeButtonClick -= OnUpgradeButtonClick;
    }

    private void AddItem(Spell spell)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.UpgradeButtonClick += OnUpgradeButtonClick;
        view.Render(spell);
    }

    private void OnUpgradeButtonClick(Spell spell)
    {
        gameObject.SetActive(false);
        spell.IncreaseDamage(spell.DamagePerUpgrade);
        _spawner.NextWave();
    } 
}
