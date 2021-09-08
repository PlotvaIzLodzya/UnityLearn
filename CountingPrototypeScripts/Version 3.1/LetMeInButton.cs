using UnityEngine;
using UnityEngine.UI;

public class LetMeInButton : MonoBehaviour
{
    private GameManager _gameManagerScript;
    private Button _button;
    [SerializeField] Sound _soundManager;

    void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _button = GetComponent<Button>();
        _soundManager = FindObjectOfType<Sound>().GetComponent<Sound>();
        _button.onClick.AddListener(DisablePrepartionTime);
    }

    public void DisablePrepartionTime()
    {
        _gameManagerScript.isPreparationTimeActive(false);
        _gameManagerScript._time = 0;
        _soundManager.playSound(_soundManager._click, _soundManager.clickSoundLevel);
    }
}
