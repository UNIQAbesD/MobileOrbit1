using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePod : MonoBehaviour
{
    public GameObject PlayerObject;
    public HormingMover MissileMover;
    public float MissileCT;
    public float RestMissileCT;
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
        if (RestMissileCT <= 0)
        {
            RestMissileCT = MissileCT;
            HormingMover tempMover = Instantiate(MissileMover.gameObject, this.transform.position + Vector3.up * 3, Quaternion.Euler(-90, 0, 0)).GetComponent<HormingMover>();
            tempMover.TargetObject = PlayerObject;
            HormingMissile hormingMissile = tempMover.GetComponent<HormingMissile>();
            hormingMissile.HitBackTarget = this.gameObject;
        }
        else 
        {
            RestMissileCT -= Time.fixedDeltaTime;
        }
        

    }
}
