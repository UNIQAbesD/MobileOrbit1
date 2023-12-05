using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;
using System.Threading;

public class DamageDisp : MonoBehaviour
{
    public int DamagePoint=999;
    public float RisingTime=1;
    public float PhadingTime=0.5f;
    public TextMeshProUGUI tmp;


    // Start is called before the first frame update
    void Start()
    {
        if (!tmp) 
        {
            tmp = GetComponent<TextMeshProUGUI>();
        }
        tmp.text = $"{DamagePoint}";
        FixUpdateAsync().Forget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async UniTaskVoid FixUpdateAsync() 
    {
        float timer= RisingTime;
        while (timer > 0) 
        {
            timer -= Time.fixedDeltaTime;
            await UniTask.Yield(PlayerLoopTiming.FixedUpdate,gameObject.GetCancellationTokenOnDestroy());
            this.transform.position += Vector3.up*Time.fixedDeltaTime*10;

        }

        timer = PhadingTime;
        while (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
            await UniTask.Yield(PlayerLoopTiming.FixedUpdate, gameObject.GetCancellationTokenOnDestroy());
            Color CurColor = tmp.color;
            CurColor.a = timer / PhadingTime;
            tmp.color = CurColor;
        }
        Destroy(tmp.gameObject);

    }
}
