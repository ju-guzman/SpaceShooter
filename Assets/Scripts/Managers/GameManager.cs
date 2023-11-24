using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    public Action<float> OnPlayerLifeUpdate;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayerLifeUpdate(float life)
    {
        OnPlayerLifeUpdate?.Invoke(life);
    }
}
