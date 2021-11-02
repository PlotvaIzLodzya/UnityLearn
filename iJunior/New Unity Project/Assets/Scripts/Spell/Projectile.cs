using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private bool _isPenetrative;

    [SerializeField] private int _damage;

    private void Start()
    {
        StartCoroutine(TimerUntilDestroy());
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
        }

        if(!collision.gameObject.TryGetComponent(out Player player) && !_isPenetrative)
            Destroy(gameObject);
    }

    private IEnumerator TimerUntilDestroy()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }

    public void IncreaseDamage(int additionalDamage)
    {
        _damage += additionalDamage;
    }
}
