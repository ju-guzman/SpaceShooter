using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    private TextMeshProUGUI lifeText;

    void Start()
    {
        lifeText = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.OnPlayerLifeUpdate += UpdateLife;
    }

    private void UpdateLife(float life)
    {
        lifeText.text = ((int)life).ToString();
    }
}
