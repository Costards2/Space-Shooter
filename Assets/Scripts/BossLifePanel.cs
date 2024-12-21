using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossLifePanel : MonoBehaviour
{
    public GameObject bossLifePanel;
    public Slider bossLifeSlider;
    public TextMeshProUGUI textBossLife;
    public float bossLife = 500000;
    
    private float initialLife;
    private GameObject boss;

    void Start()
    {
        bossLifeSlider.maxValue = bossLife;
        bossLifeSlider.value = bossLife;
        initialLife = bossLife;
        textBossLife.text = $"{bossLife}";
        //bossLifePanel.SetActive(false);
    }

    // Show Panel with Boss Life
    public void ShowBossLife(GameObject newBoss)
    {
        boss = newBoss;
        bossLife = initialLife;
        bossLifeSlider.value = bossLife;
        textBossLife.text = $"{bossLife}";
        bossLifePanel.SetActive(true);
        CanvasGame.instance.bossActive = true;
    }

    public void DescreaseBossLife(float damage)
    {
        bossLife -= damage;

        if(bossLife < 0)
        {
            Destroy(boss);
            bossLifePanel.SetActive(false);
            CanvasGame.instance.bossActive = false;
        }

        bossLifeSlider.value = bossLife;
        textBossLife.text = $"{bossLife}";
    }
}
