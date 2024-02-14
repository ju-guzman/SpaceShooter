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

    private void UpdateBullet(SO_Bullet bullet)
    {
        bulletImage.sprite = bullet.image;
    }
}
