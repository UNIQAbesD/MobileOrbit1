using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUIOnDamagedComp : MonoBehaviour
{
    public GameObject CanvasObj;
    public DamageDisp damageDisp;

    private RectTransform canvasRect;

    private void Start()
    {
        canvasRect = CanvasObj.GetComponent<RectTransform>();
    }

    public void OnDamaged(HitData hitData)
    {
        damageDisp.DamagePoint = (int)hitData.damagePoint;
        Vector3 damageDispPos = Vector3.zero ;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasRect,Camera.main.WorldToScreenPoint(this.transform.position),null,  out damageDispPos);
        damageDispPos +=50*( Random.Range(-1f, 1f)*new Vector3(1,0,0)+ Random.Range(-1f, 1f) * new Vector3(0, 1, 0));
        GameObject dispObj= Instantiate(damageDisp.gameObject, damageDispPos, Quaternion.identity, CanvasObj.transform);
        //dispObj.transform.position = damageDispPos;
    }
}
