using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private GameObject player;
    public GameObject rebornPos;
    private GameObject[] platforms;
    private SpawnManager spawnManager;
    private GameObject powerUp;

    private int exitKeyCounter;
    public int maxExitKeyAmount = 1;
    public int levelCounter = 1 ;


    public bool isPlatformRandomSpeed = true;
    public bool lvlComplition = false;

    public int lengthPlatformAmount = 20;
    public int widthPlatformAmount = 4;

    [SerializeField] private int _maxDuration = 10;
    [SerializeField] private int _minDuration = 1;


    // Start is called before the first frame update
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>().GetComponent<SpawnManager>();
        player = GameObject.Find("Player");
        spawnManager.LevelCreation();
    }

    // Update is called once per frame
    void Update()
    {
        LevelComplition();
    }

    public void LevelComplition()
    {
        exitKeyCounter = GameObject.FindGameObjectsWithTag("ExitKey").Length;
        if (exitKeyCounter == 0)
        {
            levelCounter++;
            Debug.Log("Level complete! Level: " + levelCounter);
            DestroyingWorld();
            SetExitKeyAmout();
            spawnManager.LevelCreation();
            PlayerReborn();
            lvlComplition = false;
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
        if (levelCounter > 2)
        {
            maxExitKeyAmount++;
        }
        if(levelCounter > 5)
        {
            maxExitKeyAmount = 3;
        }
    }
}
