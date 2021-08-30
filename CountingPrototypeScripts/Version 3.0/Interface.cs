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
    [SerializeField] private GameObject prepScreen;
    private GameManager _gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        _timerText.text = "Time: " + Math.Round(_gameManagerScript._time,2);
        _counterText.text = "Count: " + _gameManagerScript._count;

    }

    public void BestTimeSetting(double bestTime)
    {
        _bestTime.color = new Color(0.25f, 0.71f, 0.15f);
        _bestTime.text = "Best Time: " + Math.Round(bestTime, 2);
    }

    public void PreparationOnScreen(bool isPreparationTime)
    {
        prepScreen.SetActive(isPreparationTime);
    }

}
