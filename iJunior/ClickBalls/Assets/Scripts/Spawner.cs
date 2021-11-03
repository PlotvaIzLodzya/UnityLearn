using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private float _delay;
    [SerializeField] private float _minDelay;
    [SerializeField] private Player _player;
    [SerializeField] private float _increaseSpeedPerSpawn;
    [SerializeField] private float _decreaseDelayPerSpawn;
    
    private float _additionalSpeed;
    private float _lastTimeSpawned = 0;
    private float _leftBorder;
    private float _rightBorder;
    private float _upBorder;
    private float _bottomBorder;
    private float _distanceFromCamera = 20;

    private event UnityAction _ballSpawned;

    private void Start()
    {
        _leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.2f, 0, 0)).x;
        _rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.98f, 0, 0)).x;
        _upBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        _bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    private void OnEnable()
    {
        _ballSpawned += DecreaseDelay;
    }

    private void Update()
    {
        if(Time.time > _lastTimeSpawned + _delay)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(_leftBorder, _rightBorder), _upBorder, _distanceFromCamera);
            SpawnBall(spawnPoint);
            _additionalSpeed += _increaseSpeedPerSpawn;

            _lastTimeSpawned = Time.time;
        }
    }

    private void DecreaseDelay()
    {
        _delay -= _decreaseDelayPerSpawn;
        
        if(_delay<=_minDelay)
            _ballSpawned -= DecreaseDelay;
    }

    public void SpawnBall(Vector3 spawnPoint)
    {
        Ball ball = Instantiate(_ball, spawnPoint, Quaternion.identity);
        ball.Init(_player, _bottomBorder, _additionalSpeed);
        _ballSpawned?.Invoke();
    }
}
