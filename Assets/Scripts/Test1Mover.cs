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
    public AttackSat1 LeftDrill;
    public AttackSat1 RightDrill;
    public GameObject GuardSat;
    public GameObject PlayerCameraObj;

    public LineRenderer lineRenderer;

    public GameObject LazerBeamObject;
    public float LazerBeamSize;


    float ParringTimer = 0;
    bool CantStartParring_R=false;
    bool CantStartParring_L = false;
    float CT_LazerBeam=0;




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

            if ((RightDrill.isParring | (!LeftDrill.isParring & !RightDrill.isParring))& !CantStartParring_L) 
            {
                CantStartParring_L = true;
                CantStartParring_R = false;


                ParringTimer = 0.3f;
                LeftDrill.isParring = true;
                RightDrill.isParring = false;
            }
            
        }
        if (Input.GetKey(KeyCode.D)&!RightMoveStop)
        {
            CurTheta -= AngularV * Time.deltaTime;
            if ((LeftDrill.isParring | (!LeftDrill.isParring & !RightDrill.isParring)) & !CantStartParring_R)
            {
                CantStartParring_L = false;
                CantStartParring_R = true;

                ParringTimer = 0.3f;
                LeftDrill.isParring = false;
                RightDrill.isParring = true;
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (ParringTimer <= 0)
        {
            ParringTimer = 0;
            LeftDrill.isParring = false;
            RightDrill.isParring = false;
        }
        else
        {
            ParringTimer -= Time.fixedDeltaTime;
        }

        if (CT_LazerBeam > 0) 
        {
            CT_LazerBeam -= Time.fixedDeltaTime;
        }


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
            Vector3 shotTo = this.transform.position + PlayerCameraObj.transform.rotation * Vector3.forward * 100;

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, this.transform.position);
            lineRenderer.SetPosition(1, this.transform.position + PlayerCameraObj.transform.rotation * Vector3.forward * 100);

            RaycastHit hit;
            if (Physics.SphereCast(PlayerCameraObj.transform.position + PlayerCameraObj.transform.rotation * Vector3.forward * 9, 4, PlayerCameraObj.transform.rotation * Vector3.forward, out hit))
            {
              
                if (hit.collider.gameObject.CompareTag("HitObject"))
                {
                    shotTo = hit.point;
                    lineRenderer.SetPosition(1, hit.point);
                    HitObject hitobjsHitObject = hit.collider.gameObject.GetComponent<HitObject>();
                    hitobjsHitObject.OnDamaged(new HitData(10));
                }
                
            }
            if (CT_LazerBeam <= 0)
            {
                CT_LazerBeam = 0.1f;
                Vector3 shotFrom = this.transform.position + PlayerCameraObj.transform.rotation * (Vector3.forward * (1 + LazerBeamSize / 2));
                //Instantiate(LazerBeamObject, shotFrom, V3_MyUtil.RotateV2V(Vector3.forward,shotTo- shotFrom));
            }
        }
        else 
        {
            lineRenderer.enabled = false;
        }
        
    }

    
}
