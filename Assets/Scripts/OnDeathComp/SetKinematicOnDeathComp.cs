using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetKinematicOnDeathComp : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rigidBody;
    public MonoBehaviour[] MoveList;

    private void Start()
    {
        if (!rigidBody) 
        {
            rigidBody = GetComponent<Rigidbody>();
        }
    }

    public void OnDeath(HPComponent hpComponent) 
    {
        
        foreach (var AMono in MoveList) 
        {
            AMono.enabled = false;
        }
        rigidBody.isKinematic = false;
    }
}
