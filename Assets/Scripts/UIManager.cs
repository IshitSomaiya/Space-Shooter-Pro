using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _LivesImg;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;

    private _gameManager _gameManager;
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<_gameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("GameManager Is NULL. ");
        }
    }

    public void UpdateScore(int PlayerScore) 
    {
        _scoreText.text = "Score: " + PlayerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        if(currentLives >= 0)
        {
            _LivesImg.sprite = _liveSprites[currentLives];
            if (currentLives == 0)
            {
                GameOverSequence();
            }
        }
    }

    void GameOverSequence()
    {
        //_gameManager.GameOver();
        _gameManager.Instance.gameover = true;
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }
    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

    internal void HideTitleScreen()
    {
        throw new NotImplementedException();
    }
}
