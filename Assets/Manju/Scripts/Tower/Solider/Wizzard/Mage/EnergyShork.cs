using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnergyShork : Skill
{
    public override void UseSkill(Vector3 targetPos)
    {        
        Quaternion qua = TowerManager.Instance.selectTile.towerObj.transform.rotation;
        Vector3 pos = new Vector3(targetPos.x, targetPos.y, targetPos.z - 1.8f);
        Instantiate(skillObj, pos, qua);
    }

}
