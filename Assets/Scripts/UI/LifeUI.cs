using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    private TextMeshProUGUI lifeText;
    // Start is called before the first frame update
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
