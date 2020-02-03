using System.Collections.Generic;
using UnityEngine;

public class RandomSoundOnClick : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;

    private AudioSource audioSource;
    private Car car;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        car = GetComponent<Car>();
        car.HealthUpdated += Car_HealthUpdated;
    }

    private void Car_HealthUpdated()
    {
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Count)]);
    }
}