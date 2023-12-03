using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarightMover : MonoBehaviour
{
    public float LifeTime = 0;
    public Vector3 LocalDorection=new  Vector3(0,0,1);
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position+= this.transform.rotation*LocalDorection.normalized*Speed*Time.deltaTime;
        LifeTime-=Time.fixedDeltaTime;
        if (LifeTime < 0) 
        {
            Destroy(gameObject);
        }
    }
}
