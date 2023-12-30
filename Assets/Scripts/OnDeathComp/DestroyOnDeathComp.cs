using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class DestroyOnDeathComp : MonoBehaviour
{
    public float deathTimeLag=0;
    public void OnDeath(HPComponent hpComponent) 
    {
        if (deathTimeLag <= 0)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            deathTask().Forget();
        }
    }

    async UniTaskVoid deathTask() 
    {
        await UniTask.Delay((int)(deathTimeLag*1000),cancellationToken: gameObject.GetCancellationTokenOnDestroy());
        Destroy(this.gameObject);
    }

}
