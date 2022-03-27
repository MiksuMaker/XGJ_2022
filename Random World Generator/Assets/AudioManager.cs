using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AUMA;

    public AudioClip soSound1;
    public AudioClip soSound2;
    public AudioClip soSound3;
    public AudioClip soEAT;
    public AudioClip soKalaSpawn;
    public AudioClip soLihisSpawn;
    public AudioClip soMETEORITE;
    public AudioClip soRAIN;
    public AudioClip soSTEAM;
    public AudioClip soPILVI;

    public AudioClip RAINRAIN;
    public AudioClip RANDOM;


    private void Awake()
    {
        AUMA = this;
    }

    [SerializeField] AudioSource au;

    public void playSound(AudioClip _clip)
    {
        au.PlayOneShot(_clip);
    }

}
