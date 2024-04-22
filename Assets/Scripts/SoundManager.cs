using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip BG_Sound;
    public AudioClip Button_Sound;
    public AudioClip Coin_Sound;
    public AudioClip Level_Fail_Sound;
    public AudioClip Level_Complete_Sound;
    public AudioClip LifeLost_Meow;

    public AudioSource Music_Source;
    public AudioSource SFX_Source;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {

        Music_Source.clip = BG_Sound;
        Music_Source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
