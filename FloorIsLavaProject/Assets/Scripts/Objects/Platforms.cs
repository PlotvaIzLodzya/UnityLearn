using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MovingCalculator
{
    [SerializeField] private AnimationCurve _yTravel;
    private float _duration;
    [SerializeField] private float _distance = 0.75f;
    private Vector3 _initialPos;

    private bool _isStatic = false;

    private GameManager _gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        _initialPos = transform.position;

        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        _duration = _gameManagerScript.DurationGeneration();
        _isStatic = _gameManagerScript.IsPlatformStatic();

        _yTravel.preWrapMode = WrapMode.PingPong;
        _yTravel.postWrapMode = WrapMode.PingPong;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!_isStatic)
            Levitation(_yTravel, _initialPos, _duration, _distance);
    }

}
