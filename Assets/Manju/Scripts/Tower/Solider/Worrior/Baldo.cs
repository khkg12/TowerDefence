using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Baldo : Skill
{
    public GameObject baldo;

    public override int UseSkill(GameObject tower)
    {
        Tower selectTower = tower.GetComponent<Tower>();
        selectTower.status.mp = 0;

        Vector3 createPos = selectTower.transform.position;
        Quaternion createAngle = selectTower.transform.rotation;

        GameObject createObj;
        createObj = Instantiate(baldo, createPos, createAngle);
        createObj.GetComponent<BaldoController>().atk = selectTower.status.atk;

        return selectTower.status.atk;
    }
}
