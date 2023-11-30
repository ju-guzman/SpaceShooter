using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    private TextMeshProUGUI levelText;

    void Start()
    {
        levelText = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.OnLevelUp += UpdateLevel;
    }

    private void UpdateLevel(int level)
    {
        levelText.text = level.ToString();
    }
}
