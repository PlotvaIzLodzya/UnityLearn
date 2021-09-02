using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private GameObject player;
    public GameObject rebornPos;
    private GameObject[] platforms;
    private SpawnManager _spawnManager;
    private GameObject powerUp;

    public int exitKeyCounter = 0;
    public int maxExitKeyAmount = 1;
    public int levelCounter = 1 ;

    public int lengthPlatformAmount;
    public int widthPlatformAmount;

    [SerializeField] private int _maxDuration = 10;
    [SerializeField] private int _minDuration = 1;


    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>().GetComponent<SpawnManager>();
        _spawnManager.LevelCreation();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
            lengthPlatformAmount += levelCounter;
            _spawnManager.LevelCreation();
            PlayerReborn();
            Debug.Log("Level complete! Level: " + levelCounter);
        }
    }

    public void PlayerReborn()
    {
        player.transform.position = rebornPos.transform.position;
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
}
