using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1Mover : MonoBehaviour
{
    public float CurTheta=0;
    public float AngularV=60;
    public Vector3 CenterPos;
    public float OrbitRadius;

    public float YRot_xyOrder;
    public float XRot_xyOrder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        YRot_xyOrder = Mathf.Clamp(YRot_xyOrder + Input.mouseScrollDelta.x, -90, 90);
        XRot_xyOrder = Mathf.Clamp(XRot_xyOrder + Input.mouseScrollDelta.y, -45, 45);
        if (Input.GetKey(KeyCode.A))
        {
            CurTheta += AngularV * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            CurTheta -= AngularV * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion cameraLocalRot = Quaternion.Euler(XRot_xyOrder, YRot_xyOrder, 0);

        Quaternion RotQ =Quaternion.AngleAxis(CurTheta, Vector3.up);
        this.transform.position = CenterPos+ RotQ * Vector3.back* OrbitRadius;
        this.transform.rotation = RotQ* cameraLocalRot;

    }
}
