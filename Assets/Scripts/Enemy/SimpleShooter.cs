using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShooter : MonoBehaviour
{
    public GameObject BulletObject;
    public float ShootCT = 2;
    public float ShootingTime = 1;
    public int BulletNum = 10;

    public Vector3 SpawnOffset=new Vector3(0,0,3);
    // Start is called before the first frame update
    void Start()
    {
        FixedUpdateAsync().Forget();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private async UniTaskVoid FixedUpdateAsync()
    {
        while (true)
        {
            await UniTask.Delay((int)(ShootCT * 1000), false, PlayerLoopTiming.FixedUpdate, this.gameObject.GetCancellationTokenOnDestroy());
            int wait_miliSec = (int)(ShootingTime / BulletNum * 1000);
            for (int i = 0; i < BulletNum; i++)
            {
                Instantiate(BulletObject.gameObject, this.transform.position + SpawnOffset, this.transform.rotation);
                await UniTask.Delay(wait_miliSec, false, PlayerLoopTiming.FixedUpdate, this.gameObject.GetCancellationTokenOnDestroy());
            }
        }




    }
}
