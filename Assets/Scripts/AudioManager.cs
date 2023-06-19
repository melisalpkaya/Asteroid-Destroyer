using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    // this script is for background music
    private static AudioManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public static AudioManager Instance
    {
        get { return instance; }
    }

    public void PlayMusic(AudioClip music)
    {
        audioSource.clip = music;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
