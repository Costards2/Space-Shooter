using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public float speed = 25f;

    private ScreenLimits screenLimits;

    private void Start()
    {
        screenLimits = CanvasGame.instance.screenLimits;
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Limits the player Position
        float limitX = Mathf.Clamp(mousePosition.x, screenLimits.leftLimit, screenLimits.rightLimit);
        float limitY = Mathf.Clamp(mousePosition.y, screenLimits.bottomLimit, screenLimits.topLimit);

        mousePosition = new Vector2(limitX, limitY);

        float movementSpeed = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, movementSpeed);
    }
}
