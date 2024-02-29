using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;

    private void Start()
    {
        Time.timeScale = 0f;
        _startScreen.Open();
    }

    private void OnEnable()
    {
        _bird.GameOver += OnGameOver;
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _bird.GameOver -= OnGameOver;
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }

    private void OnGameOver()
    {
        
        Time.timeScale = 0f;
        _endScreen.Open();
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        _bird.Reset();
    }
}
