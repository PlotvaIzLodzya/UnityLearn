using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Vector3> _spawnPoints;
    [SerializeField] private List<GameObject> _enemys;
    [SerializeField] private WaitForSeconds _spawnRate;
    [SerializeField] private float _spawnCooldown = 2;
    [SerializeField] private bool _isGameActive = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemys());
    }

    private IEnumerator SpawnEnemys()
    {
        _spawnRate = new WaitForSeconds(_spawnCooldown);

        while (_isGameActive) 
        {
            int enemyIndex = Random.Range(0, _enemys.Count);
            int spawnIndex = Random.Range(0, _spawnPoint.Count);
            Instantiate(_enemys[enemyIndex], _spawnPoints[spawnIndex], Quaternion.identity);
            yield return _spawnRate;
        }
    }
}
