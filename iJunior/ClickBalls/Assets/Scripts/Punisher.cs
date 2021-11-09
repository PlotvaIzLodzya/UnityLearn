using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punisher : MonoBehaviour
{
    [SerializeField] private int _damage;

    private Player _player;

    private float _bottomBorder;

    private void Start()
    {
        _bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        float radius = GetComponent<Renderer>().bounds.extents.magnitude;
        _bottomBorder -= radius;
    }

    private void Update()
    {
        if (transform.position.y < _bottomBorder)
        {
            _player.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void Init(Player player)
    {
        _player = player;
    }
}
