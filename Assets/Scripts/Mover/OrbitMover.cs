using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMover : MonoBehaviour
{
    public float CurTheta = 0;
    public float AngularV = 40;
    public Vector3 CenterPos=new Vector3(0,0,0);
    public float OrbitRadius=50;
    

    public float LifeTime=2;
    // Start is called before the first frame update
    void Start()
    {
        
        Vector3 ObjPos_CenterLocal= this.transform.position - CenterPos;
        CurTheta = Mathf.Atan2(-ObjPos_CenterLocal.x, -ObjPos_CenterLocal.z)/Mathf.PI*180;
        //CurTheta = 90;

    }

    void FixedUpdate()
    {
        
        LifeTime-=Time.fixedDeltaTime;
        if (LifeTime <= 0) 
        {
            Destroy(this.gameObject);
        }
        CurTheta += AngularV * Time.fixedDeltaTime;
        Quaternion RotQ = Quaternion.AngleAxis(CurTheta, Vector3.up);
        this.transform.position = CenterPos + RotQ * Vector3.back * OrbitRadius;
        this.transform.rotation = RotQ*Quaternion.AngleAxis(90,Vector3.up);

    }

}


