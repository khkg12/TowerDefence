using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SwordAuror : Skill
{
    public GameObject auror;

    public override int UseSkill(GameObject tower)
    {
        Tower selectTower = tower.GetComponent<Tower>();
        selectTower.status.mp = 0;

        Vector3 createPos = selectTower.transform.position;
        Quaternion createAngle = selectTower.transform.rotation;

        GameObject createObj;
        createObj = Instantiate(auror, createPos, createAngle);
        createObj.transform.position += createObj.transform.forward;
        createObj.GetComponent<SwordAurorController>().atk = selectTower.status.atk;

        return selectTower.status.atk;
    }
}
