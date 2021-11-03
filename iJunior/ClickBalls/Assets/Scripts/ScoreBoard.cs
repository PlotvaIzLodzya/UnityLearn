using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _highestScore;

    public event UnityAction<int> OnScoreLoaded;

    private void Start()
    {
        LoadScore();
    }

    private void OnEnable()
    {
        _player.Died += SaveSore;
        _player.Died += LoadScore;
    }

    private void OnDisable()
    {
        _player.Died -= SaveSore;
        _player.Died -= LoadScore;
    }

    class SaveData
    {
        public int HighestScore;
    }

    public void SaveSore()
    {
        SaveData saveData = new SaveData();

        if (_player.Score > _highestScore)
        {
            saveData.HighestScore = _player.Score;
            _highestScore = _player.Score;
            Debug.Log(saveData.HighestScore);
            string json = JsonUtility.ToJson(saveData);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            _highestScore = saveData.HighestScore;
            OnScoreLoaded?.Invoke(_highestScore);
        }
    }
}
