using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] private int _rewardPoints;
    [SerializeField] private int _damage;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private ParticleSystem _particles;

    private Player _player;
    private float _speed;
    private Material _material;
    private Color _color;
    private float _bottomBorder;

    public float Speed => _speed;

    public event UnityAction<int> Poped;

    [System.Obsolete]
    private void Start()
    {
        _particles.Pause();

        _color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        _particles.startColor = _color;
        _material = GetComponent<Renderer>().material;
        _material.SetColor("_Color", _color);

        _speed = Random.Range(_minSpeed, _maxSpeed);
    }

    private void Update()
    {
        if (transform.position.y < _bottomBorder)
        {
            _player.ApplyDamage(_damage);
            Destroy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Ball>(out Ball ball) == false)
            Destroy();
    }

    public void Init(Player player, float bottomBorder, float speed)
    {
        _player = player;
        float radius = GetComponent<Renderer>().bounds.extents.magnitude;
        _bottomBorder = bottomBorder - radius;
        Poped += _player.AddPoint;
        IncreaseSpeed(speed);
    }

    public void Pop()
    {
        Poped?.Invoke(_rewardPoints);
        _particles.transform.parent = null;
        _particles.Play();
        Destroy();
    }

    private void Destroy()
    {
        Poped -= _player.AddPoint;
        Destroy(gameObject);
    }

    public void IncreaseSpeed(float speed)
    {
        _minSpeed += speed;
        _maxSpeed += speed;
    }
}
