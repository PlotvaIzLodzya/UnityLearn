using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Coin _coin;
    private Coin _coinOnScene;

    private void Update()
    {
        if (_coinOnScene == null) 
            SpawnCoin();
    }

    private void SpawnCoin()
    {
        int spawnIndex = Random.Range(0, _spawnPoints.Count);
        _coinOnScene = Instantiate(_coin, _spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}
