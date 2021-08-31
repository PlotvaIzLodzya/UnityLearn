using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawns : MonoBehaviour
{
    private GameManager _gameManagerScript;
    [SerializeField] GameObject[] _spawnAreas;
    [SerializeField] GameObject[] _cititzenPrefabs;
    [SerializeField] GameObject[] _carPrefabs;
    private int carSpawnAreaID = 0;
    private int CitizenSpawnAreaRightID = 1;
    private int CitizenSpawnAreaLeftID = 2;
    private float minSpawnTime = 5;
    private float maxSpawnTime = 15;

    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        StartCoroutine(BackSceneRuler(_carPrefabs, _spawnAreas[carSpawnAreaID], 180.0f));
        StartCoroutine(BackSceneRuler(_cititzenPrefabs, _spawnAreas[CitizenSpawnAreaRightID], 180.0f));
        StartCoroutine(BackSceneRuler(_cititzenPrefabs, _spawnAreas[CitizenSpawnAreaLeftID], 0));
    }

    // Update is called once per frame
    void Update()
    {
            
    }


    IEnumerator BackSceneRuler(GameObject[] _objectPrefabs, GameObject _spawnArea, float angle)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            _gameManagerScript.ObjectSpawn(_objectPrefabs, _spawnArea, angle);
        }
    }
}
