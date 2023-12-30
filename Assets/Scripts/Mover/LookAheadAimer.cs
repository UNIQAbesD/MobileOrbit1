using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAheadAimer : MonoBehaviour
{
    public float MaxAngularV = 180;
    public float BulletVelocity = 40;
    public GameObject TargetObject;


    public Vector3 PrevFramePos=new Vector3(0,0,0);

    private void Start()
    {
        if (TargetObject) 
        {
            PrevFramePos = TargetObject.transform.position;
        }
       
    }

    private void FixedUpdate()
    {
        Vector3 TargetObjVelocity = (TargetObject.transform.position - PrevFramePos) / Time.fixedDeltaTime;
        Vector3 TargetPosition_Relative = TargetObject.transform.position - this.transform.position;
        float Cos_This_Target_Dest = Vector3.Dot(TargetObjVelocity.normalized, -TargetPosition_Relative.normalized);

        float reachTime=(2* TargetPosition_Relative.magnitude* TargetObjVelocity.magnitude* Cos_This_Target_Dest)/(Mathf.Pow(TargetObjVelocity.magnitude, 2)+ Mathf.Pow(BulletVelocity, 2)) ;
        //float reachTime = TargetPosition_Relative.magnitude / BulletVelocity;

        Vector3 DestPos_Relative = reachTime * TargetObjVelocity + TargetPosition_Relative;


        Vector3 LocalForward = this.transform.rotation * Vector3.forward;
        Vector3 rotationAxies = Vector3.Cross(LocalForward, DestPos_Relative);
        float TwoVectorDeg = Vector3.SignedAngle(LocalForward, DestPos_Relative, rotationAxies);
        float maxRotDelta_thisFrame = MaxAngularV * Time.fixedDeltaTime;
        this.transform.rotation = Quaternion.AngleAxis(Mathf.Clamp(TwoVectorDeg, 0, maxRotDelta_thisFrame), rotationAxies) * this.transform.rotation;
    }
}
