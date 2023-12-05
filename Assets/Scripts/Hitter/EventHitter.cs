using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;

public class EventHitter : HitObjHitter
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


    protected override void OnHit(HitObject hitObj) 
    {
        OnHitEvent.Invoke(hitObj);
    }
}
