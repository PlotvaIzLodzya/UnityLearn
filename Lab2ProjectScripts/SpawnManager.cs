using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject platform;
    public GameObject movingWall;
    public GameObject lavaFloor;
    public GameObject lvlBorderHorizontal;
    public GameObject lvlBorderVertical;
    public GameObject exitKey;
    private GameManager gameManager;

    public float powerUpPosY = 3.0f;
    public float platformPosY = 1.25f;
    private float movingWallsOffset = 2.0f;
    private float spawnRate = 3.0f;
    private int xStartPos = 0;
    private int zStartPos = 0;

    private float lavaFloorDistance;
    private float lavaCoveringMultiplier = 8;
    private int distance = 4;

    public int platformCounter;
    private int lengthPlatformAmount;
    private int widthPlatformAmount;
    private int movingWallsAmount;






    // Start is called before the first frame update
    void Start()
    {
        lavaFloorDistance = lavaFloor.gameObject.GetComponent<BoxCollider>().size.x * lavaFloor.transform.localScale.x;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lengthPlatformAmount = gameManager.lengthPlatformAmount;
        widthPlatformAmount = gameManager.widthPlatformAmount;
        movingWallsAmount = lengthPlatformAmount / 5;
    }
    public void LevelCreation()
    {
        MovingWallsCreation();
        ExitKeyPlacing();
        PlatformPlacing();
        LavaPlacing();
        PowerUpPlacing();
        StartCoroutine("SpawnWalls");
    }

    private Vector3 GenerateRandomPos(int xStartPos, int zStartPos)
    {
        int posX = Random.Range(xStartPos, lengthPlatformAmount) * distance;
        int posZ = Random.Range(zStartPos, widthPlatformAmount) * distance;
        Vector3 position = new Vector3(posX, powerUpPosY, posZ);
        return position;
    }

    private void PlatformPlacing()
    {
        for(int x = xStartPos; x < lengthPlatformAmount; x++)
        {
            for(int z = zStartPos; z< widthPlatformAmount; z++)
            {
                int posX = x * distance;
                int posZ = z * distance;
                Vector3 platformPos = new Vector3(posX, platformPosY, posZ);
                Instantiate(platform, platformPos, platform.transform.rotation);
            }
        }
    }

    private void MovingWallsCreation()
    {
        for(int i = 0; i < movingWallsAmount; i++)
        {
            
            float posX = Random.Range(2, lengthPlatformAmount) * distance - movingWallsOffset;
            float posZ = Random.Range(-10, -20);
            Vector3 wallPos = new Vector3(posX, movingWall.transform.position.y, posZ);
            Instantiate(movingWall, wallPos, movingWall.transform.rotation);
        }
    }

    private void LavaPlacing()
    {
        for(int i = 1; i <= lengthPlatformAmount/ lavaCoveringMultiplier; i++)
        {
            float posX = i * lavaFloorDistance;
            Vector3 lavaPos = new Vector3(posX, 0, 5);
            Instantiate(lavaFloor, lavaPos, lavaFloor.transform.rotation);
        }
    }

    private void PowerUpPlacing()
    {
        Instantiate(powerUp, GenerateRandomPos(lengthPlatformAmount/4, zStartPos), powerUp.transform.rotation);
    }

    public void ExitKeyPlacing()
    {
        for(int i = 0; i <= gameManager.maxExitKeyAmount; i++)
        {
            Instantiate(exitKey, GenerateRandomPos(lengthPlatformAmount / 2, zStartPos), exitKey.transform.rotation);
        }
    }

    IEnumerator SpawnWalls()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            MovingWallsCreation();

        }
    }
}
