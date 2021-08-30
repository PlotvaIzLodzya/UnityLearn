using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    private GameManager _gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
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
            _gameManagerScript.RestartLevel();
        }
    }
}
