using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHitComp : MonoBehaviour
{
    public void OnHit(HitObject hitObj)
    {
        Destroy(this.gameObject);
    }
}
