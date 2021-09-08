using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundSpawns : MonoBehaviour
{
    private GameManager _gameManagerScript;
    [SerializeField] GameObject[] _spawnAreas;
    [SerializeField] GameObject[] _cititzenPrefabs;
    [SerializeField] GameObject[] _carPrefabs;

    [SerializeField]private float minSpawnTime = 1;
    [SerializeField]private float maxSpawnTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        StartCoroutine(BackSceneRuler(_carPrefabs, GetArea(SpawnAreaCatalog.CarSpawnArea), 180.0f));
        StartCoroutine(BackSceneRuler(_cititzenPrefabs, GetArea(SpawnAreaCatalog.RightSpawnArea), 180.0f));
        StartCoroutine(BackSceneRuler(_cititzenPrefabs, GetArea(SpawnAreaCatalog.LeftSpawnArea), 0));
    }


    public GameObject GetArea(SpawnAreaCatalog spawnAreaId)
    { 
        int index = 0;
        {
            for (int i = 0; i < _spawnAreas.Length; i++)
            {
                if (spawnAreaId == _spawnAreas[i].GetComponent<AreaId>()._areaName)
                    index = i;
            }
        }
        return _spawnAreas[index];
    }


    IEnumerator BackSceneRuler(GameObject[] _objectPrefabs, GameObject _spawnArea, float yAngle)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            _gameManagerScript.ObjectSpawn(_objectPrefabs, _spawnArea, yAngle);
        }
    }
}
