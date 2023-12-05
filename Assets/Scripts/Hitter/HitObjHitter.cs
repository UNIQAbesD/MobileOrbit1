using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;

public class HitObjHitter : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        HitObject hitobjsHitObject = other.gameObject.GetComponent<HitObject>();
        if (hitobjsHitObject) 
        {
            OnHit(hitobjsHitObject);
        }
        //hitobjsHitObject.OnDamaged(new HitData(10));
    }

    protected virtual void OnHit(HitObject hitObj) 
    {
        Debug.Log($"{hitObj.name}‚Éhit");
    }
}
