using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _decorations;
    private int _lastIdnex;
    private float _distance = 4.0f;

    public void LevelObjectPlacing(GameObject _object, Vector3 _startPos, float _distance, int _xObjectAmount, int _zObjectAmount)
    {
        for (int x = 0; x < _xObjectAmount; x++)
        {
            for (int z = 0; z < _zObjectAmount; z++)
            {
                Instantiate(_object,
                            CalculatePos(_startPos, _distance, new Vector3(x, _object.transform.position.y, z)),
                            _object.transform.rotation);
            }
        }
    }
    public void LevelBordersPlacing(Vector3 _startPos, int _length)
    {
        for (int _xPos = 1; _xPos <= _length; _xPos++)
        {
            int index = DecorChooser();
            Instantiate(_decorations[index],
                        CalculatePos(_startPos, _distance, new Vector3(_xPos, 0, _decorations[index].transform.position.y)),
                        _decorations[index].transform.rotation);
        }
    }
    private Vector3 CalculatePos(Vector3 _startPos, float _distance, Vector3 _pos)
    {
        var posX = _startPos.x + _pos.x * _distance;
        var posZ = _startPos.z + _pos.z * _distance;
        
        return new Vector3(posX, _pos.y, posZ);
    }

    private int DecorChooser()
    {
        var curIndex = Random.Range(0, _decorations.Length);
        if (curIndex != _lastIdnex)
            _lastIdnex = curIndex;
        else
            DecorChooser();

        return curIndex;
    }
}
