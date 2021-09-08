using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelConstructor : MonoBehaviour
{
    [SerializeField] private GameObject powerUp;
    [SerializeField] private GameObject exitKey;
    [SerializeField] private GameObject platform;
    [SerializeField] private SpawnItems _spawnItems;
    [SerializeField] private SpawnObstacle _spawnObstacle;
    [SerializeField] private GameObject _lavaFloor;
    [SerializeField] private LvlGenerator _lvlGenerator;
    private GameManager _gameManager;

    private Vector3 _lavaStartPos = new Vector3(-20, 0, -20);
    private int _lavaStartAreaOffset = 5;
    private int _widthLavaAmount = 12;
    private Vector3 _platformStartPos = new Vector3(0, 1.25f, 0);
    private Vector3 _cloudsLeftSide = new Vector3(0, 0, -20);
    private Vector3 _cloudsRightSide = new Vector3(0, 0, 30);

    private float _distance = 4;
    public int ObstaclesAmount;

    public int lengthPlatformAmount;
    public int widthPlatformAmount;
    public int platformAmountPerLvl = 5;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _spawnObstacle = GetComponent<SpawnObstacle>();
        ObstaclesAmount = lengthPlatformAmount / 5;
    }
    public void LevelCreation()
    {
        lengthPlatformAmount = _gameManager.levelCounter * platformAmountPerLvl;

        _lvlGenerator.LevelObjectPlacing(platform,
                                         _platformStartPos,
                                         _distance,
                                         lengthPlatformAmount, widthPlatformAmount);

        _lvlGenerator.LevelObjectPlacing(_lavaFloor,
                                         _lavaStartPos,
                                         _distance,
                                         lengthPlatformAmount + _lavaStartAreaOffset,
                                         _widthLavaAmount);

        for (int i = 0; i < _gameManager.maxExitKeyAmount; i++)
            _spawnItems.ObjectRandomSpawnOnPlatform(exitKey, 2);

        _spawnItems.ObjectRandomSpawnOnPlatform(powerUp, 3);

        _lvlGenerator.LevelBordersPlacing(_cloudsLeftSide, lengthPlatformAmount);
        _lvlGenerator.LevelBordersPlacing(_cloudsRightSide, lengthPlatformAmount);

        StartCoroutine(_spawnObstacle.SpawnThrower(ObstacleCatalog.OneWayThrower));

        if(_gameManager.levelCounter > 4)
            StartCoroutine(_spawnObstacle.SpawnThrower(ObstacleCatalog.TwoWayThrower));
        
        if(_gameManager.levelCounter > 5)
            StartCoroutine(_spawnObstacle.SpawnThrower(ObstacleCatalog.TwoWayThrowerShuriken));
    }        
}
