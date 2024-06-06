using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{

    public Sound[] soundsEffects;
    public Sound[] musics;

    public AudioMixer audioMix;

    public float masterVolume, musicVolume, sfxVolume;
    bool pauseMod = false;

    protected override void Awake()
    {

        DontDestroyOnLoad(this);

        base.Awake();

        foreach (Sound s in soundsEffects)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            if (s.playOnAwake)
            {
                Play(s.name);
            }
            s.source.outputAudioMixerGroup = s.output;
        }
        foreach (Sound s in musics)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            if (s.playOnAwake)
            {
                PlayMusic(s.name);
            }
            s.source.outputAudioMixerGroup = s.output;
        }
    }

    public void Start()
    {
        /*ModifyAllVolume(masterVolume);
        ModifyMusicVolume(musicVolume);
        ModifySFXVolume(sfxVolume);*/
        PlayMusic("1");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(soundsEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("sound name not found : " + name);
            return;
        }
        s.source.Play();
    }

    public void PlayOnAwake(string name, bool playOnAwake)
    {
        Sound s = Array.Find(soundsEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("sound name not found : " + name);
            return;
        }
        s.source.playOnAwake = playOnAwake;
    }

    public void PauseMod(bool a)
    {
        if (pauseMod == a) return;
        if (a)
        {
            foreach (Sound s in musics)
            {
                s.source.volume /= 5;
                s.volume /= 5;
            }
        }
        else
        {
            foreach (Sound s in musics)
            {
                s.source.volume *= 5;
                s.volume *= 5;
            }
        }
        pauseMod = a;
    }

    public void PauseSound(string name)
    {
        Sound s = Array.Find(soundsEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("musics name not found : " + name);
            return;
        }
        s.source.Pause();
    }
    public void UnpauseSound(string name)
    {
        Sound s = Array.Find(soundsEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("musics name not found : " + name);
            return;
        }
        s.source.UnPause();
    }
    public void StopSound(string name)
    {
        Sound s = Array.Find(soundsEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("musics name not found : " + name);
            return;
        }
        s.source.Stop();
    }

    public void ModifyVolume(string name, float volume)
    {
        Sound s = Array.Find(soundsEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("sound name not found : " + name);
            return;
        }
        s.source.volume = volume;
    }

    public void ModifyAllVolume(float i)
    {
        audioMix.SetFloat("Master", Mathf.Log10(i) * 20);
        masterVolume = i;
    }

    public void ModifyMusicVolume(float i)
    {
        audioMix.SetFloat("Musics", Mathf.Log10(i) * 20);
        musicVolume = i;
    }

    public void ModifySFXVolume(float i)
    {
        audioMix.SetFloat("SoundEffects", Mathf.Log10(i) * 20);
        sfxVolume = i;
    }

    public void ModifyPitch(string name, float pitch)
    {
        Sound s = Array.Find(soundsEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("sound name not found : " + name);
            return;
        }
        s.source.pitch = pitch;
    }
    public float PlayTime(string name)
    {
        Sound s = Array.Find(soundsEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("sound name not found : " + name);
            return 0;
        }
        s.source.Play();
        return s.clip.length;
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musics, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("musics name not found : " + name);
            return;
        }
        s.source.Play();
    }
    public void PauseMusic(string name)
    {
        Sound s = Array.Find(musics, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("musics name not found : " + name);
            return;
        }
        s.source.Pause();
    }
    public void UnpauseMusic(string name)
    {
        Sound s = Array.Find(musics, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("musics name not found : " + name);
            return;
        }
        s.source.UnPause();
    }
    public void StopMusic(string name)
    {
        Sound s = Array.Find(musics, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("musics name not found : " + name);
            return;
        }
        s.source.Stop();
    }

    public void ModifyMusicVolume(string name, float volume)
    {
        Sound s = Array.Find(musics, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("sound name not found : " + name);
            return;
        }
        s.source.volume = volume;
    }

    public void StopAllSoud()
    {
        foreach (Sound s in soundsEffects)
        {
            s.source.Stop();
        }
        foreach (Sound s in musics)
        {
            s.source.Stop();
        }
    }

}

