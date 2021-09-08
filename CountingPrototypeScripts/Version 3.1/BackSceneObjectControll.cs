using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSceneObjectControll : MonoBehaviour
{
    [SerializeField] public float _speed;

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillBox"))
            Destroy(gameObject);
    }
}
