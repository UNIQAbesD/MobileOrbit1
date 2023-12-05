using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDamageComp : MonoBehaviour
{
    public float DamagePoint;

    public void OnHit(HitObject hitObj) 
    {
        hitObj.OnDamaged(new HitData(10));
    }
}
