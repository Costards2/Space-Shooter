using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public bool isActive = false;
    public GameObject shield;

    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer.enabled = false;
        circleCollider.enabled = false;
    }

    private void DesactivateShield()
    {
        isActive = false;
        spriteRenderer.enabled = false;
        circleCollider.enabled = false;
    }

    public void ActivateShield()
    {
        isActive = true;
        spriteRenderer.enabled = true;
        circleCollider.enabled = true;
        StopAllCoroutines();
        StartCoroutine(DesactivateShieldIE());
    }

    IEnumerator DesactivateShieldIE()
    {
        yield return new WaitForSeconds(5f);
        DesactivateShield();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                collision.GetComponent<EnemyDamage>().DestroyEnemy(); 
                break;
            case "LaserEnemy":
                Destroy(collision.gameObject);
                break;
        }
    }
}
