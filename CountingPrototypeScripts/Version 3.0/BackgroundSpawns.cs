using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawns : MonoBehaviour
{
    private GameManager _gameManagerScript;
    [SerializeField] GameObject[] _spawnAreas;
    [SerializeField] GameObject[] _cititzenPrefabs;
    [SerializeField] GameObject[] _carPrefabs;
    private int carSpawnAreaIndex = 0;
    private int CitizenSpawnAreaRightIndex = 1;
    private int CitizenSpawnAreaLeftIndex = 2;
    private float minSpawnTime = 5;
    private float maxSpawnTime = 15;

    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        StartCoroutine(BackSceneRuler(_carPrefabs, _spawnAreas[carSpawnAreaIndex], 180.0f));
        StartCoroutine(BackSceneRuler(_cititzenPrefabs, _spawnAreas[CitizenSpawnAreaRightIndex], 180.0f));
        StartCoroutine(BackSceneRuler(_cititzenPrefabs, _spawnAreas[CitizenSpawnAreaLeftIndex], 0));
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void ObjectSpawn(GameObject[] _objectToSpawn, GameObject _spawnArea, float angle)
    {
        int prefabIndex = Random.Range(0, _objectToSpawn.Length);
        Instantiate(_objectToSpawn[prefabIndex],
                    _gameManagerScript.RandomSpawnPosInArea(_spawnArea),
                    Quaternion.Euler(0, angle, 0));
    }

    IEnumerator BackSceneRuler(GameObject[] _objectPrefabs, GameObject _spawnArea, float angle)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            ObjectSpawn(_objectPrefabs, _spawnArea, angle);
        }
    }
}
