using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float speed = 3;
    private float leftMaxPos = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward* speed * Time.deltaTime);
        DestroyOutOfBounds();
    }

    private void DestroyOutOfBounds()
    {
        if(transform.position.z > leftMaxPos)
        {
            Destroy(gameObject);
        }
    }
}
