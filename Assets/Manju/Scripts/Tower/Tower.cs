using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 23.09.05 지호준 comment

// public Skill skill 에서 => public List<Skill> towerSkils; 로 변경


[System.Serializable]
public class Status
{
    public int cost; // 타워 가격
    public int atk; // 평타 데미지
    public float atkSpeed; // 평타 속도
    public int mp; // 현재 Mp
    public int recoveryMp; // Mp 회복량
    public int maxMp; // 최대 Mp

    // 그 타워에 맞는  스크립트 드래그앤 드롭 하기
    public List<Skill> towerSkills;
}


public class Tower : MonoBehaviour
{
    public Status status;
    public GameObject nextLevelTower;

    public virtual int GetCost()
    {
        return status.cost;
    }

    public virtual List<Skill> GetTowerSkills()
    {
        return status.towerSkills;
    }

    public virtual void UseSkill()
    {
        if(status.towerSkills.Count > 0 && status.mp == status.maxMp)
        {
            status.towerSkills[0].UseSkill(status);
        }
    }
}
