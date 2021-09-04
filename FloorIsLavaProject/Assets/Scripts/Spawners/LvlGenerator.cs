using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _decorations;
    private int _lastIdnex;
    float _distance = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelObjectGeneration(GameObject _object, Vector3 startPos, float _distance, int xObjectAmount, int zObjectAmount)
    {
        for (int x = 0; x < xObjectAmount; x++)
        {
            for (int z = 0; z < zObjectAmount; z++)
            {
                Instantiate(_object,
                            CalculatePos(startPos, _distance, new Vector3(x, _object.transform.position.y, z)),
                            _object.transform.rotation);
            }
        }
    }
    public void LevelBordersPlacing(Vector3 _startPos, int length)
    {
        for (int _xPos = 1; _xPos <= length; _xPos++)
        {
            int index = DecorChooser();
            Instantiate(_decorations[index],
                        CalculatePos(_startPos, _distance, new Vector3(_xPos, 0, _decorations[index].transform.position.y)),
                        _decorations[index].transform.rotation);
        }
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
}
