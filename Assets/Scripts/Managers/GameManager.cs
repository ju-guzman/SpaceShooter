using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float scoreRatio = 100f;
    [SerializeField] AudioSource ExplosionSound;

    private int level = 1;
    private float score = 0;
    private float gameSpeedMultiplier = 1;

    public int Level => level;
    public float GameSpeedMultiplier => gameSpeedMultiplier;
    public float Score => score;

    private static GameManager instance;
    public static GameManager Instance => instance;

    public Action<float> OnPlayerLifeUpdate;
    public Action<int> OnLevelUp;
    public Action<float> OnUpdateScore;
    public Action OnGameOver;
    public Action<SO_Bullet> OnPlayerSwitchAmmo;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        StartCoroutine(UpdateScoreCoroutine());
    }

    private IEnumerator UpdateScoreCoroutine()
    {
        while (true)
        {
            score += scoreRatio * Time.deltaTime;
            OnUpdateScore?.Invoke(score);
            yield return null;
        }
    }

    public void PlayExplosionSound()
    {
        ExplosionSound.Play();
    }

    public void AddScore(float score)
    {
        this.score += score;
        OnUpdateScore?.Invoke(this.score);
    }

    public void PlayerLifeUpdate(float life)
    {
        OnPlayerLifeUpdate?.Invoke(life);
        if (life <= 0)
        {
            OnGameOver?.Invoke();
            StopAllCoroutines();
        }
    }

    public void LevelUp() {
        level++;
        gameSpeedMultiplier += 0.1f;
        OnLevelUp?.Invoke(level);
    }

    public void SwitchAmmo(SO_Bullet bullet)
    {
        OnPlayerSwitchAmmo?.Invoke(bullet);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
