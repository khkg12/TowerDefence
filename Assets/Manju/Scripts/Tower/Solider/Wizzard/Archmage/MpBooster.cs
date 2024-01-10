using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MpBooster : Skill
{    
    public override int UseSkill(GameObject tower)
    {        
        GameObject bo = Instantiate(skillObj);
        bo.GetComponent<MpBoosterController>().SetAttack(tower.GetComponent<Soldier>());
        return 1;
    }    
}
