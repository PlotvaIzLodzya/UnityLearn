using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevitation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yTravel;
    [SerializeField] private float _duration = 1;
    [SerializeField] private float _hight = 0.75f;

    private bool isStatic = false;

    private GameManager _gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _yTravel.preWrapMode = WrapMode.PingPong;
        _yTravel.postWrapMode = WrapMode.PingPong;
    }

    // Update is called once per frame
    void Update()
    {
        ObjectMoving();
    }

    private float SettingDuration()
    {
        return _duration *= _gameManagerScript.DurationGeneration(_gameManagerScript._minDuration, _gameManagerScript._maxDuration);
    }

    public void ObjectMoving()
    {
        transform.position = new Vector3(transform.position.x, _yTravel.Evaluate(Time.time / SettingDuration()) * _hight, transform.position.z);
    }
}
