using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPComponent : MonoBehaviour
{
    public float HP;
    public bool InvokedOnDeathEvent;

    private void Start()
    {
        InvokedOnDeathEvent = false;
    }

    public void OnDamaged(HitData hitData) 
    {
        HP -= hitData.damagePoint;
        if (HP <= 0& !InvokedOnDeathEvent) 
        {
            InvokedOnDeathEvent = true;
            OnDeath();
        }
    }

    public virtual void OnDeath() 
    {
        Debug.Log($"{this.gameObject.name}‚ÍŽ€‚ñ‚Å‚µ‚Ü‚Á‚½I");
    }
}
