using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HormingMover : MonoBehaviour
{
    public float MaxAngularV;
    public float MovingVelocity;
    public GameObject TargetObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void FixedUpdate()
    {
        if (TargetObject) 
        {
            float maxRotDelta_thisFrame=MaxAngularV * Time.fixedDeltaTime;
            this.transform.rotation =Quaternion.AngleAxis(Mathf.Clamp(0,-maxRotDelta_thisFrame, maxRotDelta_thisFrame),Vector3.up)*this.transform.rotation;
        }

        this.transform.position = this.transform.position + this.transform.rotation * Vector3.forward * MovingVelocity * Time.fixedDeltaTime;
    }
}
