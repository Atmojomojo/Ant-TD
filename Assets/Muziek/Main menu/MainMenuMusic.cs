using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public AudioSource intro, loop;

    public void Start()
    {
        intro.enabled = true;
        loop.enabled = false;
    }
    void Update()
    {
        if (!intro.isPlaying)
        {
            intro.enabled = false;
            loop.enabled = true;
        }
    }
}
