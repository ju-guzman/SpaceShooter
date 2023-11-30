using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.OnUpdateScore += UpdateScore;
    }

    private void UpdateScore(float score)
    {
        scoreText.text = ((int)score).ToString();
    }
}
