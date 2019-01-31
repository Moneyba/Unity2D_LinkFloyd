using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour {

    public SoundClip[] soundClips;

    Dictionary<string, AudioClip> audioDictionary = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        foreach (SoundClip soundCip in soundClips)
        {
            audioDictionary.Add(soundCip.clipName, soundCip.audioClip);
        }
    }

    public AudioClip GetClipFromName(string name)
    {
        if(audioDictionary.ContainsKey(name))
        {
            AudioClip sound = audioDictionary[name];
            return sound;
        }
        return null;
    }

    [System.Serializable]
    public class SoundClip
    {
        public string clipName;
        public AudioClip audioClip;
    }


}
