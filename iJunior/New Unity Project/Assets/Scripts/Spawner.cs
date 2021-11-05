using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;

    private int _deadEnemyCounter;
    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemyDead;
    public event UnityAction<int, int> EnemyCountChanged;
    public event UnityAction AllWavesCompleted;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if(_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
        }

        if(_currentWave.Count <= _spawned)
        {
            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
        int templateIndex = Random.Range(0, _waves[_currentWaveNumber].Templates.Length);

        Enemy enemy = Instantiate(_currentWave.Templates[templateIndex], _spawnPoints[spawnPointIndex].position, _spawnPoints[spawnPointIndex].rotation).GetComponent<Enemy>();

        if(enemy.TryGetComponent<EnemyStateMachine>(out EnemyStateMachine enemyStateMachine))
            enemyStateMachine.Init(_player);

        enemy.Dying += OnEnemyDied;
    }

    private void SetWave(int index)
    {
         _currentWave = _waves[index];

        EnemyCountChanged?.Invoke(0, 1);
    }

    public void NextWave()
    {
        if (_currentWaveNumber < _waves.Count && _deadEnemyCounter >= _waves[_currentWaveNumber].Count)
        {
            SetWave(_currentWaveNumber);
            _spawned = 0;
            _deadEnemyCounter = 0;
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _deadEnemyCounter++;

        if (_deadEnemyCounter >= _waves[_currentWaveNumber].Count)
        {
            AllEnemyDead?.Invoke();
            _currentWaveNumber++;

            if (_currentWaveNumber >= _waves.Count)
            {
                AllWavesCompleted?.Invoke();
            }
        }

        enemy.Dying -= OnEnemyDied;
    }
}

[System.Serializable]
public class Wave
{
    public Enemy[] Templates;
    public float Delay;
    public int Count;
}
