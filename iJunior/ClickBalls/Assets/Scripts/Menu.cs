using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _loseScreen;

    private void OnEnable()
    {
        _player.Died += ShowLoseScreen;
    }

    private void OnDisable()
    {
        _player.Died -= ShowLoseScreen;
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void ShowLoseScreen()
    {
        OpenPanel(_loseScreen);
    }
}
