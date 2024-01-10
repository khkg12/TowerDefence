using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Soldier
{    
    // 위자드는 rangeObj
    [SerializeField] private GameObject baseAttackObj;

    protected override void Attack(GameObject targetObj)
    {
        // 투사체의 타겟정보 전달을 위한 생성 후 캐싱
        if (targetObj.TryGetComponent<Monster>(out var monster))
        {
            AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.idleSound], transform.position);
            animator.SetTrigger("isAttack");            
            GameObject bao = Instantiate(baseAttackObj, transform.position, transform.rotation); // 내 위치에서 생성            
            bao.GetComponent<ChaseObj>().SetTarget(targetObj, transform.position, status.atk);
        }
    }

    public override void UseSkill()
    {
        if (status.mp != status.maxMp)
            return;

        AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.skillSound], transform.position);
        status.mp = 0;
        status.towerSkills[0].UseSkill(gameObject);
    }
}
