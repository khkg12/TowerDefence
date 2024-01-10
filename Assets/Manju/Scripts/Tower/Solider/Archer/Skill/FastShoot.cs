using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class FastShoot : Skill
{
    public override void UseSkill(Soldier attacker, Monster target)
    {
        float delay = 0.1f;
        Archer archer = (Archer)attacker;
        delay = archer.status.atkSpeed;
        archer.status.atkSpeed = 0.5f;
        archer.AttackSpeedInit(5.0f, delay);
    }
}
