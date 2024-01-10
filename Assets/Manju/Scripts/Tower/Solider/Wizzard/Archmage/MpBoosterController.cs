using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpBoosterController : MonoBehaviour
{
    int skillTime;
    float atkSpeed;
    Soldier attacker;
    void Start()
    {
        atkSpeed = attacker.status.atkSpeed;
        skillTime = 5; // 매직넘버 인스펙터에서 변경
        attacker.isAttack = true;
        StartCoroutine(DelayCo());
    }
    
    IEnumerator DelayCo()
    {
        attacker.status.atkSpeed = 0.5f; // 매직넘버 인스펙터에서 변경
        yield return new WaitForSeconds(skillTime);
        attacker.status.atkSpeed = atkSpeed;
    }

    public void SetAttack(Soldier attacker)
    {
        this.attacker = attacker;
    }
}
