using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ObstacleCatalog
{
    OneWayThrower,
    TwoWayThrower,
    TwoWayThrowerShuriken
}


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
    private ObstacleCatalog _thrower;

    private float powerUpPosY = 3.5f;
    public float platformPosY = 1.25f;
    private float _flameThrowerOffset = 2.0f;
    private Vector3 _lavaStartPos = new Vector3(-20, 0, -20);
    private int _lavaStartAreaOffset = 5;
    private int _widthLavaAmount = 12;
    private Vector3 _platformStartPos = new Vector3(0, 1.25f, 0);
    private Vector3 _cloudsLeftSide = new Vector3(0, 0, -20);
    private Vector3 _cloudsRightSide = new Vector3(0, 0, 30);

    private float _distance = 4;
    private int _lastIdnex;

    public int platformCounter;
    private int ObstaclesAmount;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        ObstaclesAmount = _gameManager.lengthPlatformAmount / 5;
    }
    public void LevelCreation()
    {
        LevelObjectGeneration(platform,
                      _platformStartPos,
                      _distance,
                      _gameManager.lengthPlatformAmount, _gameManager.widthPlatformAmount);

        LevelObjectGeneration(lavaFloor2,
                      _lavaStartPos,
                      _distance,
                      _gameManager.lengthPlatformAmount + _lavaStartAreaOffset,
                      _widthLavaAmount);

        for (int i = 0; i < _gameManager.maxExitKeyAmount; i++)
            ObjectRandomSpawnOnPillar(exitKey, 2);

        ObjectRandomSpawnOnPillar(powerUp, 3);

        DecorPlacing(_cloudsLeftSide, _gameManager.lengthPlatformAmount);
        DecorPlacing(_cloudsRightSide, _gameManager.lengthPlatformAmount);

        StartCoroutine(SpawnThrower(ObstacleCatalog.OneWayThrower));

        if(_gameManager.levelCounter > 4)
            StartCoroutine(SpawnThrower(ObstacleCatalog.TwoWayThrower));
        
        if(_gameManager.levelCounter > 5)
            StartCoroutine(SpawnThrower(ObstacleCatalog.TwoWayThrowerShuriken));
    }    

    private void LevelObjectGeneration(GameObject _object, Vector3 startPos, float _distance, int xObjectAmount, int zObjectAmount)
    {
        for (int x = 0; x < xObjectAmount; x++)
        {
            for (int z = 0; z < zObjectAmount; z++)
            {
                Instantiate(_object,
                            CalculatePos(startPos, _distance, new Vector3( x, _object.transform.position.y, z)),
                            _object.transform.rotation);
            }
        }
    }

    private void DecorPlacing(Vector3 _startPos, int length)
    {
        for (int _xPos = 1; _xPos <= length; _xPos++)
        {
            int index = DecorChooser();
            Instantiate(_decorations[index],
                        CalculatePos(_startPos, _distance, new Vector3(_xPos, 0, _decorations[index].transform.position.y)),
                        _decorations[index].transform.rotation);
        }
    }

    public void ObjectRandomSpawnOnPillar(GameObject objectToSpawn, int _magicDivider)
    {
        Instantiate(objectToSpawn,
                    SpawnOnPillar(_magicDivider),
                    objectToSpawn.transform.rotation);
    }

    IEnumerator SpawnThrower(ObstacleCatalog _thrower)
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
        for (int i = 0; i < ObstaclesAmount; i++)
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
        for(int i = 0; i<_throwers.Length; i++)
        {
            if (_thrower == _throwers[i].GetComponent<FlamerThrower>()._throwerName)
                index = i;
        }
        return index;
    }

    private Vector3 CalculatePos(Vector3 startPos, float _distance, Vector3 _pos)
    {
        float posX = startPos.x + _pos.x * _distance;
        float posZ = startPos.z + _pos.z * _distance;
        Vector3 _objectPos = new Vector3(posX, _pos.y, posZ);
        return _objectPos;
    }

    private int DecorChooser()
    {
        int curIndex = Random.Range(0, _decorations.Length);
        if (curIndex != _lastIdnex)
            _lastIdnex = curIndex;
        else
            DecorChooser();

        return curIndex;
    }
    
    private Vector3 SpawnOnPillar(int _magicDivider)
    {
        PositionOnScene[] _pillarsPos = FindObjectsOfType<PositionOnScene>();
        int _index = Random.Range(0, _pillarsPos.Length / _magicDivider); // this _magicDivider give me opprtunity to spawn thing in the end of line. For example if _magicDivider = 2 it will get all pillars in second half of the line, i just hope it will work in all situation xD, the more divider is the closes to the end of the line it will pick pillars
        Vector3 _offset = new Vector3(0, powerUpPosY, 0);
        return _pillarsPos[_index].GetPos()+ _offset;
    }
}
