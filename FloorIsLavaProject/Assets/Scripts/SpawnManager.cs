using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject platform;
    public GameObject[] _throwers;
    public GameObject lavaFloor;
    public GameObject exitKey;
    private GameManager _gameManager;

    public GameObject[] _decorations;

    private float powerUpPosY = 3.5f;
    public float platformPosY = 1.25f;
    private float movingWallsOffset = 2.0f;
    private int xStartPos = 0;
    private int zStartPos = 0;

    private float lavaFloorDistance;
    private float lavaCoveringMultiplier = 8;
    private int distance = 4;
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
            ObjectRandomSpawn(exitKey, _gameManager.lengthPlatformAmount / 2, zStartPos);

        ObjectRandomSpawn(powerUp, _gameManager.lengthPlatformAmount / 4, zStartPos);
        LvlObjectPlacing();
        PlatformPlacing();
        StartCoroutine(SpawnThrower((int)ThrowerCatalog.OneWayThrower));

        if(_gameManager.levelCounter > 5)
            StartCoroutine(SpawnThrower((int)ThrowerCatalog.TwoWayThrower));
    }

    private Vector3 GenerateRandomPos(int xStartPos, int zStartPos)
    {
        int posX = Random.Range(xStartPos, _gameManager.lengthPlatformAmount) * distance;
        int posZ = Random.Range(zStartPos, _gameManager.widthPlatformAmount) * distance;
        Vector3 position = new Vector3(posX, powerUpPosY, posZ);
        return position;
    }
    

    private void PlatformPlacing()
    {
        for(int x = xStartPos; x < _gameManager.lengthPlatformAmount; x++)
        {
            for(int z = zStartPos; z< _gameManager.widthPlatformAmount; z++)
            {
                int posX = x * distance;
                int posZ = z * distance;
                Vector3 platformPos = new Vector3(posX, platformPosY, posZ);
                Instantiate(platform, platformPos, platform.transform.rotation);
            }
        }
    }

    private void LvlObjectPlacing()
    {
        for (int i = 1; i <= _gameManager.lengthPlatformAmount / lavaCoveringMultiplier; i++)
        {
            float posX = i * lavaFloorDistance;
            PlaceDecoration(posX, -20);
            PlaceDecoration(posX, 30);
            Instantiate(lavaFloor, new Vector3(posX, 0, 5), lavaFloor.transform.rotation);
            
        }
    }

    private void PlaceDecoration(float posX, float posZ)
    {
        int curIndex = Random.Range(0, _decorations.Length);
        if (curIndex != _lastIdnex)
        {
            Instantiate(_decorations[curIndex], new Vector3(posX, 0, posZ), _decorations[curIndex].transform.rotation);
            _lastIdnex = curIndex;
        }
        else
            PlaceDecoration(posX, posZ);
    }


    private void FlameThrowerCreation(int throwerIndex)
    {
        for(int i = 0; i < movingWallsAmount; i++)
        {
            
            float posX = Random.Range(2, _gameManager.lengthPlatformAmount) * distance - movingWallsOffset;
            float posZ = -15.0f;
            Vector3 wallPos = new Vector3(posX, _throwers[throwerIndex].transform.position.y, posZ);
            Instantiate(_throwers[throwerIndex], wallPos, _throwers[throwerIndex].transform.rotation);
        }
    }

    public void ObjectRandomSpawn(GameObject objectToSpawn, int xStartPos, int zStartPos)
    {
        Instantiate(objectToSpawn, GenerateRandomPos(xStartPos, zStartPos), objectToSpawn.transform.rotation);
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
