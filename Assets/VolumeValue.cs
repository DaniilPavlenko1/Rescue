using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("Volume", 1);
    }
    void Update()
    {
        audioSrc.volume = PlayerPrefs.GetFloat("Volume");
    }
    public void SetVolume(float vol)
    {
        PlayerPrefs.SetFloat("Volume", vol);
    }
}