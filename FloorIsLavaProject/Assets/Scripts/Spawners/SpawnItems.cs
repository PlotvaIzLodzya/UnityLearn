using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    private float _powerUpPosY = 3.2f;

    public void ObjectRandomSpawnOnPlatform(GameObject _objectToSpawn, int _magicDivider)
    {
        Instantiate(_objectToSpawn,
                    SpawnOnPlatforms(_magicDivider),
                    _objectToSpawn.transform.rotation);
    }

    private Vector3 SpawnOnPlatforms(int _magicDivider)
    {
        PlatformPosOnScene[] _platformsPos = FindObjectsOfType<PlatformPosOnScene>();
        var _index = Random.Range(0, _platformsPos.Length / _magicDivider); // this _magicDivider give me opprtunity to spawn thing in the end of line. For example if _magicDivider = 2 it will get all pillars in second half of the line, i just hope it will work in all situation xD, the more divider is the closes to the end of the line it will pick pillars
        Vector3 _offset = new Vector3(0, _powerUpPosY, 0);
        return _platformsPos[_index].GetPos() + _offset;
    }
}
