using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/Bullet", order = 1)]
public class SO_Bullet : ScriptableObject
{
    [Header("Visual")]
    public Bullet prefabToSpawn;

    [Header("Stats")]
    public float damage = 10f;
    public float speed = 10f;
    public float fireRatio;

    [Header("Modifiers")]
    public bool applyMultiplierRatio = true;
    public bool destroyOnHit;

    [Header("FX")]
    public bool playShootSound = true;
    public Sprite image;
    public ParticleSystem hitEffect;
}
