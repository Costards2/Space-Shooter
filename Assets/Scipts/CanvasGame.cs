using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasGame : MonoBehaviour
{
    public static CanvasGame instance;

    public GameObject[] lifeImagesPlayer;

    public TextMeshProUGUI gameScoreTxt;
    public TextMeshProUGUI gameLevelText;
    public float timeDificulty;

    private int playerLife;
    private int gameLevel = 1;
    private int gameScore;

    public int GameLevel
    {
        get { return gameLevel; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
    }

    void Start()
    {
        playerLife = lifeImagesPlayer.Length - 1;
        gameLevel = 1;
        gameScore = 0;
        gameScoreTxt.text = $"{gameScore}";
        gameLevelText.text = $"Nv. {gameLevel}";

        StartCoroutine(IncreaseDificulty());    
    }

    public void IncreaseScore(int score)
    {
        gameScore += score;
        gameScoreTxt.text = $"{gameScore}";
    }

    public void DecreasePlayerLife()
    {
        if (PlayerManager.playerShield.isActive == true) return;

        if(playerLife <= 0)
        {
            PlayerManager.instance.DestroyPlayer();
        }
        else
        {
            lifeImagesPlayer[playerLife].SetActive(false);
            playerLife--;
            PlayerManager.shootLaser.LevelDown();
        }
    }
  
    void Update()
    {
        
    }

    IEnumerator IncreaseDificulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeDificulty);
            gameLevel++;
            if(gameLevel == 8)
            {
                gameLevelText.text = $"Nv. MAX";
                break;
            }
            gameLevelText.text = $"Nv. {gameLevel}";
        }
    }
}
