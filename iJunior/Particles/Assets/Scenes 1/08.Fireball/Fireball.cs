using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject FireballPrefab;
    public GameObject SpawnPoint;

    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.LookAt(mouse);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(FireballPrefab,SpawnPoint.transform.position, transform.rotation)
                ;
        }
    }
}
