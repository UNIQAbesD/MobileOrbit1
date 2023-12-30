using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventHPComp : HPComponent
{
    // Start is called before the first frame update
    [System.Serializable]
    public class UnityEvent_HPComponent : UnityEvent<HPComponent> { }

    [System.Serializable]
    public class UnityEvent_HitData : UnityEvent<HitData> { }

    [SerializeField] UnityEvent_HitData OnDamagedEvent;
    [SerializeField] UnityEvent_HPComponent OnDeathEvent;

    public override void OnDamaged(HitData hitData)
    {
        OnDamagedEvent.Invoke(hitData);
        base.OnDamaged(hitData);
    }

    public override void OnDeath()
    {
        OnDeathEvent.Invoke(this);
        //base.OnDeath();
    }
}
