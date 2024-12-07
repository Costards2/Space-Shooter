using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPower : MonoBehaviour
{
    public float[] damageValues;
    public float damage;

    public Sprite[] lasers;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        damage = damageValues[PlayerManager.instance.laserPowerLevel];
        spriteRenderer.sprite = lasers[PlayerManager.instance.laserPowerLevel];
    }
}
