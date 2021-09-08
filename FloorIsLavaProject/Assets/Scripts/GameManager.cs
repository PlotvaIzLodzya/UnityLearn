using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] GameObject _player;
    public GameObject rebornPos;
    [SerializeField] CinemachineFreeLook _camera;
    [SerializeField] ParticleSystem _rebornParticle;
    private GameObject[] platforms;
    private LevelConstructor _spawnManager;
    private GameObject powerUp;
    [SerializeField] float _yPosDestroyBounds = -350;


    public int exitKeyCounter = 0;
    public int maxExitKeyAmount = 1;
    public int levelCounter = 1 ;

    [SerializeField] private int _maxDuration = 6;
    [SerializeField] private int _minDuration = 3;


    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = FindObjectOfType<LevelConstructor>().GetComponent<LevelConstructor>();
        _spawnManager.LevelCreation();
        _player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BoundsForThePlayer();
        LevelComplition();
    }

    public void LevelComplition()
    {
        if (exitKeyCounter >= maxExitKeyAmount)
        {

            exitKeyCounter = 0;
            levelCounter++;
            SetExitKeyAmout();
            DestroyingWorld();
            
            _spawnManager.LevelCreation();
            PlayerReborn();
        }
    }

    public void PlayerReborn()
    {   
        _rebornParticle.Play();
        StartCoroutine(PlayerRebirth());
        Vector3 _cameraOffset = new Vector3(5, 0, 0);
        _camera.ForceCameraPosition(rebornPos.transform.position - _cameraOffset, Quaternion.Euler(Vector3.zero));
        _camera.m_YAxis.Value = 1.0f;
    }

    private void DestroyingWorld()
    {
        platforms = GameObject.FindGameObjectsWithTag("Ground");
        for (int i = 0; i < platforms.Length; i++)
        {
            if (platforms[i].gameObject.name !="StartPos") 
            { 
                Destroy(platforms[i]);
            }    
        }
        powerUp = GameObject.FindGameObjectWithTag("PowerUp");
        Destroy(powerUp);
    }

    public int DurationGeneration()
    {
        return Random.Range(_minDuration, _maxDuration);
    }

    public bool IsPlatformStatic()
    {
        return Random.Range(0,10)<=3;
    }

    private void SetExitKeyAmout()
    {
        if (levelCounter == 2)
        {
            maxExitKeyAmount++;
        }
        if(levelCounter == 5)
        {
            maxExitKeyAmount = 3;
        }
    }

    private void BoundsForThePlayer()
    {
        if (_player.transform.position.y < _yPosDestroyBounds)
        {
            PlayerReborn();
        }
    }

    private IEnumerator PlayerRebirth()
    {
        _player.GetComponent<PlayerControlls>().isPlayerReborning = true;
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _player.transform.position = rebornPos.transform.position;
        _player.transform.rotation = Quaternion.Euler(new Vector3(0, 90.0f, 0));
        yield return new WaitForSeconds(2.1f);

        _player.GetComponent<PlayerControlls>().isPlayerReborning = false;
    }
}
