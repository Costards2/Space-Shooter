using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public static MoveShip moveShip;
    public static ShootLaser shootLaser;
    public static PlayerShield playerShield;

    public GameObject explosion;

    public int laserPowerLevel = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            moveShip = GetComponent<MoveShip>();
            shootLaser = GetComponent<ShootLaser>();
            playerShield = GetComponentInChildren<PlayerShield>();
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DestroyPlayer()
    {
        AudioManager.instance.PlayExploxionAudio();

        GameObject go = Instantiate(explosion);
        go.transform.position = transform.position;

        Destroy(gameObject);
    }

    public void EnableLaserLevel(int level)
    {
        laserPowerLevel = level;
        StopAllCoroutines();
        StartCoroutine(ResetPlayerPower());
    }

    IEnumerator ResetPlayerPower()
    {
        yield return new WaitForSeconds(3f);
        laserPowerLevel = 0;
    }
}
