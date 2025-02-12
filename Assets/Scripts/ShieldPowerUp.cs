using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            AudioManager.instance.PlayPowerUpAudio();
            PlayerManager.playerShield.ActivateShield();
            Destroy(gameObject);
        }
    }
}
