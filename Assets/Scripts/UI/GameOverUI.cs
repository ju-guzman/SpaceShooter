using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    void Start()
    {
        GameManager.Instance.OnGameOver += () =>
        {
            gameOverUI.SetActive(true);
            playerUI.SetActive(false);
            scoreText.text = "" + (int)GameManager.Instance.score;
        };
    }
}
