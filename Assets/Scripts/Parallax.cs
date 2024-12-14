using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Material material;

    private float offesetY;
    public float speed;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        offesetY += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", new Vector2(0, offesetY));
    }
}
