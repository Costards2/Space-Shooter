using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenu : MonoBehaviour
{
    public TextMeshProUGUI txtScore;
    public Image volumeIcon;
    public Sprite[] sptVolumes;

    void Start()
    {
        AudioManager.instance.PlayMenuAudio();
        AudioManager.instance.ConfigInitialVolume();

        ChangeVolumeIcon();

        txtScore.text = DBManager.GetSavedScore().ToString();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void ChangeVolumeIcon()
    {
        if (AudioManager.instance.IsMuted == true)
        {
            volumeIcon.sprite = sptVolumes[0];
        }
        else
        {
            volumeIcon.sprite = sptVolumes[1];
        }
    }

    public void ChangeVolume()
    {
        AudioManager.instance.ChangeVolume();
        ChangeVolumeIcon();
    }
}
