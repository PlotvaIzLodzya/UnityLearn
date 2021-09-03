﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnManager : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject platform;
    [SerializeField] private SpawnItems _spawnItems;
    [SerializeField] private SpawnObstacle _spawnObstacle;
    [SerializeField] private LvlGenerator _lvlGenerator;
    [SerializeField] private GameObject _lavaFloor;
    public GameObject exitKey;
    private GameManager _gameManager;

    public GameObject[] _decorations;

    private Vector3 _lavaStartPos = new Vector3(-20, 0, -20);
    private int _lavaStartAreaOffset = 5;
    private int _widthLavaAmount = 12;
    private Vector3 _platformStartPos = new Vector3(0, 1.25f, 0);
    private Vector3 _cloudsLeftSide = new Vector3(0, 0, -20);
    private Vector3 _cloudsRightSide = new Vector3(0, 0, 30);

    private float _distance = 4;
    public int ObstaclesAmount;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _spawnObstacle = GetComponent<SpawnObstacle>();
        ObstaclesAmount = _gameManager.lengthPlatformAmount / 5;
    }
    public void LevelCreation()
    {
        _lvlGenerator.LevelObjectGeneration(platform,
                      _platformStartPos,
                      _distance,
                      _gameManager.lengthPlatformAmount, _gameManager.widthPlatformAmount);

        _lvlGenerator.LevelObjectGeneration(_lavaFloor,
                      _lavaStartPos,
                      _distance,
                      _gameManager.lengthPlatformAmount + _lavaStartAreaOffset,
                      _widthLavaAmount);

        for (int i = 0; i < _gameManager.maxExitKeyAmount; i++)
            _spawnItems.ObjectRandomSpawnOnPillar(exitKey, 2);

        _spawnItems.ObjectRandomSpawnOnPillar(powerUp, 3);

        _lvlGenerator.DecorPlacing(_cloudsLeftSide, _gameManager.lengthPlatformAmount);
        _lvlGenerator.DecorPlacing(_cloudsRightSide, _gameManager.lengthPlatformAmount);

        StartCoroutine(_spawnObstacle.SpawnThrower(ObstacleCatalog.OneWayThrower));

        if(_gameManager.levelCounter > 4)
            StartCoroutine(_spawnObstacle.SpawnThrower(ObstacleCatalog.TwoWayThrower));
        
        if(_gameManager.levelCounter > 5)
            StartCoroutine(_spawnObstacle.SpawnThrower(ObstacleCatalog.TwoWayThrowerShuriken));
    }        
}
