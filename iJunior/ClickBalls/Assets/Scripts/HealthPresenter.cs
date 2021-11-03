using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointText;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= UpdateHealth;
    }

    public void UpdateHealth(int health, int maxHealth)
    {
        _pointText.text = $"Жизни: {health}/{maxHealth}";
    }
}
