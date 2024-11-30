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
            GameObject firstLaser = Instantiate(laser);
            firstLaser.transform.position = transform.position + Vector3.up;

            waitTime = Time.time + shootTime;
        }
    }

    public void LevelUp()
    {
        laserLevel++;
        laserLevel = laserLevel > 5 ? 5 : laserLevel;
    }

    public void LevelDown()
    {
        laserLevel = 1;
    }
}
