using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventTest : MonoBehaviour
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
        OnDamagedEvent.Invoke(new HitData(10));
    }

    public void Test1Func(HitData hitData) 
    {
        Debug.Log($"{hitData.damagePoint}É_ÉÅÇ‡ÇÁÇ¡ÇΩÅ`");

    }
}
