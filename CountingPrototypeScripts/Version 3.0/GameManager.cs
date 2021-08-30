using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;
    [SerializeField] private GameObject _spawnArea;
    [SerializeField] private int _gravityModifier;
    private Interface _interfaceScript;
    public double _time;
    private double _currentLevelTimeComplition;
    public double _bestTime;
    public bool isPreparationTime;
    private int objectsAmount = 10;
    public float _forceMultiplier;
    public int _count;

    // Start is called before the first frame update
    void Start()
    {
        _bestTime = 999;
        ThrowingObjects();
        Physics.gravity *= _gravityModifier;
        _interfaceScript = FindObjectOfType<Interface>().GetComponent<Interface>();
        isPreparationTimeActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        LevelComplition();
        Debug.Log(isPreparationTime);
    }

    private void ThrowingObjects()
    {
        for (int i = 0; i < objectsAmount; i++)
        {
            int index = Random.Range(0, _objects.Length);
            Instantiate(_objects[index], RandomSpawnPosInArea(), _objects[index].transform.rotation);
        }
    }

    private Vector3 RandomSpawnPosInArea()
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
            ThrowingObjects();
            isPreparationTimeActive(true);
        }
    }

    private void BurningTrash()
    {
        GameObject[] trashOnLevel = GameObject.FindGameObjectsWithTag("Trash");
        foreach (GameObject trash in trashOnLevel)
        {
            Destroy(trash.gameObject);
        }
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
    public void RestartLevel()
    {
        BurningTrash();
        ThrowingObjects();
        isPreparationTimeActive(true);
        _time = 0;
    }
}

