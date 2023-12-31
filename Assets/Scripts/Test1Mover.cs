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
    public HPComponent hpComp;

    public LineRenderer lineRenderer;

    public GameObject LazerBeamObject;
    public GameObject SealdObject;

    public AudioSource audioSource;
    public AudioClip audioClip;


    public float LazerBeamSize;

    float InvicibilityTimer = 0;
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
        if (Input.GetKey(KeyCode.A) & !LeftMoveStop)//左に移動+左パリィ
        {
            CurTheta += AngularV * Time.deltaTime;

            if ((RightDrill.isParring | (!LeftDrill.isParring & !RightDrill.isParring)) & !CantStartParring_L)
            {
                CantStartParring_L = true;
                CantStartParring_R = false;


                ParringTimer = 0.3f;
                LeftDrill.isParring = true;
                RightDrill.isParring = false;
            }

        }
        else if (Input.GetKey(KeyCode.D) & !RightMoveStop)//右に移動+右パリィ
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
        else 
        {
            CantStartParring_L = false;
            CantStartParring_R = false;

            ParringTimer = 0.3f;
            LeftDrill.isParring = false;
            RightDrill.isParring = false;
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

        if (InvicibilityTimer > 0) 
        {
            InvicibilityTimer -= Time.fixedDeltaTime;
        }

        GuardSat.SetActive(IsGuard);
        Quaternion cameraLocalRot = Quaternion.Euler(XRot_xyOrder, YRot_xyOrder, 0);
        Quaternion RotQ =Quaternion.AngleAxis(CurTheta, Vector3.up);

        CenterSat.transform.localRotation = cameraLocalRot;
        

        this.transform.position = CenterPos+ RotQ * Vector3.back* OrbitRadius;
        this.transform.rotation = RotQ;
        LeftMoveStop = false;
        RightMoveStop = false;

        //光線を出す
        if (Input.GetMouseButton(0))
        {
            Vector3 shotTo = this.transform.position + PlayerCameraObj.transform.rotation * Vector3.forward * 100;

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, this.transform.position);
            lineRenderer.SetPosition(1, this.transform.position + PlayerCameraObj.transform.rotation * Vector3.forward * 100);

            float CToPDist=(PlayerCameraObj.transform.position-this.transform.position).magnitude;
            RaycastHit[] hits= Physics.SphereCastAll(PlayerCameraObj.transform.position + PlayerCameraObj.transform.rotation * Vector3.forward * (CToPDist+1), 3, PlayerCameraObj.transform.rotation * Vector3.forward);

            foreach (RaycastHit aHit in hits) 
            {
                

                if (aHit.collider.gameObject.CompareTag("HitObject"))
                {
                    
                    lineRenderer.SetPosition(1, aHit.point);
                    shotTo = aHit.point;
                    break;
                }
                else if (!aHit.collider.gameObject.CompareTag("UnReactReticle"))
                {
                    lineRenderer.SetPosition(1, aHit.point);
                    shotTo = aHit.point;
                    break;
                }
            }


            //RTransform_MyUtil.WorldToCanvasWorld();


            if (CT_LazerBeam <= 0)
            {
                CT_LazerBeam = 0.1f;
                Vector3 shotFrom = this.transform.position + PlayerCameraObj.transform.rotation * (Vector3.forward * (1 + LazerBeamSize / 2));
                Instantiate(LazerBeamObject, shotFrom, V3_MyUtil.RotateV2V(Vector3.forward,shotTo- shotFrom));
                //audioSource.PlayOneShot(audioClip);
            }
        }
        else 
        {
            lineRenderer.enabled = false;
        }
        
    }


    public void OnDeath(HPComponent hpComponent) 
    {
        Debug.Log("しんだ〜");
    }

    public void ExtendParringTimer() 
    {
        if (LeftDrill.isParring|RightDrill.isParring) 
        {
            ParringTimer = 0.3f;
        }
    }

    public void OnDamaged(HitData hitData) 
    {
        if (InvicibilityTimer<=0) 
        {
            audioSource.PlayOneShot(audioClip);
            hpComp.OnDamaged(hitData);
            InvicibilityTimer = 0.2f;
        }
    }
    
}
