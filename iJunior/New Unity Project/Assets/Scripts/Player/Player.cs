using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<Spell> _spells;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private Transform _castPoint;  
    [SerializeField] private int _curentSpellIndex = 0;

    private bool _isGrounded;
    private Spell _currentSpell;
    private Animator _animator;

    public bool IsGrounded => _isGrounded;
    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public Transform CastPoint => _castPoint;
    public Spell CurrentSpell => _currentSpell;
    public List<Spell> Spells => _spells;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = _maxHealth;
        ChangeSpell(_spells[_curentSpellIndex]);
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void CastSpell()
    {
        _currentSpell.Cast(_castPoint);
    }

    public void NextSpell()
    {
        if (_spells.Count-1 > _curentSpellIndex)
            _curentSpellIndex++;
        else if (_spells.Count-1  == _curentSpellIndex)
            _curentSpellIndex = 0;

        ChangeSpell(_spells[_curentSpellIndex]);
    }

    public void PreviousSpell()
    {
        if (_curentSpellIndex > 0)
            _curentSpellIndex--;
        else if (_curentSpellIndex == 0)
            _curentSpellIndex = _spells.Count-1;

        ChangeSpell(_spells[_curentSpellIndex]);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
            _isGrounded = true;
    }

    public void SetIsGrounded()
    {
        _isGrounded = false;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth,_maxHealth);

        if (_currentHealth <= 0)
            Die();
    }

    public void Heal(int healAmount)
    {
        if (_currentHealth + healAmount < _maxHealth)
            _currentHealth += healAmount;
        else
            _currentHealth = _maxHealth;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void Die()
    {
        _animator.Play("Death");
        this.enabled = false;
        Died?.Invoke();
    }

    public void ChangeSpell(Spell spell)
    {
        _currentSpell = spell;
    }
}
