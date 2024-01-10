using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseObj : MonoBehaviour
{
    // 화살프리팹에 붙어있을 스크립트    
    GameObject target;    
    Vector3 attackerPos;
    int atk;
    Vector3 targetPos;
    public float moveSpeed;
    public float atkRange;
    


    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        // 타겟이 null이 되었을 때 기사의 경우에는 바로 대미지를 줘서 update에 InitTarget을 넣어서 바로바로 최신화해도 상관없지만
        // 궁수나 마법사와 같이 프리팹에 날라가는 경우엔 바로대미지를 줄수있는게 아니고 화살이 타겟에 도달했을 때 대미지를 입어야함
        // 그래서 화살이 날아가는 도중에 타겟이 죽어서 null이 될 때 그 공격을 실패로 처리해 Destroy됨
        if (target != null) // 타겟이 있을 때만 
        {            
            targetPos = target.transform.position;
            MoveAttackToTarget();            
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void MoveAttackToTarget()
    {        
        Vector3 tempPos = new Vector3(targetPos.x, targetPos.y, transform.position.z) - transform.position;
        transform.forward = tempPos;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed);
        float targetDis = Vector3.Distance(transform.position, targetPos); // 화살과 타겟과의 거리, tempPos가 0일때로 써도될듯
        float towerDis = Vector3.Distance(transform.position, attackerPos); // 화살과 화살을 쏜 타워와의 거리
        if (targetDis == 0 || towerDis >= atkRange) // distance가 최대범위를 벗어나거나, 타겟과의 거리가 0이되면 
        {
            if(targetDis == 0)
            {
                target.GetComponent<Monster>().TakeDamage(atk);
            }            
            Destroy(gameObject);
        }        
    }

    public void SetTarget(GameObject target, Vector3 attackerPos, int atk)
    {
        this.target = target;
        this.attackerPos = attackerPos;
        this.atk = atk;
    }   
}
