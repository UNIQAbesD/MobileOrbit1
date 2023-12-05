using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeComp : MonoBehaviour
{
    public float LifeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        LifeTime -= Time.fixedDeltaTime;
        if (LifeTime <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
