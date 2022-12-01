﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController obj;

    public AudioClip jump;
    public AudioClip shoot;
    public AudioClip intro;
    public AudioClip live;
    public AudioClip coin;
    public AudioClip exitLevel;
    public AudioClip gameOver;
    public AudioClip caida;
    public AudioClip error;
    public AudioClip good;
    private AudioSource audioSource;

    private void Awake()
    {
        obj = this;
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    
    public void playJump()
    {
        playSound(jump);
    }

    public void playShoot()
    {
        playSound(shoot);
    }

    public void playGui()
    {
        playSound(intro);
    }

    public void playLive()
    {
        playSound(live);
    }

    public void playCoin()
    {
        playSound(coin);
    }

    public void playExit()
    {
        playSound(exitLevel);
    }
    
    public void playGameOver()
    {
        playSound(gameOver);
    }

    public void playCaida()
    {
        playSound(caida);
    }
    
    public void playError()
    {
        playSound(error);
    }

    public void playGood()
    {
        playSound(good);
    }

    public void playSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
