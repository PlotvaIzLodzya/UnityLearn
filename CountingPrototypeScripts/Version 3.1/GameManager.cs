using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _garbage;
    [SerializeField] private GameObject _spawnArea;
    [SerializeField] private int _gravityModifier = 8;
    [SerializeField] private Sound _soundManager;
    private Interface _interfaceScript;
    public double _time;
    private double _currentLevelTimeComplition;
    public double _bestTime;
    public bool isPreparationTime;
    public int objectsAmount = 10;
    public float _forceMultiplier =2000;
    public float _maxSpeed;
    public int _count;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= _gravityModifier;
        _bestTime = 999;

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
                    RandomSpawnPosInBoxCollider(_spawnArea),
                    Quaternion.Euler(0, yAngle, 0));
    }


    public Vector3 RandomSpawnPosInBoxCollider(GameObject _spawnArea)
    {
        Vector3 center = _spawnArea.transform.position;
        float halfSizeX = _spawnArea.GetComponent<BoxCollider>().bounds.extents.x;
        float halfSizeY = _spawnArea.GetComponent<BoxCollider>().bounds.extents.y;
        float halfSizeZ = _spawnArea.GetComponent<BoxCollider>().bounds.extents.z;
        float posX = Random.Range(-halfSizeX, halfSizeX);
        float posY = Random.Range(-halfSizeY, halfSizeY);
        float posZ = Random.Range(-halfSizeZ, halfSizeZ);
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

