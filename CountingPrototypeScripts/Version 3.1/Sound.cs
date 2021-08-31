using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip burningTrash;
    public float burningTrashSoundLevel = 1.0f;
    public AudioClip _counted;
    public float maxCountedSoundLevel = 10.0f;
    public AudioClip _click;
    public float clickSoundLevel = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(AudioClip sound, float soundLevel)
    {
        audioSource.PlayOneShot(sound, soundLevel);
    }
}
