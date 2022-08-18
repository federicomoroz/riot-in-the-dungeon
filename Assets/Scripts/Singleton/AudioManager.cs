using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioClip[] stageMusic;
    public AudioSource audioSrc;


    private void Awake()
    {
        int Q = FindObjectsOfType<AudioManager>().Length;
        instance = this;

        if (Q > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.loop = true;

    }
    public void StopStageStong()
    {
        //audioSrc.Stop();
    }
}