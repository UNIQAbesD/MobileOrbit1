using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HormingMissile : MonoBehaviour
{
    public HormingMover mover;
    public FriendlyHitter friendlyHitter;
    public GameObject HitBackTarget;
    public float HP;
    bool isHPZeroEventInvoked;
    // Start is called before the first frame update
    void Start()
    {
        isHPZeroEventInvoked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit(HitObject hitObject)
    {
        hitObject.OnDamaged(new HitData(10));
    }


    public void OnDamaged(HitData hitData) 
    {
        //Debug.Log($"{hitData.damagePoint}É_ÉÅÇ‡ÇÁÇ¡ÇΩÅ`");
        HP -= hitData.damagePoint;
        if (HP<=0& !isHPZeroEventInvoked) 
        {
            isHPZeroEventInvoked = true;
            Debug.Log("Ç§ÇøÇ©Ç¶ÇµÇΩÅI");
            this.transform.rotation =this.transform.rotation*Quaternion.Euler(0,180,0);
            mover.TargetObject = HitBackTarget;
            mover.LifeTime = 4;
            friendlyHitter.FriendryLayer = 0;
        }
    }
}
