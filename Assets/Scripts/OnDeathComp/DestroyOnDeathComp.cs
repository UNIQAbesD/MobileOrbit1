using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDeathComp : MonoBehaviour
{
    public void OnDeath(HPComponent hpComponent) 
    {
        Destroy(this.gameObject);
    }
}
