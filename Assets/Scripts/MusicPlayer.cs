using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource[] music = null;
    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    void Start()
    {
        PlayNextSong();
    }

    void PlayNextSong(){
        AudioSource audio  = music[Random.Range(0,music.Length)];
        audio.Play();
        Invoke(nameof(PlayNextSong), audio.clip.length);
    }
}
