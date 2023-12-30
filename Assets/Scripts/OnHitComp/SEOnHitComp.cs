using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEOnHitComp : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float VolumeScale=1;
 
    public void OnHit(HitData hitData) 
    {
        audioSource.PlayOneShot(audioClip, VolumeScale);
    }
}
