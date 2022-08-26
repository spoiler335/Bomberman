using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static bool isMute = false;
    public static AudioManager Instance;
    private AudioSource audioSource;

    [SerializeField] AudioClip[] sounds;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    public void playSound(string clip)
    {
        if(!isMute)
        {
            switch(clip)
            {
                case "sound1":
                    audioSource.PlayOneShot(sounds[0], 1f);
                    break;

                case "sound2":
                    audioSource.PlayOneShot(sounds[1], 1f);
                    break;

                case "sound3":
                    audioSource.PlayOneShot(sounds[2], 1f);
                    break;

                default:
                    Debug.LogError("No Clip to Play");
                    break;
            }
        }
    }
}
