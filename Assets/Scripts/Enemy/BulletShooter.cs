using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject PlayerObject;
    public HormingMover BulletMover;
    public float ShootCT=2;
    public float ShootingTime=1;
    public int BulletNum=10;
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
            await UniTask.Delay((int)(ShootCT * 1000), false,PlayerLoopTiming.FixedUpdate, this.gameObject.GetCancellationTokenOnDestroy());
            int wait_miliSec = (int)(ShootingTime/ BulletNum * 1000);
            for (int i=0;i<BulletNum;i++) 
            {
                HormingMover tempMover = Instantiate(BulletMover.gameObject, this.transform.position + Vector3.up * 3, Quaternion.Euler(-90, 0, 0)).GetComponent<HormingMover>();
                tempMover.TargetObject = PlayerObject;
                await UniTask.Delay(wait_miliSec,false,PlayerLoopTiming.FixedUpdate,this.gameObject.GetCancellationTokenOnDestroy());
            }
        }
        
        

        
    }
}
