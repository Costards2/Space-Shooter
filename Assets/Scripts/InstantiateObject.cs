using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    public GameObject objectToInstantiate;
    private GameObject instatiatedObject;

    public float timeToAppear;
    protected float waitTime;
    public float initialPositionY = 8.5f;

    public bool waitFirst;

    public bool powerUpObject;

    protected ScreenLimits screenLimits;

    void Start()
    {
        if (waitFirst)
        {
            waitTime = Time.time + timeToAppear;
        }

        screenLimits = CanvasGame.instance.screenLimits;
    }

    void Update()
    {
        if (CanvasGame.instance.bossActive == true && powerUpObject == false) return;
       
        if (Time.time > waitTime)
        {
            instatiatedObject = Instantiate(objectToInstantiate);
            float positionX = Random.Range(screenLimits.leftLimit + 0.15f, screenLimits.rightLimit - 0.15f);
            instatiatedObject.transform.position = new Vector3(positionX, screenLimits.topLimit, 0);
            waitTime = Time.time + timeToAppear;
        }
    }
}
