using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource[] music = null;
    void Start()
    {
        PlayNextSong();
    }

    void PlayNextSong(){
        AudioSource audio  = music[Random.Range(0,music.Length)]; // get random song
        audio.Play();
        Invoke(nameof(PlayNextSong), audio.clip.length); // play next song, after the current one is done playing
    }
}
