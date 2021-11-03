using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    private RaycastHit _hit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hit))
            {
                Transform objectHit = _hit.transform;

                if (objectHit.gameObject.TryGetComponent<Ball>(out Ball ball))
                    ball.Pop();
            }
        }
    }
}
