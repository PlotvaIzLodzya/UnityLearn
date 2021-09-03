using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamerThrower : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    private float leftMaxPos = 40.0f;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private ParticleSystem[] _particales;
    private GameManager _gameManager;
    public ObstacleCatalog _throwerName;
    // Start is called before the first frame update
    void Start()
    {
        foreach (ParticleSystem particle in _particales)
            particle.Play();
            
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.World);
        DestroyOutOfBounds();
        transform.Rotate(Vector3.right * _rotationSpeed * Time.deltaTime);
    }

        private void DestroyOutOfBounds()
        {
            if(transform.position.z > leftMaxPos)
                Destroy(gameObject);
        }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _gameManager.PlayerReborn();
    }
}
