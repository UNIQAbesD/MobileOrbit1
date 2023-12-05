using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventHPComp : HPComponent
{
    // Start is called before the first frame update
    [System.Serializable]
    public class UnityEvent_HPComponent : UnityEvent<HPComponent> { }
    [SerializeField] UnityEvent_HPComponent OnDeathEvent;

    public override void OnDeath()
    {
        OnDeathEvent.Invoke(this);
        //base.OnDeath();
    }
}
