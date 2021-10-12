using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoint;
    [SerializeField] private Coin _coin;
    [SerializeField] private Coin _coinOnScene;

    private void Update()
    {
        if (_coinOnScene == null) 
            SpawnCoin();
    }

    private void SpawnCoin()
    {
        int spawnIndex = Random.Range(0, _spawnPoint.Count);
        _coinOnScene = Instantiate(_coin, _spawnPoint[spawnIndex].position, Quaternion.identity);
    }
}
