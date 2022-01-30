using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    
    public Sound[] sounds;
    public static AudioController instance;
    private DoctorMovement doctorMovement;
    private float musicVolume = 0.4f;

    void Awake()
    {
        if (instance == null) instance = this;
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        doctorMovement = gameObject.GetComponent<PlayerScore>().Doctor.GetComponent<DoctorMovement>();
        Play("Normal");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndMusic()
    {
        foreach(Sound sound in sounds) sound.source.volume = 0.0f;
    }

    public void Play(string name)
    {
        Sound snd = Array.Find(sounds, sound => sound.name == name);
        Sound[] dsbl = Array.FindAll(sounds, sound => sound.name != name);
        try
        {
            foreach(Sound sound in dsbl) sound.source.volume = 0.0f;
            snd.source.volume = musicVolume;
        } catch
        {
            Debug.LogWarning("Sound not found");
        }
    }

    public void UpdateTrack()
    {
        if (doctorMovement.IsNormal())
        {
            Play("Normal");
        } else if (doctorMovement.IsMuting())
        {
            Play("Muting");
        } else if (doctorMovement.IsMonster())
        {
            Play("Monster");
        }
    }
}
