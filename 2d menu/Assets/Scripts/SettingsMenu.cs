using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public UnityEngine.UI.Slider m_slider;

    void Awake()
    {


        if (m_slider != null && PlayerPrefs.HasKey("volume")){

            // get temporary float
            float wantedVolume = PlayerPrefs.GetFloat("volume", 1f);
            
            // this is IMPORTANT I find because it update your slider because it will naturally start at 0 even when in a previous game you set it to whatever
            m_slider.value = wantedVolume;

            // this actually changes all game sounds volume
            //AudioListener.volume = PlayerPrefs.GetFloat("wantedVolume");
            AudioListener.volume = m_slider.value;

            //this adds a listener
            m_slider.onValueChanged.AddListener(delegate { SetGameVolume(m_slider.value); });
        }
    }
    public void SetGameVolume(float volume)
    {
        // update volume again when slider changes
        AudioListener.volume = volume;

        // this SAVES the incoming slider change for next time
        PlayerPrefs.SetFloat("volume", volume);


    }
   
}
