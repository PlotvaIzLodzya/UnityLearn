using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    private Vector3 _screenPoint;
    private GameManager _gameManagerScript;
    private Objects _objectPhysics;
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _objectPhysics = FindObjectOfType<Objects>().GetComponent<Objects>();
    }

    // Update is called once per frame
    void Update()
    {
        ButtonForRestart();
    }

    public void ButtonForRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _gameManagerScript.StartNewLevel();
        }
    }
}
