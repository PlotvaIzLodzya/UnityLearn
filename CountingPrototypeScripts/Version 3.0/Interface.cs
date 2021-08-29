using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Interface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _bestTime;
    private GameManager _gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _counterText.text = "Count: " + _gameManagerScript._count;
        _timerText.text = "Time: " + Math.Round(_gameManagerScript._time,2);
        _bestTime.text = "Best Time: " + Math.Round(_gameManagerScript.bestTime, 2);

    }
}
