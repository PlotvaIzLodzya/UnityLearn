using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetMeInButton : MonoBehaviour
{
    private GameManager _gameManagerScript;
    private Button _button;
    [SerializeField] Sound _soundManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(DisablePrepartionTime);
        _button.onClick.AddListener(SoundEffect);
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

    private void SoundEffect()
    {
        _soundManager.playSound(_soundManager._click, _soundManager.clickSoundLevel);
    }

}
