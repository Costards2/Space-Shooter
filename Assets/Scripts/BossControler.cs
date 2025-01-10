using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControler : MonoBehaviour
{
    public float speed;
    public GameObject[] lasers;
    public GameObject explosion;

    private bool gotToTheInitialPosition;
    private bool gotToTheLeft;

    private int totalOfMovements = 0;
    private float targetAngle = 90;

    void Start()
    {
        DeactivateLasers();
        CanvasGame.bossLifePanel.ShowBossLife(gameObject);
    }

    void Update()
    {
        if (!gotToTheInitialPosition)
        {
            MoveToTheInitialPosition();
        }
        else if(totalOfMovements < 4)
        {
            ActivateLasers();
            MoveHorizontaly();
        }
        else
        {
            DeactivateLasers();
            Rotate();
        }
    }

    private void MoveToTheInitialPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, Vector3.zero) < 0.001f)
        {
            gotToTheInitialPosition = true;
        }
    }

    private void MoveHorizontaly()
    {
        if (!gotToTheLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.3f, 0, 0), speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, new Vector3(-1.3f, 0, 0)) < 0.001f)
            {
                gotToTheLeft = true;
                totalOfMovements++;
            }
        }
        else
        {
            // Move to the right
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.3f, 0, 0), speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, new Vector3(1.3f, 0, 0)) < 0.001f)
            {
                gotToTheLeft = false;
                totalOfMovements++;
            }
        }
    }

    private void Rotate()
    {
        var targetRotation = Quaternion.Euler(new Vector3(0f, 0f, targetAngle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime * 50);

        if(transform.rotation == targetRotation)
        {
            targetAngle = targetAngle == 90 ? 0f : 90;
            totalOfMovements = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Laser":
                LaserPower laserPower = collision.GetComponent<LaserPower>();
                CanvasGame.bossLifePanel.DescreaseBossLife(laserPower.damage);
                Destroy(collision.gameObject);
                break;
            case "Player":
                CanvasGame.instance.ShowGameOverScreen();
                break;
        }
    }

    private void DeactivateLasers()
    {
        foreach(var laser in lasers)
        {
            laser.SetActive(false);
        }
    }

    private void ActivateLasers()
    {
        foreach (var laser in lasers)
        {
            laser.SetActive(true);
        }
    }

    public void InstatiateExplosion()
    {
        GameObject newExplosion = Instantiate(explosion);
        newExplosion.transform.position = transform.position;
    }
}
