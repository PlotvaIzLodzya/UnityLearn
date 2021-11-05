using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private bool _isPenetrative;

    private int _damage;

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
        if(collision.gameObject.TryGetComponent(out Damagable damagable) && collision.gameObject.TryGetComponent(out Player player) == false)
        {
            damagable.TakeDamage(_damage);

            if(!_isPenetrative)
                Destroy(gameObject);
        }
    }

    private IEnumerator TimerUntilDestroy()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}
