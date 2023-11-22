using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnDamaged(HitData hitData) 
    {
        Debug.Log($"{hitData.damagePoint}ダメージを受けた！");
    }
}

public class HitData 
{
    public float damagePoint;
    public HitData(float DamagePoint) 
    {
        damagePoint = DamagePoint;
    }
}
