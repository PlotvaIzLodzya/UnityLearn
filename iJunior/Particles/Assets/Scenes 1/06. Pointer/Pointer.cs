using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public GameObject PointerPref;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

            if (Physics.Raycast(ray, out hit))
                Instantiate(PointerPref, new Vector3(hit.point.x, hit.point.y + 1, hit.point.z), Quaternion.identity);
        }
    }
}
