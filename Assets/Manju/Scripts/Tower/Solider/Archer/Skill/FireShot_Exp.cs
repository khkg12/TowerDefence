using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireShot : Skill
{
    // Start is called before the first frame update

    public GameObject shot;
    [SerializeField]
    private GameObject tower;
    private Monster monster;
    private RangeObj range;



    public override void UseSkill( Soldier attacker , Monster target, GameObject instantObj)
    {
        Init(attacker,monster,instantObj);
        Transform towerTrans = attacker.transform;
        range = Instantiate(instantObj,attacker.gameObject.transform).GetComponent<RangeObj>();
        range.gameObject.transform.position = attacker.transform.position;
        range.SetTarget(target.gameObject , attacker);

    }

    public override void UseSkill(Soldier attacker, Vector3 targetPos, GameObject instantObj)
    {
        Init(attacker, monster, instantObj);
        Transform towerTrans = attacker.transform;
        range = Instantiate(instantObj, attacker.gameObject.transform).GetComponent<RangeObj>();
        range.gameObject.transform.position = attacker.transform.position;
        range.SetTarget(targetPos, attacker);

    }



    public void Init( Soldier tower , Monster monster, GameObject instantObj)
    {

        this.monster = monster;
        this.tower = tower.gameObject;
        this.range = instantObj.GetComponent<RangeObj>();

    }








}
