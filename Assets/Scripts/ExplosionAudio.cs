using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAudio : MonoBehaviour
{
    [SerializeField] private AudioSource[] clips;

    void Awake()
    {
        int random = Random.Range(0, clips.Length);
        clips[random].Play();
    }
}
