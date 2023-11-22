using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSat1 : MonoBehaviour
{

    public Test1Mover ParentMover;
    public bool IsRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
