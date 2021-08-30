using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetMeInButton : MonoBehaviour
{
    private GameManager _gameManagerScript;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(DisablePrepartionTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisablePrepartionTime()
    {
        _gameManagerScript.isPreparationTimeActive(false);
        _gameManagerScript._time = 0;
    }

}
