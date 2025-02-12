using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public GameObject laser;

    public float shootTime;
    private float waitTime = 0;

    public int laserLevel = 1;

    void Update()
    {
        if (Time.time > waitTime)
        {
            Shoot();

            waitTime = Time.time + shootTime;
        }
    }

    public void LevelUp()
    {
        laserLevel++;
        laserLevel = laserLevel > 5 ? 5 : laserLevel;
    }

    private void Shoot()
    {
        AudioManager.instance.PlayLaserAudio();

        GameObject ls = Instantiate(laser);
        ls.transform.position = transform.position + Vector3.up;

        if (laserLevel == 1) return;
        InstatiateDoubleLaser(-0.195f, 0.851f);
        if (laserLevel == 2) return;
        InstatiateDoubleLaser(-0.378f, 0.575f);
        if (laserLevel == 3) return;
        InstatiateDoubleLaser(-0.571f, 0.323f);
        if (laserLevel == 4) return;
        InstatiateDoubleLaser(-0.74f, -0.018f);

    }

    private void InstatiateDoubleLaser(float x, float y)
    {
        GameObject laser1 = Instantiate(laser);
        laser1.transform.position = transform.position + new Vector3(x,y,0);
        GameObject laser2 = Instantiate(laser);
        laser2.transform.position = transform.position + new Vector3(x * -1,y , 0);
    }

    public void LevelDown()
    {
        laserLevel = 1;
    }
}
