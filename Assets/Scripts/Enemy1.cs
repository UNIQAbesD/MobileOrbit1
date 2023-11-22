using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : HitObject
{
    int HP = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnDamaged(HitData hitData)
    {
        //base.OnDamaged(hitData);
        HP -= (int)hitData.damagePoint;
    }
}
