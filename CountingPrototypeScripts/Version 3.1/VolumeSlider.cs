using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        volumeSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        MusicVolumeSetting();
    }

    private void MusicVolumeSetting()
    {
        music.volume = volumeSlider.value;
    }


}
