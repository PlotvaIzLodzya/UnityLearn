using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitation : MonoBehaviour
{
    public float topBorder;
    public float bottomBorder;
    public float speed = 0.2f;
    public float _maxDuration = 6.0f;
    public float _minDuration = 3f;

    public float currentPositionY;

    private bool isGoingDown = false;
    private bool isStatic = false;



    private GameManager gameManger;
    // Start is called before the first frame update
    void Start()
    {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();

        PlatformCongiguration();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStatic)
        {
            MovingPlatform();
        }
    }
    void IsBorderReached()
    {
        currentPositionY = transform.position.y;
        if (currentPositionY >= topBorder)
        {
            isGoingDown = true;
        }
        if (currentPositionY < bottomBorder)
        {
            isGoingDown = false;
        }
    }

    void MovingPlatform()
    {
        IsBorderReached();
        if (isGoingDown == false)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (isGoingDown == true)
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
        }
    }

    void settingSpeed()
    {
        if (gameManger.isPlatformRandomSpeed == true)
        {
            speed *= gameManger.DurationGeneration(_minDuration, _maxDuration);
        }
    }

    void PlatformCongiguration()
    {
        if (gameObject.CompareTag("Ground"))
        {
            settingSpeed();
            isStatic = gameManger.IsPlatformStatic();
        }
    }
}







