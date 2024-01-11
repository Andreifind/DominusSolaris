using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject retro;
    public GameObject sett;
    public GameObject mainm;
    public void SetMusicVolume (float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }
    public void RetroON (bool isretro)
    {
        if(isretro)
        {
            retro.SetActive(true);
        }
        else 
        {
            retro.SetActive(false);
        }
            
    }
    public void Ret()
    {
        sett.SetActive(false);
        //mainm.SetActive(true);
    }

}
