using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    [SerializeField, Tooltip("Master audio mixer.")]
    private AudioMixer audioMixer;
    public Slider SFXSlider;
    [SerializeField, Tooltip("Slider value to Decibel value.")]
    private AnimationCurve volumeVsDecibels;

    public void AdjustVolume() 
    {
        audioMixer.SetFloat("Master Volume", volumeVsDecibels.Evaluate(SFXSlider.value));
    }
 /*
  
    public AudioClip[] backgroundMusic;
    public Slider SFXSlider, musicSlider;
    public AudioSource[] SFXSource;
    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void AdjustVolume()
    {
        for (int i = 0; i < SFXSource.Length; i++) 
        {
            SFXSource[i].volume = SFXSlider.value;
            musicSource.volume = musicSlider.value;
        }
    }
 */
}
