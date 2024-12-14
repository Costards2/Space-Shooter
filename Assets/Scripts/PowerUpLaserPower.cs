using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLaserPower : MonoBehaviour
{
    public Sprite[] pills;
    private SpriteRenderer spriteRenderer;

    private int level;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        level = new System.Random().Next(1, pills.Length);
        spriteRenderer.sprite = pills[level];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerManager.instance.EnableLaserLevel(level);
            Destroy(gameObject);
        }
    }
}
