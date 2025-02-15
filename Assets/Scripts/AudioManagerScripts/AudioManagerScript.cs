using UnityEngine.Audio;
using System;
using UnityEngine;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour
{
    
   


    public SoundScript[] sounds;

    public static AudioManagerScript instance;

    
    
    void Awake()
    {
      
        
        Debug.Log("hii");
        if (instance == null)
        {         
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (SoundScript s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

   


   public void ChangeVolume(float volume)
    {      
        foreach (SoundScript s in sounds)
        {
            if (s.name == "Theme")
            {
                s.source.volume = volume;
                PlayerPrefs.SetFloat("VolumeSliderValue",volume);
            }
        }
    }

    private void Start()
    {
        Play("Theme");
       
    }

    public void Play(string name)
    {
        SoundScript s = Array.Find(sounds, SoundScript => SoundScript.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}


