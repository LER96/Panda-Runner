using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeLevel : MonoBehaviour
{
    [SerializeField] Slider volume;

    // Checks if user values are part of volume range
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    //Changes the value of volume using the slider
    //Uses the AudioListener of the camera
    public void ChangeVolume()
    {
        AudioListener.volume = volume.value;
    }

    //Receives values of what the user inputed
    private void Load()
    {
        volume.value = PlayerPrefs.GetFloat("musicVolume");
    }

    //Saves values of what the user inputed
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volume.value);
    }
}
