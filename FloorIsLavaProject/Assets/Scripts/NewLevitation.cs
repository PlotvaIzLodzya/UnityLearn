using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevitation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yTravel;
    public float _duration;
    [SerializeField] private float _hight = 0.75f;

    private bool isStatic = false;

    private GameManager _gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        SettingDuration(_gameManagerScript.DurationGeneration());
        isStatic = _gameManagerScript.IsPlatformStatic();

        _yTravel.preWrapMode = WrapMode.PingPong;
        _yTravel.postWrapMode = WrapMode.PingPong;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!isStatic)
        transform.position = new Vector3(transform.position.x, _yTravel.Evaluate(Time.time / _duration) * _hight, transform.position.z);
    }

    private void SettingDuration(int duration)
    {
        _duration = duration;
    }

}
