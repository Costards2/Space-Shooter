using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource vfx;
    public AudioSource music;

    public AudioClip menuClip;
    public AudioClip[] gameClips;
    public AudioClip laserClip;
    public AudioClip explosionClip;
    public AudioClip powerUpClip;

    private bool isMuted;
    public bool IsMuted
    {
        get { return isMuted; }
    }

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

    public void ChangeVolume()
    {
        isMuted = !isMuted;
        ConfigVolume();
    }

    public void ConfigInitialVolume()
    {
        isMuted = DBManager.GetVolume();
    }

    private void ConfigVolume()
    {
        if (isMuted)
        {
            vfx.volume = 0;
            music.volume = 0;
        }
        else
        {
            vfx.volume = 0.5f;
            music.volume = 0.5f;
        }
        DBManager.SaveVolume(isMuted);
    }

    public void PlayMenuAudio()
    {
        if ((music.clip != menuClip))
        {
            music.Stop();
            music.clip = menuClip;
            music.Play();
        }
    }

    public void PlayGameAudio()
    {
        if (music.clip == menuClip) 
        {
            music.Stop();

            var sortedAudio = new System.Random().Next(0, gameClips.Length);
            music.clip = gameClips[sortedAudio];

            music.Play();
        }
    }

    public void PlayLaserAudio()
    {
        vfx.PlayOneShot(laserClip);
    }

    public void PlayExploxionAudio()
    {
        vfx.PlayOneShot(explosionClip);
    }

    public void PlayPowerUpAudio()
    {
        vfx.PlayOneShot(powerUpClip);
    }
}
