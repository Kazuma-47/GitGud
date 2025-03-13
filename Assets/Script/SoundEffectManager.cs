using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<Sound> sounds;      

    private Dictionary<string, AudioClip> soundDictionary;
    [SerializeField] private UnityEvent onStart = new();

    private void Awake()
    {
        soundDictionary = new Dictionary<string, AudioClip>();

        foreach (Sound sound in sounds)
        {
            if (!soundDictionary.ContainsKey(sound.name))
                soundDictionary.Add(sound.AudioName, sound.AudioClip);
        }
    }

    private void Start()
    {
        onStart?.Invoke();
    }
    public void PlaySound(string soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out AudioClip clip))
            audioSource.PlayOneShot(clip); 
    }
}
