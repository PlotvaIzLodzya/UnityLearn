using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MovingCalculator
{
    [SerializeField] private float _speed = 3.0f;
    private float leftMaxPos = 40.0f;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private ParticleSystem[] _particales;
    private GameManager _gameManager;
    public ObstacleCatalog throwerName;
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
        MovingForwardInWorld(_speed);
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
