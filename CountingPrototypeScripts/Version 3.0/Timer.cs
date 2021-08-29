using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    GameManager _gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManagerScript.isPreparationTime == false )
        {
            _gameManagerScript._time += Time.deltaTime;
        }

        
    }
}
