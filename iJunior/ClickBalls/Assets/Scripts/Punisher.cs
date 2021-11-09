using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punisher : MonoBehaviour
{
    [SerializeField] private int _damage;

    private Player _player;

    private float _bottomBorder;

    private void Update()
    {
        if (transform.position.y < _bottomBorder)
        {
            _player.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void Init(Player player, float bottomBorder)
    {
        _player = player;
        float radius = GetComponent<Renderer>().bounds.extents.magnitude;
        _bottomBorder = bottomBorder - radius;
    }
}
