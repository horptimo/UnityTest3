using UnityEngine.Audio;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    // Random pitch adjustment & volume range for Burst 
    public float LowPitchRange;
    public float HighPitchRange;
    public float MinVolume;
    public float MaxVolume;
    public float randomPitch;
    public float randomVolume;
    public AudioMixer mixer;

    public Sound[] sounds;


    public static AudioManager instance;
    public static AudioManager Instance
    {
        get { return instance; } // katotaas vaikuttaako tää (en tiedä vaikuttaako)
    }

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);



        foreach (Sound s in sounds) // laitetaan äänilähde ja muuttujat jokaiselle äänelle Sound[]-taulukossa
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;


            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = s.outputAudioMixerGroup;
            //string _OutputMixer = "Music";

            //s.source = GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups(_OutputMixer)[0];
            //s.source.outputAudioMixerGroup = GetComponent<AudioSource>().outputAudioMixerGroup;
        }
    }

    void Start()
    {

        //Play("Theme");

    }

    void Update()
    {




    }

    public void Play(string name) //
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found!");
            return; // jos on ääntä ei löydy tai kirjoitettu väärä nimi, niin tää ohittaa nullista aiheutuvat ongelmat

        }
        //katotaas toimiiko fade
        if (name == "Theme") //testinimi biisille
        {
            StartCoroutine(FadeMusic.StartFade(s.source, 1f, 0.5f));
        }
        else
        {
            StartCoroutine(FadeMusic.StartFade(s.source, 1f, 0.8f));
        }
        s.source.Play();

    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found!");
            return; // jos on ääntä ei löydy tai kirjoitettu väärä nimi, niin tää ohittaa nullista aiheutuvat ongelmat

        }

        

        StartCoroutine(FadeMusic.StartFade(s.source, 1f, 0.0001f));



        s.source.Stop();
        

    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found!");
            return; // jos on ääntä ei löydy tai kirjoitettu väärä nimi, niin tää ohittaa nullista aiheutuvat ongelmat

        }
        randomPitch = Random.Range(LowPitchRange, HighPitchRange);
        randomVolume = Random.Range(MinVolume, MaxVolume);

       

        s.source.volume = randomVolume;
        s.source.pitch = randomPitch;
        s.source.Play();

    }

}

