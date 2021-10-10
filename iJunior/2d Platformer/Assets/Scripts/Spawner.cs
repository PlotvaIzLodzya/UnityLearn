using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawners;
    [SerializeField] private Coin _coin;
    [SerializeField] private Coin _coinOnScene;

    private void Update()
    {
        if (_coinOnScene == null) 
            SpawnEnemys();
    }

    private void SpawnEnemys()
    {
        int spawnerIndex = Random.Range(0, _spawners.Count);
        _coinOnScene = Instantiate(_coin, _spawners[spawnerIndex].transform.position, Quaternion.identity);
    }
}
