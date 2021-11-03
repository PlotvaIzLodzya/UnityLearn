using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointText;
    [SerializeField] private TMP_Text _highestPointText;
    [SerializeField] private ScoreBoard _scoreBoard;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.PointsChanged += UpdatePoint;
        _scoreBoard.OnScoreLoaded += UpdateHighScore;
    }

    private void OnDisable()
    {
        _player.PointsChanged -= UpdatePoint;
        _scoreBoard.OnScoreLoaded -= UpdateHighScore;
    }

    public void UpdatePoint(int point)
    {
        _pointText.text = $"Очки: {point}";
    }

    public void UpdateHighScore(int highestPoint)
    {
        _highestPointText.text = $"Лучший результат: {highestPoint}";
    }
}
