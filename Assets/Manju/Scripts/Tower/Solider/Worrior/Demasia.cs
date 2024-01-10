using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Demasia : Skill
{
    public GameObject demasia;
    public GameObject demasiaRange;

    public override int UseSkill(GameObject tower)
    {
        Tower selectTower = tower.GetComponent<Tower>();
        selectTower.status.mp = 0;

        Vector3 createPos = selectTower.transform.position;
        Quaternion createAngle = selectTower.transform.rotation;

        GameObject demasiaObj;
        demasiaObj = Instantiate(demasia, createPos, createAngle);
        demasiaObj.transform.position += demasiaObj.transform.forward * 2.5f;

        GameObject demasiaRangeObj;
        demasiaRangeObj = Instantiate(demasiaRange, createPos, createAngle);
        demasiaRangeObj.transform.position += demasiaRangeObj.transform.forward * 3f;
        demasiaRangeObj.GetComponent<DemasiaController>().atk = selectTower.status.atk;

        return selectTower.status.atk;
    }
}
