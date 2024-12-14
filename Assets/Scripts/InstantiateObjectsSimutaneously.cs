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
        if(Time.time > waitTime)
        {
            waitTime = Time.time + timeToAppear;
        }
    }

    IEnumerator InstatiateObjectsSimutaneously()
    {
        float xPosition = Random.Range(-3.5f, 3.5f);
        totalInstantiated = 0;

        do
        {
            yield return new WaitForSeconds(instatiateTime);
            GameObject instatiatedObeject = Instantiate(objectToInstantiate);
            instatiatedObeject.transform.position = new Vector3(xPosition, 8.5f, 0);
            totalInstantiated++;
        }
        while (totalInstantiated <= maxObjects);
    }
}
