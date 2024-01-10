using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archmage : Soldier
{
    [SerializeField] private GameObject baseAttackObj;

    protected override void Attack(GameObject targetObj)
    {
        // 투사체의 타겟정보 전달을 위한 생성 후 캐싱
        if (targetObj.TryGetComponent<Monster>(out var monster))
        {
            AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.idleSound], transform.position);
            animator.SetTrigger("isAttack");
            Quaternion qua = transform.rotation;
            qua.eulerAngles = new Vector3(0, 90, -115);
            GameObject bao = Instantiate(baseAttackObj, targetObj.transform.position, qua); // 타겟의 위치에 기본공격 생성(범위공격)                    
            bao.GetComponent<wizzardBaseObj>().SetAtk(status.atk);
        }
    }

    public override void UseSkill()
    {
        if(status.mp != status.maxMp)
        {
            return;
        }

        AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.skillSound], transform.position);
        status.mp = 0;
        status.towerSkills[0].UseSkill(gameObject);
    }
}
