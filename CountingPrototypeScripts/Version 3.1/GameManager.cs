using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _garbage;
    [SerializeField] private GameObject _spawnArea;
    [SerializeField] private int _gravityModifier;
    [SerializeField] private Sound _soundManager;
    private Interface _interfaceScript;
    public double _time;
    private double _currentLevelTimeComplition;
    public double _bestTime;
    public bool isPreparationTime;
    public int objectsAmount = 10;
    public float _forceMultiplier =2000;
    public float _masSpeed;
    public int _count;

    // Start is called before the first frame update
    void Start()
    {
        _bestTime = 999;
        Physics.gravity *= _gravityModifier;
        _soundManager = FindObjectOfType<Sound>().GetComponent<Sound>();
        _interfaceScript = FindObjectOfType<Interface>().GetComponent<Interface>();
        StartNewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        LevelComplition();
    }

    public void LitterTheStreet(int amount)
    {
        for(int i = 0; i< amount; i++)
            ObjectSpawn(_garbage, _spawnArea, 0);
    }
    public void ObjectSpawn(GameObject[] _objectToSpawn, GameObject _spawnArea, float yAngle)
    {
        int prefabIndex = Random.Range(0, _objectToSpawn.Length);
        Instantiate(_objectToSpawn[prefabIndex],
                    RandomSpawnPosInArea(_spawnArea),
                    Quaternion.Euler(0, yAngle, 0));
    }


    public Vector3 RandomSpawnPosInArea(GameObject _spawnArea)
    {
        Vector3 center = _spawnArea.transform.position;
        float halfSizeX = _spawnArea.GetComponent<BoxCollider>().size.x * _spawnArea.transform.localScale.x / 2;
        float halfSizeZ = _spawnArea.GetComponent<BoxCollider>().size.z * _spawnArea.transform.localScale.z / 2;
        float halfSizeY = _spawnArea.GetComponent<BoxCollider>().size.y * _spawnArea.transform.localScale.y / 2;
        float posX = Random.Range(-halfSizeX, halfSizeX);
        float posZ = Random.Range(-halfSizeZ, halfSizeZ);
        float posY = Random.Range(-halfSizeY, halfSizeY);
        Vector3 objectPos = new Vector3(posX, posY, posZ);
        return objectPos + center;
    }


    private void LevelComplition()
    {
        if (_count == objectsAmount)
        {
            Debug.Log("Congratulations!");
            TimeWriter();
            BurningTrash();
            StartNewLevel();
        }
    }

    private void BurningTrash()
    {
        GameObject[] trashOnLevel = GameObject.FindGameObjectsWithTag("Trash");
        foreach (GameObject trash in trashOnLevel)
            Destroy(trash.gameObject);
        _soundManager.playSound(_soundManager.burningTrash, _soundManager.burningTrashSoundLevel);
    }

    private void TimeWriter()
    {
        _currentLevelTimeComplition = _time;
        if (_bestTime > _currentLevelTimeComplition)
        {
            _bestTime = _currentLevelTimeComplition;
            _interfaceScript.BestTimeSetting(_bestTime);
        }

    }

    public void isPreparationTimeActive(bool isActive)
    {
        isPreparationTime = isActive;
        _interfaceScript.PreparationOnScreen(isActive);

    }
    public void StartNewLevel()
    {
        isPreparationTimeActive(true);
        LitterTheStreet(objectsAmount);
    }

    public void ApllicationClose()
    {
        Application.Quit();
    }
}

