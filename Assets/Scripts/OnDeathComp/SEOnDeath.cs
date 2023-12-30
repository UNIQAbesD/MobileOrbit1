using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEOnDeath : MonoBehaviour
{
    public AudioSource SEPrefab;
    public AudioClip audioClip;
    public float VolumeScale = 1;

    public void OnHit(HPComponent hpComponent)
    {
        SEPrefab.clip= audioClip;
        SEPrefab.volume = VolumeScale;
        Instantiate(SEPrefab.gameObject,this.transform.position,Quaternion.identity);
    }
}
