using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootLaser : MonoBehaviour
{
    public GameObject laser;
    public GameObject laserPosition;

    public float shootTime;
    private float waitTime = 0f;

    void Update()
    {
        if (Time.time > waitTime)
        {
            GameObject ls = Instantiate(laser);

            ls.transform.position = laserPosition.transform.position;
            ls.transform.rotation = laserPosition.transform.rotation;

            waitTime = Time.time + shootTime;
        }
    }
}
