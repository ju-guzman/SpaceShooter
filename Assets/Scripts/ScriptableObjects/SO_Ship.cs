using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "ScriptableObjects/Ship", order = 1)]
public class SO_Ship : ScriptableObject
{
    [Header("Stats")]
    public Sprite image;
    public int health = 100;
    public int speed = 10;

    [Header("Shot")]
    public SO_Bullet[] bullets;
    public int fireRateMultiplier = 1;

    [Header("EventStats")]
    public int damageByCollision = 10;
    public int scoreByKill = 100;
}
