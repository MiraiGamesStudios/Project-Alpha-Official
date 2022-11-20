using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] public Slider volumeSlider;
    [SerializeField] public TextMeshProUGUI VolumenValueText;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = 1;
    }


    public void changeVolume(float volume)
    {
        AudioListener.volume = volumeSlider.value;
        float volumeInt = volume * 100;
        VolumenValueText.text = volumeInt.ToString("0");
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
