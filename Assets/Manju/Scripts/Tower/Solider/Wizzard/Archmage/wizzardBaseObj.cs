using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizzardBaseObj : MonoBehaviour
{
    int atk;
    [SerializeField] float atkAmount;

    // 콜리젼 충돌이어야하니까 몬스터의 isTrigger를 해제해줘야함 그런데 트리거로 해둔이유가 있었나? 물어보기 이거스킬임 Base는 다시만들기

    private void OnParticleSystemStopped() // StopAction에 콜백으로 받을 때 호출, 그냥 StopAction Destroy로 설정해서 파괴시킴
    {
        Destroy(gameObject);
    }
    

    private void OnParticleCollision(GameObject other)
    {        
        if (other.TryGetComponent<Monster>(out var monster))
        {                
            monster.TakeDamage(atk);            
        }
    }    

    public void SetAtk(int atk)
    {
        // this.atk = (int)(atkAmount * atk); 
        this.atk = atk;
    }
}
