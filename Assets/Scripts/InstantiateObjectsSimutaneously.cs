using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjectsSimutaneously : InstantiateObject
{
    public int maxObjects;
    public float instatiateTime;
    private int totalInstantiated = 0;

    void Update()
    {
        if (CanvasGame.instance.bossActive == true) return;

        if (Time.time > waitTime)
        {
            StartCoroutine(InstatiateObjectsSimutaneously());
            waitTime = Time.time + timeToAppear;
        }
    }

    IEnumerator InstatiateObjectsSimutaneously()
    {
        float xPosition = Random.Range(screenLimits.leftLimit + 0.15f, screenLimits.rightLimit - 0.15f);
        totalInstantiated = 0;

        do
        {
            yield return new WaitForSeconds(instatiateTime);
            GameObject instatiatedObeject = Instantiate(objectToInstantiate);
            instatiatedObeject.transform.position = new Vector3(xPosition, screenLimits.topLimit + 7, 0);
            totalInstantiated++;
        }
        while (totalInstantiated <= maxObjects);
    }
}
