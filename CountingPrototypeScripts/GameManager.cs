using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;
    [SerializeField] private GameObject _spawnArea;
    [SerializeField] private int _gravityModifier;
    private int objectsAmount = 10;
    public float _forceMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        ThrowingObjects();
        Physics.gravity *= _gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        float minPosX = _spawnArea.transform.position.x - _spawnArea.GetComponent<BoxCollider>().size.x / 2;
        float maxPosX = _spawnArea.transform.position.x + _spawnArea.GetComponent<BoxCollider>().size.x / 2;
        float minPosZ = _spawnArea.transform.position.z - _spawnArea.GetComponent<BoxCollider>().size.z / 2;
        float maxPosZ = _spawnArea.transform.position.z + _spawnArea.GetComponent<BoxCollider>().size.z / 2;
        float posX = Random.Range(minPosX, maxPosX);
        float posZ = Random.Range(minPosZ, maxPosZ);
        Vector3 objectPos = new Vector3(posX, _spawnArea.transform.position.y, posZ);
        return objectPos;
    }
}
