using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    Slider MasterSlider, BGMSlider, SFXSlider;
    [SerializeField]
    AudioMixer AudioMixer;
    [SerializeField]
    Image image;
    void Start()
    {
        MasterSlider.value = AudioListener.volume;
    }
    public void button()
    {
        if(image.gameObject.activeSelf)
        {
            image.gameObject.SetActive(false);
        }
        else
        {
            image.gameObject.SetActive(true);
        }
    }
    public void MasterSoundSet()
    {
        float sound = MasterSlider.value;

        if (sound == -40f) AudioListener.volume = -80;
        else AudioListener.volume = sound;

    }
    public void BGMSoundSet()
    {
        float sound = BGMSlider.value;

        if (sound == -40f) AudioMixer.SetFloat("BGM", -80);
        else AudioMixer.SetFloat("BGM", sound);

    }
    public void SFXSoundSet()
    {

        float sound = SFXSlider.value;

        if (sound == -40f) AudioMixer.SetFloat("SFX", -80);
        else AudioMixer.SetFloat("SFX", sound);

    }
}
