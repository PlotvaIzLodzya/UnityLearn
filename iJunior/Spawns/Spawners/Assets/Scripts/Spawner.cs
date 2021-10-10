using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawners;
    [SerializeField] private List<GameObject> _enemys;
    [SerializeField] private WaitForSeconds _spawnRate = new WaitForSeconds(2);
    [SerializeField] private bool _isGameActive = true;

    private void Start()
    {
        Debug.Log(_spawners.Count + " " + _enemys.Count);
        StartCoroutine(SpawnEnemys());
    }

    private IEnumerator SpawnEnemys()
    {
        while (_isGameActive) 
        {
            int enemyIndex = Random.Range(0, _enemys.Count);
            int spawnerIndex = Random.Range(0, _spawners.Count);
            Instantiate(_enemys[enemyIndex], _spawners[spawnerIndex].transform.position, Quaternion.identity);
            yield return _spawnRate;
        }
    }
}
