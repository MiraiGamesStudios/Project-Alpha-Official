using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] public Slider volumeSlider;
    [SerializeField] public Slider volumeMusicSlider;
    [SerializeField] public Slider volumeSFXSlider;
    [SerializeField] public Slider ENGVolumeSlider;
    [SerializeField] public Slider ENGVolumeMusicSlider;
    [SerializeField] public Slider ENGVolumeSFXSlider;
    [SerializeField] public TextMeshProUGUI VolumenValueText;
    [SerializeField] public TextMeshProUGUI SFXValueText;
    [SerializeField] public TextMeshProUGUI MusicValueText;
    [SerializeField] public TextMeshProUGUI ENGVolumenValueText;
    [SerializeField] public TextMeshProUGUI ENGSFXValueText;
    [SerializeField] public TextMeshProUGUI ENGMusicValueText;
    [SerializeField] public List<AudioSource> SFXAudios;
    [SerializeField] public List<AudioSource> MusicAudios;
    [SerializeField] public CambiarIdioma controladorIdioma;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = 1;
        volumeMusicSlider.value = MusicAudios[0].volume;
        volumeSFXSlider.value = 1;
        ENGVolumeSlider.value = 1;
        ENGVolumeMusicSlider.value = MusicAudios[0].volume;
        ENGVolumeSFXSlider.value = 1;
    }


    public void changeVolume(float volume)
    {
        if (controladorIdioma.Language == 0)
        {
            AudioListener.volume = volumeSlider.value;
            float volumeInt = volume * 100;
            VolumenValueText.text = volumeInt.ToString("0");
        }
        if (controladorIdioma.Language == 1)
        {
            AudioListener.volume = ENGVolumeSlider.value;
            float volumeInt = volume * 100;
            ENGVolumenValueText.text = volumeInt.ToString("0");
        }
        
    }

    public void changeSFXVolume(float volume)
    {
        if (controladorIdioma.Language == 0)
        {
            setVolume(SFXAudios, volumeSFXSlider.value);
            float volumeInt = volume * 100;
            SFXValueText.text = volumeInt.ToString("0");
        }
        if (controladorIdioma.Language == 1)
        {
            setVolume(SFXAudios, ENGVolumeSFXSlider.value);
            float volumeInt = volume * 100;
            ENGSFXValueText.text = volumeInt.ToString("0");
        }

    }

    public void changeMusicVolume(float volume)
    {
        if (controladorIdioma.Language == 0)
        {
            setVolume(MusicAudios, volumeMusicSlider.value);
            float volumeInt = volume * 100;
            MusicValueText.text = volumeInt.ToString("0");
        }
        if (controladorIdioma.Language == 1)
        {
            setVolume(MusicAudios, ENGVolumeMusicSlider.value);
            float volumeInt = volume * 100;
            ENGMusicValueText.text = volumeInt.ToString("0");
        }
        
    }


    public void setVolume(List<AudioSource> audios, float volume)
    {
        foreach (AudioSource aud in audios)
        {
            aud.volume = volume;
        }
    }

    /*public void SaveVolumeButton()
    {
        float volumenValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumenValue", volumenValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumenValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }*/
}
