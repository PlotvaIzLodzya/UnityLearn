using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevitation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yTravel;
    UtilityScripts _utility;
    public float _duration;
    [SerializeField] private float _hight = 0.75f;

    private bool isStatic = false;

    private GameManager _gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _utility = GetComponent<UtilityScripts>();

        if (_utility == null)
            _utility = FindObjectOfType<UtilityScripts>().GetComponent<UtilityScripts>();

        SettingDuration(_gameManagerScript.DurationGeneration());

        isStatic = _gameManagerScript.IsPlatformStatic();

        _yTravel.preWrapMode = WrapMode.PingPong;
        _yTravel.postWrapMode = WrapMode.PingPong;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isStatic)
            _utility.Levitation(_yTravel, _duration, _hight);
    }

    private void SettingDuration(int duration)
    {
        _duration = duration;
    }



}
