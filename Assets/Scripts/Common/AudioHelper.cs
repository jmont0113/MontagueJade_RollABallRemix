using UnityEngine;

public static class AudioHelper
{
    public static AudioSource PlayClip2D
        (AudioClip clip, float volume)
    {
        // create 
        GameObject audioObject
            = new GameObject("Audio2D");
        AudioSource audioSource
            = audioObject.AddComponent<AudioSource>();
        // cofigure
        audioSource.clip = clip;
        audioSource.volume = volume;
        // activate
        audioSource.Play();
        Object.Destroy(audioObject, clip.length);
        // return in case the call wants to do other things 
        return audioSource;
    }
}