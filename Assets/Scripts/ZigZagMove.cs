using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMove : MonoBehaviour
{
    public float speed;
    public float turnTime;
    private float direction;
    public float existanceTime;
    private float waitTime;

    void Start()
    {
        waitTime = Time.time + turnTime;
        direction = 1;
        Destroy(gameObject, existanceTime);
    }

    void Update()
    {
        if (Time.time > waitTime) 
        {
            waitTime = Time.time + turnTime;
            direction *= -1;
        }

        transform.Translate(new Vector3(1 * direction, 2f ,0 ) * speed * Time.deltaTime);
    }
}
