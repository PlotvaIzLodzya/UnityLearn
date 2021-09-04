using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private GameObject _player;
    public GameObject rebornPos;
    private GameObject[] platforms;
    private SpawnManager _spawnManager;
    private GameObject powerUp;
    [SerializeField] float _yPosReborn = -350;

    public int exitKeyCounter = 0;
    public int maxExitKeyAmount = 1;
    public int levelCounter = 1 ;

    public int lengthPlatformAmount;
    public int widthPlatformAmount;
    public int _platformAmountPerLvl = 5;

    [SerializeField] private int _maxDuration = 6;
    [SerializeField] private int _minDuration = 3;


    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>().GetComponent<SpawnManager>();
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
            Debug.Log("exit key counter: " + exitKeyCounter);
            exitKeyCounter = 0;
            levelCounter++;
            SetExitKeyAmout();
            DestroyingWorld();
            
            _spawnManager.LevelCreation();
            PlayerReborn();
            Debug.Log("Level complete! Level: " + levelCounter);
        }
    }

    public void PlayerReborn()
    {
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _player.transform.position = rebornPos.transform.position;
        _player.transform.rotation = Quaternion.Euler(new Vector3(0,90.0f,0));
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
        if(levelCounter > 5)
        {
            maxExitKeyAmount = 3;
        }
    }

    private void BoundsForThePlayer()
    {
        if (_player.transform.position.y < _yPosReborn)
        {
            PlayerReborn();
        }
    }
}
