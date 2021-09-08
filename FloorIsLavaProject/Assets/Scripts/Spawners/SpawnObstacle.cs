using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    GameManager _gameManager;
    LevelConstructor _spawnManager;
    float _distance = 4.0f;
    float _flameThrowerOffset = 2.0f;
    [SerializeField] GameObject[] throwers;

    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = FindObjectOfType<LevelConstructor>().GetComponent<LevelConstructor>();
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
    private void FlameThrowerCreation(ObstacleCatalog _thrower)
    {
        for (int i = 0; i < _spawnManager.ObstaclesAmount; i++)
        {
            float posX = Random.Range(2, _spawnManager.lengthPlatformAmount) * _distance - _flameThrowerOffset;
            float posZ = -15.0f;
            Vector3 _flameThrowerPos = new Vector3(posX, throwers[ThrowerPicker(_thrower)].transform.position.y, posZ);

            Instantiate(throwers[ThrowerPicker(_thrower)],
                        _flameThrowerPos,
                        throwers[ThrowerPicker(_thrower)].transform.rotation);
        }
    }

    private int ThrowerPicker(ObstacleCatalog _thrower)
    {
        var index = 0;
        for (int i = 0; i < throwers.Length; i++)
        {
            if (_thrower == throwers[i].GetComponent<FlameThrower>().throwerName)
                index = i;
        }
        return index;
    }
}
