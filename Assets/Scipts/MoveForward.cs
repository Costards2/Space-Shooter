using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //if you want to change the direction junt make the speed negative
    public float speed;
    public float existanceTime;

    void Start()
    {
        Destroy(gameObject, existanceTime);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
