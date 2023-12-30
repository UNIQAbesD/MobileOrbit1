using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSat1 : MonoBehaviour
{

    public Test1Mover ParentMover;
    public bool IsRight;
    public bool isParring;
    public Animator animator;

    public HPComponent hpComponent;

    public AudioSource audioSource;
    public AudioClip ParryClip;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isParring & !animator.GetCurrentAnimatorStateInfo(0).IsName("Rolling"))
        {
            //Debug.Log("âÒÇÍÅ`");
            animator.Play("Rolling", 0);
        }
        else if (!isParring & !animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) 
        {
            //Debug.Log("Ç∆Ç‹ÇÍÅ`");
            animator.Play("Idle", 0);
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("HitObject")) 
        {
            return;
        }
        HitObject hitObject=other.gameObject.GetComponent<HitObject>();
        hitObject.OnDamaged(new HitData(10));



        if (IsRight) 
        {
            Debug.Log("migi");
            ParentMover.RightMoveStop=true;
        }
        else 
        {
            Debug.Log("hidari");
            ParentMover.LeftMoveStop = true;
        }
    }

    public void OnDamage(HitData hitData)
    {
        if (isParring)
        {
            audioSource.PlayOneShot(ParryClip);
            Debug.Log("ÉpÉäÉBÇµÇ‹ÇµÇΩ");
            ParentMover.ExtendParringTimer();
        }
        else
        {
            ParentMover.OnDamaged(hitData);
        }
    }
}


