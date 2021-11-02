using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _spawner.AllWavesCompleted += EnableWinScreen;
        _spawner.AllEnemyDead += EnableShop;
        _player.Died += EnableLoseScreen;
    }

    private void OnDisable()
    {
        _spawner.AllWavesCompleted -= EnableWinScreen;
        _spawner.AllEnemyDead -= EnableShop;
        _player.Died -= EnableLoseScreen;
    }

    private void EnableShop()
    {
        OpenPanel(_shop.gameObject);
    }

    private void EnableWinScreen()
    {
        _winScreen.SetActive(true);
    }

    private void EnableLoseScreen()
    {
        _loseScreen.SetActive(true);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}
