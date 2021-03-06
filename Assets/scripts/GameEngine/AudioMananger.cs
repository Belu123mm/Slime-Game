﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMananger : MonoBehaviour
{

    public static AudioMananger instance;

    public AudioMixer master;
    public AudioMixerGroup walk;
    public AudioMixerGroup hurt;
    public AudioMixerGroup pw;
    public AudioMixerGroup normalBullet;
    public AudioMixerGroup bigBullet;
    public AudioMixerGroup circleBullet;
    public AudioMixerGroup quickBullet;
    public AudioMixerGroup enemy;
    public AudioMixerGroup enemyHurt;
    public AudioMixerGroup crystalSlime;
    public AudioMixerGroup ambient;


    

    private void Awake()
    {
        instance = this;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlaySteps(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = walk;
        source.loop = true;
        source.clip = clip;
        source.Play();
    }

    public void PlayHurt(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = hurt;
        source.loop = false;
        source.clip = clip;
        source.Play();
    }
    public void PlayPw(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = pw;
        source.loop = false;
        source.clip = clip;
        source.Play();
    }
    public void PlayNormalBullet(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = normalBullet;
        source.loop = false;
        source.clip = clip;
        source.Play();
    }
    public void PlayEnemy(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = enemy;
        source.loop = false;
        source.clip = clip;
        source.Play();
    }
    public void PlayEnemyHurt(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = enemyHurt;
        source.loop = false;
        source.clip = clip;
        source.Play();
    }
    public void PlayCrystalSlime(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = crystalSlime;
        source.loop = false;
        source.clip = clip;
        source.Play();
    }
    public void PlayAmbient(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = ambient;
        source.loop = true;
        source.clip = clip;
        source.Play();
    }
    public void PlayBigBullet(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = bigBullet;
        source.loop = false;
        source.clip = clip;
        source.Play();
    }
    public void PlayCircleBullet(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = circleBullet;
        source.loop = false;
        source.clip = clip;
        source.Play();
    }
    public void PlayQuickBullet(AudioClip clip)
    {
        GameObject go = new GameObject("AudioSource");
        go.transform.parent = transform;
        AudioSource source = go.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = quickBullet;
        source.loop = false;
        source.clip = clip;
        source.Play();
    }
}
