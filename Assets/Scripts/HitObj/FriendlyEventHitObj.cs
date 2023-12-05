using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FriendlyEventHitObj : FriendlyHitObj
{
    [System.Serializable]
    public class UnityEvent_HitData : UnityEvent<HitData> { }
    [SerializeField] UnityEvent_HitData OnDamagedEvent;

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
        OnDamagedEvent.Invoke(hitData);
    }
}
