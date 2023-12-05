using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyHitter : HitObjHitter
{
    public int FriendryLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnHit(HitObject hitObj)
    {
        //base.OnHit(hitObj);
        FriendlyHitObj friendlyHitter = hitObj as FriendlyHitObj;
        if (friendlyHitter && friendlyHitter.FriendlyLayer== FriendryLayer) 
        {
            //Debug.Log($"{hitObj.name}ÇÕñ°ï˚ÅI");
            return;
        }
        OnEnemyHit(hitObj);
    }

    protected virtual void OnEnemyHit(HitObject hitObj) 
    {
        //Debug.Log($"{hitObj.name}ÇÕìGÅI");
        hitObj.OnDamaged(new HitData(10));
    }
}
