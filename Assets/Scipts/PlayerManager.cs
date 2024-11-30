using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public static MoveShip moveShip;
    public static ShootLaser shootLaser;

    public GameObject explosion;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        moveShip = GetComponent<MoveShip>();
        shootLaser = GetComponent<ShootLaser>();
    }

    void Update()
    {
        
    }

    public void DestroyPlayer()
    {
        GameObject go = Instantiate(explosion);
        go.transform.position = transform.position;

        Destroy(gameObject);
    }
}
