using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;
    [SerializeField] private GameObject _spawnArea;
    [SerializeField] private int _gravityModifier;
    public bool isPreparationTime = false;
    public double _time;
    private double _currentLevelTimeComplition;
    public double bestTime;
    private int objectsAmount = 10;
    public float _forceMultiplier;
    public int _count;

    // Start is called before the first frame update
    void Start()
    {
        bestTime = 20.51f;
        ThrowingObjects();
        Physics.gravity *= _gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        LevelComplition();
    }

    private void ThrowingObjects()
    {
        for(int i = 0; i < objectsAmount; i++)
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


    public void LevelComplition()
    {
        if(_count == objectsAmount)
        {
            _currentLevelTimeComplition = _time;
            Debug.Log("Congratulations!");
            BurningTrash();
            TimeWriter();
            ThrowingObjects();
            StartCoroutine("LevelCreation");
        }
    }

    public void LvlCreation()
    {
        ThrowingObjects();
    }

    public void BurningTrash()
    {
        GameObject[] trashOnLevel = GameObject.FindGameObjectsWithTag("Trash");
        foreach(GameObject trash in trashOnLevel)
        {
            Destroy(trash.gameObject);
        }
    }

    public void TimeWriter()
    {
        if (bestTime > _currentLevelTimeComplition)
        {
            bestTime = _currentLevelTimeComplition;
        }
    }

    IEnumerator LevelCreation()
    {
        isPreparationTime = true;
        yield return new WaitForSeconds(3);
        _time = 0;
        isPreparationTime = false;

        
    }

}
