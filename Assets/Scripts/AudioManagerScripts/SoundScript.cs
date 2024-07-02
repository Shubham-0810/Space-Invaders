using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class SoundScript
{
   public AudioClip clip;
    public string name;

    [Range(0f,1f)]
    public float volume;

    [Range(0.1f,3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
