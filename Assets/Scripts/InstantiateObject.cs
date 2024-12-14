using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    public GameObject objectToInstantiate;
    private GameObject instatiatedObject;

    public float timeToAppear;
    protected float waitTime;

    public bool waitFirst;

    void Start()
    {
        if (waitFirst)
        {
            waitTime = Time.time + timeToAppear;
        }
    }

    void Update()
    {
        if (Time.time > waitTime)
        {
            instatiatedObject = Instantiate(objectToInstantiate);
            float positionX = Random.Range(-3.5f, 3.5f);
            instatiatedObject.transform.position = new Vector3(positionX, 8.5f, 0);
            waitTime = Time.time + timeToAppear;
        }
    }
}
