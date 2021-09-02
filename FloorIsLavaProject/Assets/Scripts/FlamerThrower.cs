using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ThrowerCatalog
{
    OneWayThrower,
    TwoWayThrower
}
public class FlamerThrower : MonoBehaviour
{
    public float speed = 3;
    private float leftMaxPos = 40.0f;
    [SerializeField] private ParticleSystem[] _particales;
    private GameManager _gameManager;
    [SerializeField] ThrowerCatalog thrower;
    // Start is called before the first frame update
    void Start()
    {   
        foreach(ParticleSystem particle in _particales)
        {
            particle.Play();
        }
            
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        DestroyOutOfBounds();
        if(this.thrower == ThrowerCatalog.TwoWayThrower)
        {
            transform.Rotate(Vector3.right * speed*10* Time.deltaTime);
        }
    }

    private void DestroyOutOfBounds()
    {
        if(transform.position.z > leftMaxPos)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _gameManager.PlayerReborn();
    }
}
