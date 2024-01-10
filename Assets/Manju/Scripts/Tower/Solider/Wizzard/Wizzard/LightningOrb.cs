using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LightningOrb : Skill
{
    public override int UseSkill(GameObject tower)
    {
        Transform pos = TowerManager.Instance.selectTile.towerObj.transform;
        Quaternion qua = TowerManager.Instance.selectTile.towerObj.transform.rotation;
        Instantiate(skillObj, pos.position, qua);
        return 10;
    }


}
