using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float scoreRatio = 100f;
    public int level = 1;
    public float score = 0;

    private static GameManager instance;
    public static GameManager Instance => instance;

    public Action<float> OnPlayerLifeUpdate;
    public Action<int> OnLevelUp;
    public Action<float> OnUpdateScore;
    public Action OnGameOver;
    public Action<Bullet> OnPlayerSwitchAmmo;

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
        OnLevelUp?.Invoke(level);
    }

    public void SwitchAmmo(Bullet bullet)
    {
        OnPlayerSwitchAmmo?.Invoke(bullet);
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
