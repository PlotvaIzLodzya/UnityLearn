using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    GameManager _gameManager;
    SpawnManager _spawnManager;
    float _distance = 4.0f;
    float _flameThrowerOffset = 2.0f;
    public GameObject[] _throwers;

    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>().GetComponent<SpawnManager>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator SpawnThrower(ObstacleCatalog _thrower)
    {
        while (true)
        {
            int spawnRate = Random.Range(5, 10);
            yield return new WaitForSeconds(spawnRate);
            FlameThrowerCreation(_thrower);
        }
    }
    public void FlameThrowerCreation(ObstacleCatalog _thrower)
    {
        for (int i = 0; i < _spawnManager.ObstaclesAmount; i++)
        {
            float posX = Random.Range(2, _gameManager.lengthPlatformAmount) * _distance - _flameThrowerOffset;
            float posZ = -15.0f;
            Vector3 _flameThrowerPos = new Vector3(posX, _throwers[ThrowerPicker(_thrower)].transform.position.y, posZ);

            Instantiate(_throwers[ThrowerPicker(_thrower)],
                        _flameThrowerPos,
                        _throwers[ThrowerPicker(_thrower)].transform.rotation);
        }
    }

    private int ThrowerPicker(ObstacleCatalog _thrower)
    {
        int index = 0;
        for (int i = 0; i < _throwers.Length; i++)
        {
            if (_thrower == _throwers[i].GetComponent<FlameThrower>()._throwerName)
                index = i;
        }
        return index;
    }
}
