using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float[] enemiesLifes;

    public Sprite[] enemiesSprites;
    public SpriteRenderer spriteRenderer;

    public GameObject explosion;

    private float life = 100;

    public int gameLevel;

    void Start()
    {
        gameLevel = CanvasGame.instance.GameLevel;

        life = enemiesLifes[gameLevel];
        spriteRenderer.sprite = enemiesSprites[gameLevel + 1];
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag) 
        {
            case "Laser":

                LaserPower laserPower = collision.GetComponent<LaserPower>();
                life -= laserPower.damage;
                Destroy(laserPower.gameObject);
                if (life <= 0)
                {
                    DestroyEnemy();
                }
                break;

            case "Player":

                DestroyEnemy();
                CanvasGame.instance.DecreasePlayerLife();
                break ;
        }
    }

    public void DestroyEnemy()
    {
        CanvasGame.instance.IncreaseScore((int)enemiesLifes[gameLevel]);
        GameObject goExplosion = Instantiate(explosion);
        goExplosion.transform.position = transform.position;
        Destroy(gameObject);
    }
}
