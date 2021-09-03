using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject platform;
    public GameObject[] _throwers;
    [SerializeField] private GameObject lavaFloor;
    [SerializeField] private GameObject lavaFloor2;
    public GameObject exitKey;
    private GameManager _gameManager;

    public GameObject[] _decorations;

    private float powerUpPosY = 3.5f;
    public float platformPosY = 1.25f;
    private float _flameThrowerOffset = 2.0f;
    private Vector3 _lavaStartPos = new Vector3(-20, 0, -20);
    private int _lavaStartAreaOffset = 5;
    private int _widthLavaAmount = 12;
    private Vector3 _platformStartPos = new Vector3(0, 1.25f, 0);

    private float lavaFloorDistance;
    private float lavaCoveringMultiplier = 8;
    private float _distance = 4;
    private int _lastIdnex;

    public int platformCounter;
    private int movingWallsAmount;

    // Start is called before the first frame update
    void Start()
    {

        lavaFloorDistance = lavaFloor.gameObject.GetComponent<BoxCollider>().size.x * lavaFloor.transform.localScale.x;
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        movingWallsAmount = _gameManager.lengthPlatformAmount / 5;
    }
    public void LevelCreation()
    {
        for (int i = 0; i < _gameManager.maxExitKeyAmount; i++)
            ObjectRandomSpawn(exitKey, new Vector3(_gameManager.lengthPlatformAmount / 2, 0, _platformStartPos.z));

        ObjectRandomSpawn(powerUp, new Vector3(_gameManager.lengthPlatformAmount / 4,0, _platformStartPos.z));

        LevelObjectGeneration(lavaFloor2, _lavaStartPos, _distance, _gameManager.lengthPlatformAmount +_lavaStartAreaOffset, _widthLavaAmount);
        LevelObjectGeneration(platform, _platformStartPos, _distance, _gameManager.lengthPlatformAmount, _gameManager.widthPlatformAmount);

        DecorPlacing();

        StartCoroutine(SpawnThrower((int)ObstacleCatalog.OneWayThrower));

        if(_gameManager.levelCounter > 5)
            StartCoroutine(SpawnThrower((int)ObstacleCatalog.TwoWayThrower));
    }

    private Vector3 GenerateRandomPos(int xStartPos, int zStartPos)
    {
        int posX = Random.Range(xStartPos, _gameManager.lengthPlatformAmount) * (int)_distance;
        int posZ = Random.Range(zStartPos, _gameManager.widthPlatformAmount) * (int)_distance;
        Vector3 position = new Vector3(posX, powerUpPosY, posZ);
        return position;
    }
    

    private void LevelObjectGeneration(GameObject _object, Vector3 startPos, float _distance, int xPlatformAmount, int zPlatformAmount)
    {
        for (int x = 0; x < xPlatformAmount; x++)
        {
            for (int z = 0; z < zPlatformAmount; z++)
            {
                float posX = startPos.x + x * _distance;
                float posZ = startPos.z + z * _distance;
                Vector3 platformPos = new Vector3(posX, _object.transform.position.y, posZ); ;
                Instantiate(_object, platformPos, _object.transform.rotation);
            }
        }
    }

    private void DecorPlacing()
    {
        for (int i = 1; i <= _gameManager.lengthPlatformAmount / lavaCoveringMultiplier; i++)
        {
            float posX = i * lavaFloorDistance;
            DecorPlacing(posX, -20);
            DecorPlacing(posX, 30);            
        }
    }

    private void DecorPlacing(float posX, float posZ)
    {
        int curIndex = Random.Range(0, _decorations.Length);
        if (curIndex != _lastIdnex)
        {
            Instantiate(_decorations[curIndex], new Vector3(posX, 0, posZ), _decorations[curIndex].transform.rotation);
            _lastIdnex = curIndex;
        }
        else
            DecorPlacing(posX, posZ);
    }


    private void FlameThrowerCreation(int throwerIndex)
    {
        for(int i = 0; i < movingWallsAmount; i++)
        {
            float posX = Random.Range(2, _gameManager.lengthPlatformAmount) * _distance - _flameThrowerOffset;
            float posZ = -15.0f;
            Vector3 wallPos = new Vector3(posX, _throwers[throwerIndex].transform.position.y, posZ);
            Instantiate(_throwers[throwerIndex], wallPos, _throwers[throwerIndex].transform.rotation);
        }
    }

    public void ObjectRandomSpawn(GameObject objectToSpawn, Vector3 _startPos)
    {
        Instantiate(objectToSpawn, GenerateRandomPos((int)_startPos.x, (int)_startPos.z), objectToSpawn.transform.rotation);
    }

    IEnumerator SpawnThrower(int throwerIndex)
    {
        while (true)
        {
            int spawnRate = Random.Range(5, 10);
            yield return new WaitForSeconds(spawnRate);
            FlameThrowerCreation(throwerIndex);
        }
    }
}
