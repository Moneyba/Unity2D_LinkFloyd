using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour {

    Dictionary<string, AudioClip[]> groupDictionary = new Dictionary<string, AudioClip[]>();

    private void Awake()
    {
        
    }

    public AudioClip GetClipFromName(string name) {
        
        return null;
    }
}
