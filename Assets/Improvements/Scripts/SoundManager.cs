using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider SFXSlider;
    public AudioSource[] SFXSource;
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
        }
    }
}
