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

    public bool IsGuard=false;

    public bool LeftMoveStop=false;
    public bool RightMoveStop=false;

    public GameObject CenterSat;
    public GameObject LeftSat;
    public GameObject RightSat;
    public GameObject GuardSat;
    public GameObject PlayerCameraObj;

    public LineRenderer lineRenderer;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        IsGuard = Input.GetMouseButton(1);

        YRot_xyOrder = Mathf.Clamp(YRot_xyOrder + Input.GetAxis("Mouse X"), -90, 90);
        XRot_xyOrder = Mathf.Clamp(XRot_xyOrder - Input.GetAxis("Mouse Y")*1.5f, -45, 45);
        if (Input.GetKey(KeyCode.A)&!LeftMoveStop)
        {
            CurTheta += AngularV * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)&!RightMoveStop)
        {
            CurTheta -= AngularV * Time.deltaTime;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GuardSat.SetActive(IsGuard);
        Quaternion cameraLocalRot = Quaternion.Euler(XRot_xyOrder, YRot_xyOrder, 0);
        Quaternion RotQ =Quaternion.AngleAxis(CurTheta, Vector3.up);

        CenterSat.transform.localRotation = cameraLocalRot;
        

        this.transform.position = CenterPos+ RotQ * Vector3.back* OrbitRadius;
        this.transform.rotation = RotQ;
        LeftMoveStop = false;
        RightMoveStop = false;

        //åıê¸ÇèoÇ∑
        if (Input.GetMouseButton(0))
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, this.transform.position);
            lineRenderer.SetPosition(1, this.transform.position + PlayerCameraObj.transform.rotation * Vector3.forward * 100);

            RaycastHit hit;
            if (Physics.SphereCast(PlayerCameraObj.transform.position + PlayerCameraObj.transform.rotation * Vector3.forward * 9, 4, PlayerCameraObj.transform.rotation * Vector3.forward, out hit))
            {
                lineRenderer.SetPosition(1, hit.point);
                if (hit.collider.gameObject.CompareTag("HitObject"))
                {
                    HitObject hitobjsHitObject = hit.collider.gameObject.GetComponent<HitObject>();
                    hitobjsHitObject.OnDamaged(new HitData(10));
                }
            }
        }
        else 
        {
            lineRenderer.enabled = false;
        }
        
    }

    
}
