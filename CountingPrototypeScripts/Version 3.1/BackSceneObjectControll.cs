using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSceneObjectControll : MonoBehaviour
{
    [SerializeField] public float _speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
