using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HormingMover : MonoBehaviour
{
    public float MaxAngularV=180;
    public float MovingVelocity=40;
    public GameObject TargetObject;

    public float starightTime=2;
    public float LifeTime = 10;
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
        starightTime-= Time.fixedDeltaTime;
        LifeTime -= Time.fixedDeltaTime;
        if (TargetObject& starightTime<=0) 
        {
            Vector3 TargetPosition_Relative= TargetObject.transform.position-this.transform.position;
            Vector3 LocalForward= this.transform.rotation*Vector3.forward;
            Vector3 rotationAxies = Vector3.Cross(LocalForward,TargetPosition_Relative);
            float TwoVectorDeg= Vector3.SignedAngle(LocalForward, TargetPosition_Relative, rotationAxies);
            float maxRotDelta_thisFrame=MaxAngularV * Time.fixedDeltaTime;
            this.transform.rotation =Quaternion.AngleAxis(Mathf.Clamp(TwoVectorDeg,0,maxRotDelta_thisFrame), rotationAxies) *this.transform.rotation;

            //this.transform.rotation = V3_MyUtil.RotateV2V(Vector3.forward, TargetPosition_Relative);
            
        }

        this.transform.position = this.transform.position + this.transform.rotation * Vector3.forward * MovingVelocity * Time.fixedDeltaTime;

        if (LifeTime <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
}
