using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameRuler : MonoBehaviour
{
    public GameObject ResultPanelObj;
    public TextMeshProUGUI ResultTMPro;
    public HPComponent PlayerHPComponent;

    float DeathEnemyNum=0;

    public SimpleShooter aimingShooter;
    public SimpleShooter aimingShooter2;
    public SimpleShooter orbitBulletShooter;
    public MissilePod missilePod;

    public void OnEnemysDeath(HPComponent hpComp) 
    {
        DeathEnemyNum++;
        if (DeathEnemyNum == 4) 
        {
            float HP = PlayerHPComponent.HP;
            string HPColor = "green";
            string Rank = "SS";
            string RankColor ="yellow";
            if (HP == 300)
            {
                Rank = "SS";
                RankColor = "yellow";
            }
            else if (HP > 260)
            {
                Rank = "S";
                RankColor = "yellow";
            }
            else if (HP > 200)
            {
                Rank = "A";
                RankColor = "red";
            }
            else if (HP > 150)
            {
                Rank = "B";
                RankColor = "blue";
            }
            else if (HP > 100)
            {
                Rank = "C";
                RankColor = "green";
            }
            else if (HP > 50)
            {
                Rank = "D";
                RankColor = "blue";
            }
            else 
            {
                Rank = "E";
                RankColor = "purple";
            }
            if (HP < 0) 
            {
                HPColor = "red";
            }
            ResultPanelObj.SetActive(true);
            ResultTMPro.text= $"Result\r\n\r\nRest of HP:<color=\"{HPColor}\">{HP}</color>\r\nRank:<color=\"{RankColor}\">{Rank}</color>";

        }

        Debug.Log("loglog-------------------------------");

        if (aimingShooter) 
        {
            if (DeathEnemyNum == 1)
            {
                aimingShooter.BulletNum = 12;
            }
            else if (DeathEnemyNum == 2) 
            {
                aimingShooter.BulletNum = 20;
            }
            else if (DeathEnemyNum == 3)
            {
                aimingShooter.BulletNum = 20;
                aimingShooter.ShootCT = 1;
            }
        }
        if (aimingShooter2) 
        {
            if (DeathEnemyNum == 1)
            {
                aimingShooter2.BulletNum = 12;
            }
            else if (DeathEnemyNum == 2)
            {
                aimingShooter2.BulletNum = 20;
            }
            else if (DeathEnemyNum == 3)
            {
                aimingShooter2.BulletNum = 20;
                aimingShooter2.ShootCT = 1;
            }
        }
        if (orbitBulletShooter)
        {
            Debug.Log("loglog2-------------------------------");
            if (DeathEnemyNum == 1)
            {
               
                orbitBulletShooter.ShootCT = 0.7f;
            }
            else if (DeathEnemyNum == 2)
            {
                orbitBulletShooter.ShootCT = 0.5f;
            }
            else if (DeathEnemyNum == 3)
            {
                orbitBulletShooter.ShootCT = 0.2f;
            }
        }
        if (missilePod) 
        {
            if (DeathEnemyNum == 1)
            {
                missilePod.MissileCT = 1.5f;
            }
            else if (DeathEnemyNum == 2)
            {
                missilePod.MissileCT = 1f;
            }
            else if (DeathEnemyNum == 3)
            {
                missilePod.MissileCT = 0.3f;
            }
        }
    }


}
