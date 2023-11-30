using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    private Image bulletImage;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnPlayerSwitchAmmo += UpdateBullet;
        bulletImage = GetComponent<Image>();
    }

    private void UpdateBullet(Bullet bullet)
    {
        bulletImage.sprite = bullet.Image;
    }
}
