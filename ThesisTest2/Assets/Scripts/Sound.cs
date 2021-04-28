using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;


    public AudioClip clip;


    [Range(0.0001f, 1f)]
    public float volume;
    [Range(.9f, 1.15f)]
    public float pitch;

    public bool loop;

    public AudioMixerGroup outputAudioMixerGroup;

    [HideInInspector]
    public AudioSource source; //ei tahdota näkyvän inspectorissa


}