using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FriendlyEventHitter : FriendlyHitter
{
    [System.Serializable]
    public class UnityEvent_HitObject : UnityEvent<HitObject> { }
    [SerializeField] UnityEvent_HitObject OnHitEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnEnemyHit(HitObject hitObj)
    {
        //base.OnEnemyHit(hitObj);
        OnHitEvent.Invoke(hitObj);
    }


}
