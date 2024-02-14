using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "Managers/GameManager")]
public class SO_SpaceShooterGameManager : ScriptableObject
{
    public float scoreRatio = 100f;
    public AudioSource ExplosionSound;

    public Action<float> OnPlayerLifeUpdate;
    public Action<int> OnLevelUp;
    public Action<float> OnUpdateScore;
    public Action OnGameOver;
    public Action<Bullet> OnPlayerSwitchAmmo;

    private int level = 1;
    private float score = 0;

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
