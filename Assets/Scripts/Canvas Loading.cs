using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLoading : MonoBehaviour
{
    public static CanvasLoading instance;

    public GameObject loadingPNL;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    public void ShowLoadingPNL()
    {
        loadingPNL.SetActive(true);
    }

    public void HideLoadingPNL()
    {
        loadingPNL.SetActive(false);
    }
}
