using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UItest : MonoBehaviour
{
    public Slider mainvolumeSlider;
    public AudioMixer mainMixer;

    bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        mainvolumeSlider.onValueChanged.AddListener(VolumeChange );
    }

    public void VolumeChange(float volume)
    {
        mainMixer.SetFloat("MainVolume", volume);
    }
    public void PauseGame()
    { 
        isPause = !isPause;
        if(isPause )
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
