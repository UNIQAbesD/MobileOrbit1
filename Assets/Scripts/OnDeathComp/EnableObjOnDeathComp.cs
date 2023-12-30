using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjOnDeathComp : MonoBehaviour
{
    public GameObject EnableOject;
    // Start is called before the first frame update
    public void OnDeath(HPComponent hpComponent)
    {
        EnableOject.SetActive(true);
    }
}
