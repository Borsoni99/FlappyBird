using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeSlider : MonoBehaviour
{
    public AudioSource audioSource;
    public UnityEngine.UI.Slider volumeSlider;

    private void Start()
    {
        // set the slider value to the current volume of the audio source
        volumeSlider.value = audioSource.volume;
    }

    public void SetVolume(float newVolume)
    {
        audioSource.volume = newVolume;
    }
}
