using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    private float powerUpPosY = 3.5f;

    public void ObjectRandomSpawnOnPillar(GameObject objectToSpawn, int _magicDivider)
    {
        Instantiate(objectToSpawn,
                    SpawnOnPlatforms(_magicDivider),
                    objectToSpawn.transform.rotation);
    }

    private Vector3 SpawnOnPlatforms(int _magicDivider)
    {
        PositionOnScene[] _pillarsPos = FindObjectsOfType<PositionOnScene>();
        int _index = Random.Range(0, _pillarsPos.Length / _magicDivider); // this _magicDivider give me opprtunity to spawn thing in the end of line. For example if _magicDivider = 2 it will get all pillars in second half of the line, i just hope it will work in all situation xD, the more divider is the closes to the end of the line it will pick pillars
        Vector3 _offset = new Vector3(0, powerUpPosY, 0);
        return _pillarsPos[_index].GetPos() + _offset;
    }
}
