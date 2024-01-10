using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


// 230905 지호준 commnet
// 구현 해보았습니다. 적용은 안해봐서 수정이 필요한 부분도 분명히 있을 거라고 생각하고 있습니다.
// 구현한 부분은 주석으로 설명 달았습니다 확인해주시고 오류가 뜨는 부분이 있거나 이해가 안되시면 물어봐주시면
// 감사하겠습니다. 또한 코딩구현을 하면서 조금 생각해 보았는데,
// useSkill 을 skill이 가지는게 아니라 tower가 가지는게 어떨까요?
// 이거는 의견을 좀 듣고 싶습니다. 

[System.Serializable]
[CreateAssetMenu]
public class Skill : ScriptableObject
{
    public Sprite skillImage;
    public string skillOption;
    public string skillDamageText;
    public GameObject skillObj;

    public virtual int UseSkill(GameObject tower)
    {
        return tower.GetComponent<Tower>().status.atk;
    }
    public virtual int UseSkill( Status towerSt )
    {
        towerSt.mp = 0;

        
        return towerSt.atk;
    }
    public virtual void UseSkill( Soldier attacker , Vector3 targetPos , GameObject instantObj)
    {

    }
    public virtual void UseSkill(Vector3 targetPos)
    {
        return;
    }
    public virtual void UseSkill(Soldier attacker, Monster target)
    {
        return;
    }
    public virtual void UseSkill(Soldier attacker, Monster target, GameObject instantObj)
    {
        return;
    }
    // 현재 스킬이 쿨타임에 들어가 있거나, 혹은 마나가 부족한지 체크
    public virtual bool IsUseSkill( Status towerSt)
    {

        if (towerSt.maxMp == towerSt.mp)
        {
            return true;
        }
        return false;
    }
}
