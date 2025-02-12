using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGame : MonoBehaviour
{
    public static CanvasGame instance;
    public static BossLifePanel bossLifePanel;

    public GameObject[] lifeImagesPlayer;

    public TextMeshProUGUI gameScoreTxt;
    public TextMeshProUGUI gameLevelText;
    public GameObject topPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI txtScoreEndGame;
    public TextMeshProUGUI txtBestScore;

    public float timeDificulty;

    private int playerLife;
    private int gameLevel = 1;
    private int gameScore;

    public bool bossActive;

    public ScreenLimits screenLimits;

    public int GameLevel
    {
        get { return gameLevel; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            bossLifePanel = GetComponent<BossLifePanel>();
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

        topPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        // Getting Screen Bounderies
        Vector3 leftTop = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, Camera.main.nearClipPlane));
        Vector3 rightbase = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, Camera.main.nearClipPlane));

        screenLimits = new ScreenLimits();
        screenLimits.leftLimit = leftTop.x;
        screenLimits.topLimit = leftTop.y + 1.5f;
        screenLimits.rightLimit = rightbase.x;
        screenLimits.bottomLimit = rightbase.y;

        CanvasLoading.instance.HideLoadingPNL();

        HideCursor();

        AudioManager.instance.PlayGameAudio();
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
            ShowGameOverScreen();
        }
        else
        {
            lifeImagesPlayer[playerLife].SetActive(false);
            playerLife--;
            PlayerManager.shootLaser.LevelDown();
        }
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

    public void ShowGameOverScreen()
    {
        ShowCursor();
        KillPlayer();
        topPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        txtScoreEndGame.text = $"{gameScore}";
        DBManager.SaveScore(gameScore);
        txtBestScore.text = $"{DBManager.GetSavedScore()}";
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void KillPlayer()
    {
        PlayerManager.instance.DestroyPlayer();
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }
}
