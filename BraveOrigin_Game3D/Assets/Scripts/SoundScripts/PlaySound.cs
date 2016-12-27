using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    public string WhatSound;

    public void PlaySounds(int NumSound)
    {
        AudioSource ATK = GameObject.Find(WhatSound).transform.GetChild(NumSound).GetComponent<AudioSource>();
        ATK.Play();
    }



    
}
