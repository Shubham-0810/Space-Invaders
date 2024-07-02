using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChangerScript : MonoBehaviour
{
    public AudioManagerScript AudioManager;
    public SoundScript[] sounds;

    [SerializeField] private Slider VolumeSlider;

    public void Awake()
    {
        AudioManager = GameObject.FindGameObjectWithTag("AudioManagerTag").GetComponent<AudioManagerScript>();
        SetVolumeSlider();
        
    }

    public void SetVolumeSlider()
    {
        foreach (SoundScript s in sounds)
        {
            if (s.name == "Theme")
            {
                try
                {
                    VolumeSlider.value = s.source.volume;
                }
                catch(NullReferenceException)
                {
                   
                   VolumeSlider.value = PlayerPrefs.GetFloat("VolumeSliderValue");
                }
            }

        }
    }
    public void Change_Volume(float volume)
    {
      
       AudioManager.ChangeVolume(volume);
    }
}
