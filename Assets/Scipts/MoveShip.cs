using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public float speed = 25f;

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Limits the player Position
        float limitX = Mathf.Clamp(mousePosition.x, -3.5f, 3.5f);
        float limitY = Mathf.Clamp(mousePosition.y, -6.5f, 6.5f);

        mousePosition = new Vector2(limitX, limitY);

        float movementSpeed = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, movementSpeed);
    }
}
