using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AreaId : MonoBehaviour
{
    public SpawnAreaCatalog _areaName;
    // Start is called before the first frame update
    void Start()
    {
        _areaName = FindObjectOfType<BackgroundSpawns>().GetComponent<SpawnAreaCatalog>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
