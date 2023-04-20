using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunsetController : MonoBehaviour
{
    [SerializeField] private AudioClip ambienceBase;
    [SerializeField] private AudioClip ambienceNight;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayAmbienceBase()
    {
        audioSource.clip = ambienceBase;
        audioSource.Play();
    }

    public void PlayAmbienceNight()
    {
        audioSource.clip = ambienceNight;
        audioSource.Play();
    }

}
