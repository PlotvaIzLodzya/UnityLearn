using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yTravel;
    UtilityScripts _utility;
    private float _duration;
    [SerializeField] private float _distance = 0.75f;
    private Vector3 _initialPos;

    private bool isStatic = false;

    private GameManager _gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        _initialPos = transform.position;
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _utility = GetComponent<UtilityScripts>();

        _duration = _gameManagerScript.DurationGeneration();

        isStatic = _gameManagerScript.IsPlatformStatic();

        _yTravel.preWrapMode = WrapMode.PingPong;
        _yTravel.postWrapMode = WrapMode.PingPong;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isStatic)
            _utility.Levitation(_yTravel, _initialPos, _duration, _distance);
    }

}
